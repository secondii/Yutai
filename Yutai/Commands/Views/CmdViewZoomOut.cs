﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using Yutai.Plugins.Concrete;
using Yutai.Plugins.Enums;
using Yutai.Plugins.Interfaces;

namespace Yutai.Commands.Views
{
    public class CmdViewZoomOut : YutaiTool
    {
        private IPoint _iPoint;
        private INewEnvelopeFeedback _envelopeFeedback;
        private bool _inZoom;
        private Cursor _cursor;
        private Cursor _cursor1;
        private RibbonItemType _itemType;


        public CmdViewZoomOut(IAppContext context)
        {
            OnCreate(context);
        }

        public override RibbonItemType ItemType
        {
            get { return RibbonItemType.Tool; }
        }

        public override void OnClick()
        {
            _inZoom = false;
            _context.SetCurrentTool(this);
        }


        public override void OnClick(object sender, EventArgs args)
        {
            OnClick();
        }

        public override void OnCreate(object hook)
        {
            _context = hook as IAppContext;
            base.m_caption = "缩小";
            base.m_category = "View";
            base.m_bitmap = Properties.Resources.icon_zoom_out;
            _cursor = new Cursor(base.GetType().Assembly.GetManifestResourceStream("Yutai.Resource.Cursor.ZoomOut.cur"));
            _cursor1 =
                new Cursor(base.GetType().Assembly.GetManifestResourceStream("Yutai.Resource.Cursor.MoveZoomOut.cur"));
            base.m_name = "View.Common.ZoomOut";
            base._key = "View.Common.ZoomOut";
            base.m_toolTip = "缩小";
            base.m_checked = false;
            base.m_enabled = true;
            base._itemType = RibbonItemType.Tool;
        }

        public override void OnKeyDown(int keyCode, int shift)
        {
            if (_inZoom && keyCode == 27)
            {
                this._envelopeFeedback = null;
                this._inZoom = false;
                base.m_cursor = this._cursor1;
            }
        }

        public override void OnMouseDown(int button, int shift, int x, int y)
        {
            if (button != 2)
            {
                this._iPoint =
                    ((IActiveView) _context.MapControl.ActiveView).ScreenDisplay.DisplayTransformation.ToMapPoint(x, y);
                this.m_cursor = this._cursor1;
                this._inZoom = true;
            }
        }

        public override void OnMouseMove(int button, int shift, int x, int y)
        {
            if (this._inZoom)
            {
                IActiveView focusMap = (IActiveView) _context.MapControl.ActiveView;
                if (_envelopeFeedback == null)
                {
                    _envelopeFeedback = new NewEnvelopeFeedbackClass()
                    {
                        Display = focusMap.ScreenDisplay
                    };
                    _envelopeFeedback.Start(_iPoint);
                }
                _envelopeFeedback.MoveTo(focusMap.ScreenDisplay.DisplayTransformation.ToMapPoint(x, y));
            }
        }

        public override void OnMouseUp(int button, int shift, int x, int y)
        {
            IEnvelope extent;
            IEnvelope newextent;
            if (this._inZoom)
            {
                this.m_cursor = this._cursor;
                this._inZoom = false;
                IActiveView focusMap = (IActiveView) _context.MapControl.ActiveView;
                if (this._envelopeFeedback != null)
                {
                    extent = this._envelopeFeedback.Stop();
                    if ((extent.Width == 0 ? false : extent.Height == 0))
                    {
                        double width = focusMap.Extent.Width*(focusMap.Extent.Width/extent.Width);
                        double height = focusMap.Extent.Height*(focusMap.Extent.Height/extent.Height);
                        newextent = new ESRI.ArcGIS.Geometry.Envelope() as IEnvelope;
                        newextent.PutCoords(
                            focusMap.Extent.XMin -
                            (extent.XMin - focusMap.Extent.XMin)*(focusMap.Extent.Width/extent.Width),
                            focusMap.Extent.YMin -
                            (extent.YMin - focusMap.Extent.YMin)*(focusMap.Extent.Height/extent.Height),
                            focusMap.Extent.XMin -
                            (extent.XMin - focusMap.Extent.XMin)*(focusMap.Extent.Width/extent.Width) + width,
                            focusMap.Extent.YMin -
                            (extent.YMin - focusMap.Extent.YMin)*(focusMap.Extent.Height/extent.Height) + height);
                    }
                    else
                    {
                        newextent = focusMap.Extent;
                        newextent.Expand(2, 2, true);
                        newextent.CenterAt(this._iPoint);
                    }
                }
                else
                {
                    newextent = focusMap.Extent;
                    newextent.Expand(2, 2, true);
                    newextent.CenterAt(this._iPoint);
                }
                focusMap.Extent = newextent;
                this._envelopeFeedback = null;
                focusMap.Refresh();
            }
        }
    }
}
