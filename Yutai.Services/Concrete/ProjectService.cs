﻿using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Yutai.Plugins.Concrete;
using Yutai.Plugins.Enums;
using Yutai.Plugins.Interfaces;
using Yutai.Plugins.Services;
using Yutai.Services.Serialization;
using Yutai.Services.Views;
using Yutai.Shared;

namespace Yutai.Services.Concrete
{
    public class ProjectService : IProjectService, IProject
    {
        private const string ProjectFilter = "项目文档(*.yxd)|*.yxd";
        private const int ProjectFilterIndex = 3;

        private ProjectLoadingView _loadingForm;
        private readonly IAppContext _context;
        private readonly IFileDialogService _fileService;
        private readonly IBroadcasterService _broadcaster;
        private readonly IProjectLoader _projectLoader;
        private readonly ProjectLoaderLegacy _projectLoaderLegacy;
        private string _filename = string.Empty;
        private bool _modified;
        private string _title;

        public ProjectService(IAppContext context, IFileDialogService fileService,
            IBroadcasterService broadcaster, IProjectLoader projectLoader, ProjectLoaderLegacy projectLoaderLegacy)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (fileService == null) throw new ArgumentNullException("fileService");
            if (broadcaster == null) throw new ArgumentNullException("broadcaster");
            if (projectLoader == null) throw new ArgumentNullException("projectLoader");
            if (projectLoaderLegacy == null) throw new ArgumentNullException("projectLoaderLegacy");

            _context = context;
            _fileService = fileService;
            _broadcaster = broadcaster;
            _projectLoader = projectLoader;
            _projectLoaderLegacy = projectLoaderLegacy;
        }

        public bool IsEmpty
        {
            get { return _filename.Length == 0; }
        }

        public string Filename
        {
            get { return _filename; }
            set { _filename = value; }
        }

        public ProjectState GetState()
        {
            return State;
                // don't expose as property or it will cause serialization of state on examining it during debugging
        }

        private ProjectState State
        {
            get
            {
                if (_context.MapControl.Map.LayerCount == 0)
                {
                    return ProjectState.Empty;
                }

                if (string.IsNullOrWhiteSpace(_filename))
                {
                    return ProjectState.NotSaved;
                }

                try
                {
                    using (var r = new StreamReader(_filename))
                    {
                        var oldState = r.ReadToEnd();
                        var state = SerializeMapState(_filename);
                        return state.EqualsIgnoreCase(oldState) && !_modified
                            ? ProjectState.NoChanges
                            : ProjectState.HasChanges;
                    }
                }
                catch
                {
                    return ProjectState.NotSaved;
                }
            }
        }

        public bool TryClose()
        {
            var args = new CancelEventArgs();

            if (!(_context is ISecureContext))
            {
                throw new ApplicationException("Invalid application context");
            }

            _broadcaster.BroadcastEvent(p => p.ProjectClosing_, this, args);
            if (args.Cancel)
            {
                return false;
            }

            if (TryCloseCore())
            {
                Clear();

                //_broadcaster.BroadcastEvent(p => p.ProjectClosed_, this, args);
                return true;
            }
            return false;
        }

        private void Clear()
        {
            _filename = "";
            /* _context.Map.GeometryEditor.Clear();
             _context.Legend.Groups.Clear();
             _context.Legend.Layers.Clear();
             _context.Map.SetDefaultExtents();
             _context.Map.MapCursor = Api.Enums.MapCursor.ZoomIn;
 
             if (_context.Locator != null)
             {
                 _context.Locator.Clear();
             }*/
        }

        private bool TryCloseCore()
        {
            var state = State;
            switch (state)
            {
                case ProjectState.NotSaved:
                case ProjectState.HasChanges:
                {
                    string prompt = "是否保存项目?";

                    if (!string.IsNullOrWhiteSpace(_filename))
                    {
                        prompt = string.Format("保存项目: {0}?", Path.GetFileName(_filename));
                    }

                    var result = MessageService.Current.AskWithCancel(prompt);
                    if (result == DialogResult.Cancel)
                    {
                        return false;
                    }

                    if (result == DialogResult.Yes)
                    {
                        Save();
                    }
                    break;
                }
                case ProjectState.NoChanges:
                case ProjectState.Empty:
                    break;
            }

            SetEmptyProject();
            return true;
        }

        public bool Save()
        {
            string filename = _filename;
            var state = State;

            bool newProject = state == ProjectState.NotSaved || state == ProjectState.Empty;
            if (newProject)
            {
                if (!_fileService.SaveFile(ProjectFilter, ref filename))
                {
                    return false;
                }
            }

            SaveProject(filename);

            if (newProject)
            {
                // OnProjectChanged();
            }

            return true;
        }

        public bool SaveAs()
        {
            string filename = _filename;
            if (!_fileService.SaveFile(ProjectFilter, ref filename))
            {
                return false;
            }

            return SaveProject(filename);
        }

