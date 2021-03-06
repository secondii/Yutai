﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraBars;

namespace Yutai.Plugins.Interfaces
{
    public interface ICommandComboBox
    {
        //用于设置左边的标题
        string Caption { get; set; }
        bool ShowCaption { get; set; }
        //0 表示标题和下拉框水平排列，1表示竖直排列
        int LayoutType { get; set; }
        object[] Items { get; set; }
        void OnEditValueChanged(object sender, EventArgs args);

        string SelectedText { get; set; }
        BarEditItem LinkComboBox { get; set; }

        bool DropDownList { get; }
        int Width { get; set; }
    }
}