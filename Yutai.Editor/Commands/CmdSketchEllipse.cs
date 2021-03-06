﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using Yutai.ArcGIS.Common;
using Yutai.ArcGIS.Common.Display;
using Yutai.ArcGIS.Common.Editor;
using Yutai.ArcGIS.Common.Editor.Helpers;
using Yutai.ArcGIS.Common.Symbol;
using Yutai.Plugins.Concrete;
using Yutai.Plugins.Editor.Forms;
using Yutai.Plugins.Editor.Properties;
using Yutai.Plugins.Enums;
using Yutai.Plugins.Interfaces;
using Cursor = System.Windows.Forms.Cursor;

namespace Yutai.Plugins.Editor.Commands
{
    public class CmdSketchEllipse : YutaiTool, IShapeConstructorTool
    {
        private ISnappingEnvironment snappingEnvironment = new Snapping();
        private ControlsEditingSketchTool sketchTool = new ControlsEditingSketchTool();
        private ISnappingFeedback snappingFeedback = new SnappingFeedback();
        private IPointSnapper pointSnapper = new PointSnapper();
        private IAnchorPoint anchorPoint = null;
        private IPoint pPoint;
        private INewEllipseFeedback ellipseFeedback = null;
        private ISimpleLineSymbol lineSymbol = new SimpleLineSymbol();
        private ISimpleMarkerSymbol simpleMarkerSymbol = new SimpleMarkerSymbol();

        private int _order = 0;

        private IActiveView activeView;


        public CmdSketchEllipse(IAppContext context)
        {
            OnCreate(context);
        }

        public override void OnCreate(object hook)
        {
            _context = hook as IAppContext;
            base.m_caption = "椭圆工具";
            base.m_category = "Editor";
            base.m_bitmap = Properties.Resources.icon_sketch_ellipse;
            m_cursor = new Cursor(new MemoryStream(Resource.Digitise));
            base.m_name = "Editor_Sketch_Ellipse";
            base._key = "Editor_Sketch_Ellipse";
            base.m_toolTip = "椭圆工具";
            base._itemType = RibbonItemType.Tool;
            this.lineSymbol.Style = esriSimpleLineStyle.esriSLSSolid;
            this.lineSymbol.Width = 1;
            this.lineSymbol.Color = ColorManage.GetRGBColor(0, 255, 255);
            this.simpleMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSCircle;
            this.simpleMarkerSymbol.Size = 8;
            this.simpleMarkerSymbol.Outline = true;
            this.simpleMarkerSymbol.Color = ColorManage.GetRGBColor(0, 255, 255);
        }

        public esriGeometryType GeometryType
        {
            get { return esriGeometryType.esriGeometryPolyline; }
        }

        public override bool Enabled
        {
            get
            {
                bool result;
                if (_context.FocusMap == null)
                {
                    result = false;
                }
                else if (_context.FocusMap.LayerCount == 0)
                {
                    result = false;
                }
                else if (Yutai.ArcGIS.Common.Editor.Editor.EditMap != null &&
                         Yutai.ArcGIS.Common.Editor.Editor.EditMap != _context.FocusMap)
                {
                    result = false;
                }
                else if (Yutai.ArcGIS.Common.Editor.Editor.CurrentEditTemplate == null)
                {
                    result = false;
                }
                else if (Yutai.ArcGIS.Common.Editor.Editor.EditWorkspace != null)
                {
                    IFeatureLayer featureLayer = Yutai.ArcGIS.Common.Editor.Editor.CurrentEditTemplate.FeatureLayer;
                    result = (featureLayer.FeatureClass != null &&
                              featureLayer.FeatureClass.FeatureType == esriFeatureType.esriFTSimple &&
                              featureLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryPoint &&
                              featureLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryMultipoint);
                }
                else
                {
                    result = false;
                }
                return result;
            }
        }


        public override void OnClick(object sender, EventArgs args)
        {
            OnClick();
        }

        public override void OnClick()
        {
            _context.SetCurrentTool(this);
            activeView = _context.FocusMap as IActiveView;
        }

        public override void OnDblClick()
        {
        }

        public override void OnKeyDown(int int_0, int Shift)
        {
            if (int_0 == 27)
            {
                ellipseFeedback = null;
                ((IActiveView) _context.FocusMap).Refresh();
            }
        }


        public override void OnMouseDown(int int_0, int Shift, int int_2, int int_3)
        {
            if (int_0 != 1)
            {
                return;
            }
            IPoint mapPoint = activeView.ScreenDisplay.DisplayTransformation.ToMapPoint(int_2, int_3);
            ISnappingResult snappingResult = this.pointSnapper.Snap(mapPoint);
            if (anchorPoint == null)
            {
                anchorPoint = new AnchorPoint()
                {
                    Symbol = simpleMarkerSymbol as ISymbol
                };
            }
            if (snappingResult != null)
            {
                mapPoint = snappingResult.Location;
            }
            if (_order == 0)
            {
                ellipseFeedback = new NewEllipseFeedback() as INewEllipseFeedback;
                ellipseFeedback.Display = activeView.ScreenDisplay;
                //   ellipseFeedback.Symbol = lineSymbol as ISymbol;
                ellipseFeedback.Start(mapPoint);
                _order = 1;
                return;
            }
            if (_order == 1)
            {
                ellipseFeedback.SetPoint(mapPoint);
                ellipseFeedback.Refresh(activeView.ScreenDisplay.hDC);
                _order = 2;
                return;
            }


            IGeometry circularArc = ellipseFeedback.Stop(mapPoint) as IGeometry;

            ISegmentCollection polylineClass = null;
            object value = Missing.Value;
            IFeatureLayer featureLayer = Yutai.ArcGIS.Common.Editor.Editor.CurrentEditTemplate.FeatureLayer;
            if (featureLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
            {
                polylineClass = new Polyline() as ISegmentCollection;
                ISegmentCollection segmentCollection = circularArc as ISegmentCollection;

                polylineClass.AddSegment(segmentCollection.Segment[0], ref value, ref value);
                CreateFeatureTool.CreateFeature(polylineClass as IGeometry, _context.FocusMap as IActiveView,
                    Yutai.ArcGIS.Common.Editor.Editor.CurrentEditTemplate.FeatureLayer);
            }
            else if (featureLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryPolygon)
            {
                return;
            }
            else
            {
                CreateFeatureTool.CreateFeature(circularArc as IGeometry, _context.FocusMap as IActiveView,
                    Yutai.ArcGIS.Common.Editor.Editor.CurrentEditTemplate.FeatureLayer);
            }


            _order = 0;
            ellipseFeedback = null;
        }

        public override void OnMouseMove(int int_0, int int_1, int int_2, int int_3)
        {
            IPoint mapPoint = activeView.ScreenDisplay.DisplayTransformation.ToMapPoint(int_2, int_3);
            ISnappingResult snappingResult = this.pointSnapper.Snap(mapPoint);

            if (snappingResult != null)
            {
                mapPoint = snappingResult.Location;
            }
            ellipseFeedback.MoveTo(mapPoint);
        }
    }
}