﻿using System;
using System.Collections.Generic;
using System.Xml;
using DevExpress.XtraBars.Ribbon;
using Yutai.Plugins.Interfaces;
using Yutai.UI.Menu.Ribbon;

namespace Yutai.Pipeline.Analysis.Menu
{
    internal class MenuGenerator
    {
        private readonly IAppContext _context;
        private readonly YutaiCommands _commands;
        private readonly object _menuManager;
        private readonly PipelineAnalysisPlugin _plugin;


        public MenuGenerator(IAppContext context, PipelineAnalysisPlugin plugin)
        {
            if (context == null) throw new ArgumentNullException("context");
            // if (pluginManager == null) throw new ArgumentNullException("pluginManager");

            _plugin = plugin;
            _context = context;
            _menuManager = _context.MainView.RibbonManager;
            _commands = new YutaiCommands(_context, plugin);
            _commands.Plugin = plugin;
            InitMenus();
        }

        public List<string> GetMenuKeys()
        {
            return _commands.GetKeys();
        }

        private void InitMenus()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(base.GetType().Assembly.GetManifestResourceStream("Yutai.Pipeline.Analysis.Menu.MenuLayout.xml"));
            RibbonFactory.CreateMenus(_commands.GetCommands(), (RibbonControl) _menuManager,
                _context.MainView.RibbonStatusBar as RibbonStatusBar, doc);
        }
    }
}