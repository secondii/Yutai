﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yutai.Pipeline.Config.Interfaces;
using Yutai.Pipeline.Editor.Forms.Exchange;
using Yutai.Plugins.Concrete;
using Yutai.Plugins.Enums;
using Yutai.Plugins.Interfaces;

namespace Yutai.Pipeline.Editor.Commands.Exchange
{
    class CmdDataExport : YutaiTool
    {
        private PipelineEditorPlugin _plugin;
        private IPipelineConfig _config;

        public CmdDataExport(IAppContext context, PipelineEditorPlugin plugin)
        {
            OnCreate(context);
            _plugin = plugin;
        }

        public override void OnClick(object sender, EventArgs args)
        {
            FrmExportData frm = new FrmExportData(_context);
            frm.Show();
        }

        public sealed override void OnCreate(object hook)
        {
            _context = hook as IAppContext;
            base.m_caption = "数据导出";
            base.m_category = "PipelineEditor";
            base.m_bitmap = Properties.Resources.icon_pipe_dcsj;
            base.m_name = "PipelineEditor_DataExport";
            base._key = "PipelineEditor_DataExport";
            base.m_toolTip = "";
            base.m_checked = false;
            base.m_message = "";
            base.m_enabled = true;
            base._itemType = RibbonItemType.Button;
        }
        
        public override void OnDblClick()
        {

        }

        public override void OnMouseDown(int button, int shift, int x, int y)
        {
        }

        public override bool Enabled
        {
            get
            {
                if (_context.FocusMap == null)
                    return false;
                if (_context.FocusMap.LayerCount <= 0)
                    return false;
                return true;
            }
        }
    }
}