        private bool SaveProject(string filename)
        {
            var state = SerializeMapState(filename);

            try
            {
                using (var writer = new StreamWriter(filename))
                {
                    writer.Write(state);
                    writer.Flush();
                    _filename = filename;
                    _modified = false;

                    //  AppConfig.Instance.AddRecentProject(filename);

                    // PM:
                    // MessageService.Current.Info("Project was saved: " + filename);
                    Logger.Current.Info("Project was saved: " + filename);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageService.Current.Warn("Failed to save project: " + ex.Message);
            }

            return false;
        }

        public bool Open()
        {
            string filename;
            if (_fileService.Open(ProjectFilter, out filename, ProjectFilterIndex))
            {
                Open(filename);
                return true;
            }

            return false;
        }

        private ProjectLoaderBase GetCurrentLoader(bool legacy = false)
        {
            return legacy ? _projectLoaderLegacy : (ProjectLoaderBase) _projectLoader;
        }

        public bool Open(string filename, bool silent = true)
        {
            if (!CheckProjectFilename(filename, silent))
            {
                return false;
            }

            if (!TryClose())
            {
                return false;
            }

            ShowLoadingForm(filename);

            bool legacy = !filename.ToLower().EndsWith(".yxd");
            var loader = GetCurrentLoader(legacy);
            loader.ProgressChanged += OnLoadingProgressChanged;

            bool result;

            _context.View.Lock();
            result = OpenCore(filename, silent);

            // let's redraw map before hiding the progress
            _loadingForm.ShowProgress(100, "请等待，正在加载地图...");
          
            _context.View.Unlock();

            Application.DoEvents();

            loader.ProgressChanged -= OnLoadingProgressChanged;

            HideLoadingForm();
            _context.Project.Filename = filename;

            _broadcaster.BroadcastEvent(p => p.ProjectOpened_, this, null);

            return result;
        }

        private void OnLoadingProgressChanged(object sender, Plugins.Events.ProgressEventArgs e)
        {
            _loadingForm.ShowProgress(e.Percent, e.Message);
        }

        private void HideLoadingForm()
        {
            _loadingForm.Close();
            _loadingForm.Dispose();
            _loadingForm = null;
        }

        private void ShowLoadingForm(string filename)
        {
            _loadingForm = new ProjectLoadingView(filename);

            _context.View.ShowChildView(_loadingForm, false);
            Application.DoEvents();
        }

        private bool CheckProjectFilename(string filename, bool silent)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                return false;
            }

            if (!File.Exists(filename))
            {
                if (!silent)
                {
                    MessageService.Current.Info("没有发现项目文件: " + filename);
                }

                return false;
            }

            return true;
        }

        //private bool OpenLegacyProject(string filename, bool silent = false)
        //{
        //    Logger.Current.Info("Start opening legacy MapWindow 4 project: " + filename);

        //    using (var reader = new StreamReader(filename))
        //    {
        //        string state = reader.ReadToEnd();

        //        try
        //        {
        //          /*  var project = state.DeserializeFromXml<MapWin4Project>();
        //            if (!_projectLoaderLegacy.Restore(project, filename))
        //            {
        //                Clear();
        //                SetEmptyProject();
        //                return false;
        //            }

        //            _filename = string.Empty;       // it must be saved in a new format

        //            string message = "Legacy MapWindow 4 project was loaded: " + filename;

        //            if (!silent)
        //            {
        //                MessageService.Current.Info(message);
        //            }

        //            Logger.Current.Info(message);*/

        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            string msg = "Invalid project format: " + filename;
        //            Logger.Current.Warn(msg, ex);
        //            MessageService.Current.Warn(msg);
        //        }
        //    }

        //    return false;
        //}

        private bool OpenCore(string filename, bool silent = true)
        {
            using (var reader = new StreamReader(filename))
            {
                string state = reader.ReadToEnd();
                //reader.Close();
                var project = state.Deserialize<XmlProject>();
                //XmlSerializer serializer = new XmlSerializer(typeof(XmlProject));
                //var project = serializer.Deserialize(new StringReader(state)) as XmlProject;


                if (project.Settings == null)
                {
                    // in case of a bit older project version, where no such settings existed
                    project.Settings = new XmlProjectSettings();
                }

                project.Settings.LoadAsFilename = filename;
                _filename = filename;
                if (!_projectLoader.Restore(project,_loadingForm))
                {
                    Clear();
                    SetEmptyProject();
                    return false;
                }

                // AppConfig.Instance.AddRecentProject(filename);

                

                if (!silent)
                {
                    MessageService.Current.Info("项目被引导中: " + filename);
                }

                Logger.Current.Info("项目被引导中: " + filename);
                _title = project.Title;
               // _context.ProjectChanged(project);
                //OnProjectChanged();
                return true;
            }

            //OnProjectChanged();
        }

        public void SetModified()
        {
            _modified = true;
        }

        public bool Modified
        {
            get
            {
                var state = State;
                return (state == ProjectState.NotSaved || state == ProjectState.HasChanges);
            }
        }

        private string SerializeMapState(string filename)
        {
            var project = new XmlProject(_context as ISecureContext, filename);
            return project.Serialize(false);
        }

        private void SetEmptyProject()
        {
            _filename = "";
            //OnProjectChanged();
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
    }
}