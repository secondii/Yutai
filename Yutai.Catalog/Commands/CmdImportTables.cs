﻿using System;
using Yutai.ArcGIS.Catalog;
using Yutai.ArcGIS.Catalog.Geodatabase.UI;
using Yutai.Plugins.Concrete;
using Yutai.Plugins.Enums;
using Yutai.Plugins.Interfaces;

namespace Yutai.Plugins.Catalog.Commands
{
    class CmdImportTables : YutaiCommand
    {
        public CmdImportTables(IAppContext context)
        {
            OnCreate(context);
        }

        public override void OnCreate(object hook)
        {
            this.m_bitmap = Properties.Resources.icon_catalog_table;
            this.m_caption = "入多个表";
            this.m_category = "Catalog";
            this.m_message = "入多个表";
            this.m_name = "Catalog_ImportMultiTables";
            this._key = "Catalog_ImportMultiTables";
            this.m_toolTip = "入多个表";
            _context = hook as IAppContext;
            DisplayStyleYT = DisplayStyleYT.Image;
            base.TextImageRelationYT = TextImageRelationYT.ImageAboveText;
            base.ToolStripItemImageScalingYT = ToolStripItemImageScalingYT.None;
            _itemType = RibbonItemType.Button;
        }

        public override bool Enabled
        {
            get { return true; }
        }


        public override void OnClick(object sender, EventArgs args)
        {
            OnClick();
        }

        public override void OnClick()
        {
            frmMultiDataConvert _frmMultiDataConvert = new frmMultiDataConvert();
            _frmMultiDataConvert.Clear();
            _frmMultiDataConvert.Add(new MyGxFilterTables());
            _frmMultiDataConvert.OutGxObject = ((IGxSelection) _context.GxSelection).FirstObject;
            _frmMultiDataConvert.ShowDialog();
        }
    }
}