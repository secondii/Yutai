﻿// 项目名称 :  Yutai
// 项目描述 :  
// 类 名 称 :  CmdExportAll.cs
// 版 本 号 :  
// 说    明 :  
// 作    者 :  
// 创建时间 :  2017/06/08  18:51
// 更新时间 :  2017/06/08  18:51

using System;
using ESRI.ArcGIS.Carto;
using Yutai.Plugins.Concrete;
using Yutai.Plugins.Enums;
using Yutai.Plugins.Interfaces;
using Yutai.Plugins.TableEditor.Editor;
using Yutai.Plugins.TableEditor.Views;
using Yutai.UI.Dialogs;

namespace Yutai.Plugins.TableEditor.Commands
{
    public class CmdExportAll : YutaiCommand
    {
        private ITableEditorView _view;

        public CmdExportAll(IAppContext context, ITableEditorView view)
        {
            _context = context;
            _view = view;
            OnCreate();
        }

        private void OnCreate()
        {
            base.m_caption = "导出记录";
            base.m_category = "TableEditor";
            base.m_bitmap = null;
            base.m_name = "tedSelection.mnuExportAll";
            base._key = "tedSelection.mnuExportAll";
            base.m_toolTip = "导出记录";
            base.m_checked = false;
            base.m_enabled = true;
            base._itemType = RibbonItemType.Button;
        }

        public override void OnClick(object sender, EventArgs args)
        {
            OnClick();
        }

        public override void OnCreate(object hook)
        {
            OnCreate();
        }

        public override void OnClick()
        {
            frmExportData data = new frmExportData();
            data.FocusMap = _context.FocusMap as IBasicMap;
            data.FeatureLayer = _view.CurrentGridView.FeatureLayer;
            data.ShowDialog();
        }
    }
}