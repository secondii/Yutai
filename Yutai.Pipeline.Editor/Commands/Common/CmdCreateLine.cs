﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using Yutai.ArcGIS.Common.Editor;
using Yutai.Pipeline.Config.Interfaces;
using Yutai.Pipeline.Editor.Helper;
using Yutai.Pipeline.Editor.Properties;
using Yutai.Plugins.Concrete;
using Yutai.Plugins.Enums;
using Yutai.Plugins.Interfaces;

namespace Yutai.Pipeline.Editor.Commands.Common
{
    class CmdCreateLine : YutaiTool
    {
        private PipelineEditorPlugin _plugin;
        private IPipelineConfig _config;
        private INewLineFeedback _lineFeedback;
        private IPointSnapper _pointSnapper;
        private IFeatureLayer _pointFeatureLayer;
        private IFeatureLayer _lineFeatureLayer;

        public CmdCreateLine(IAppContext context, PipelineEditorPlugin plugin)
        {
            OnCreate(context);
            _plugin = plugin;
        }

        public override void OnClick(object sender, EventArgs args)
        {

            if (_plugin.CurrentLayer == null)
            {
                MessageBox.Show(@"未设置当前编辑图层！");
                _context.ClearCurrentTool();
                return;
            }
            IBasicLayerInfo pointLayerInfo = _plugin.CurrentLayer.Layers.FirstOrDefault(c => c.DataType == enumPipelineDataType.Point);
            if (pointLayerInfo != null)
                _pointFeatureLayer = CommonHelper.GetLayerByName(_context.FocusMap, pointLayerInfo.AliasName, true) as IFeatureLayer;
            IBasicLayerInfo lineLayerInfo = _plugin.CurrentLayer.Layers.FirstOrDefault(c => c.DataType == enumPipelineDataType.Line);
            if (lineLayerInfo != null)
                _lineFeatureLayer = CommonHelper.GetLayerByName(_context.FocusMap, lineLayerInfo.AliasName, true) as IFeatureLayer;
            if (_pointFeatureLayer == null || _lineFeatureLayer == null)
            {
                MessageBox.Show(@"点图层或线图层未设置！");
                _context.ClearCurrentTool();
                return;
            }


            _context.SetCurrentTool(this);
            _pointSnapper = new PointSnapper();
            (_pointSnapper as PointSnapper).Map = _context.FocusMap;
        }

        public sealed override void OnCreate(object hook)
        {
            _context = hook as IAppContext;
            base.m_caption = "新建管线";
            base.m_category = "PipelineEditor";
            base.m_bitmap = Properties.Resources.icon_CreateLine;
            this.m_cursor = new System.Windows.Forms.Cursor(new MemoryStream(Resources.Digitise));
            base.m_name = "PipelineEditor_CreateLine";
            base._key = "PipelineEditor_CreateLine";
            base.m_toolTip = "新建管线数据";
            base.m_checked = false;
            base.m_message = "新建管线数据";
            base._itemType = RibbonItemType.Tool;
        }

        public override bool Enabled
        {
            get
            {
                //if (_context.FocusMap == null)
                //    return false;
                //if (_context.FocusMap.LayerCount <= 0)
                //    return false;
                //if (ArcGIS.Common.Editor.Editor.EditMap == null)
                //    return false;
                //if (ArcGIS.Common.Editor.Editor.EditMap != _context.FocusMap)
                //    return false;
                //if (ArcGIS.Common.Editor.Editor.EditWorkspace == null)
                //    return false;
                if (_plugin.CurrentLayer == null)
                    return false;
                return true;
            }
        }

        public override void OnMouseDown(int button, int shift, int x, int y)
        {
            if (button != 1)
                return;

            IActiveView activeView = _context.ActiveView;
            IPoint point = activeView.ScreenDisplay.DisplayTransformation.ToMapPoint(x, y);
            ISnappingResult snappingResult = _pointSnapper.Snap(point);
            if (snappingResult != null)
                point = snappingResult.Location;

            if (_lineFeedback == null)
            {
                _lineFeedback = new NewLineFeedbackClass()
                {
                    Display = activeView.ScreenDisplay
                };
                _lineFeedback.Start(point);
            }
            else
            {
                _lineFeedback.AddPoint(point);
            }
        }

        public override void OnMouseMove(int Button, int Shift, int x, int y)
        {

            IActiveView activeView = _context.ActiveView;
            IPoint point = activeView.ScreenDisplay.DisplayTransformation.ToMapPoint(x, y);
            ISnappingResult snappingResult = _pointSnapper.Snap(point);
            if (snappingResult != null)
                point = snappingResult.Location;

            _lineFeedback?.MoveTo(point);
        }

        public override void OnDblClick()
        {
            try
            {
                if (_lineFeedback == null)
                    return;
                IPolyline polyline = _lineFeedback.Stop();
                if (_lineFeedback != null)
                {
                    _context.ActiveView.Refresh();
                    _lineFeedback = null;
                }
                if (polyline == null)
                    return;
                //CommonHelper.CreatePointFeatures(_pointFeatureLayer, polyline, true, true, true);
                CommonHelper.CreateLineFeature(_lineFeatureLayer, polyline);
                _context.ActiveView.Refresh();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public override void OnKeyDown(int keyCode, int Shift)
        {
            if (keyCode == 27)
            {
                _context.FocusMap.ClearSelection();
                _context.ActiveView.Refresh();
                _lineFeedback = null;
            }
        }
    }
}
