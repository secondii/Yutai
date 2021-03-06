﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using Yutai.ArcGIS.Common;
using Yutai.ArcGIS.Common.Symbol;
using Yutai.ArcGIS.Common.SymbolLib;

namespace Yutai.ArcGIS.Carto.MapCartoTemplateLib
{
    partial class LegendFrameUserControl
    {
        protected override void Dispose(bool bool_1)
        {
            if (bool_1 && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(bool_1);
        }

       
 private void InitializeComponent()
        {
            this.components = new Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LegendFrameUserControl));
            this.imageList_0 = new ImageList(this.components);
            this.btnBorderInfo = new SimpleButton();
            this.btnBorderSelector = new SimpleButton();
            this.cboBorder = new StyleComboBox(this.components);
            this.label16 = new Label();
            this.label17 = new Label();
            this.label18 = new Label();
            this.btnBackgroundInfo = new SimpleButton();
            this.btnBackgroundSelector = new SimpleButton();
            this.cboBackground = new StyleComboBox(this.components);
            this.btnshadowInfo = new SimpleButton();
            this.btnShadowSelector = new SimpleButton();
            this.cboShadow = new StyleComboBox(this.components);
            this.txtCornerRounding = new SpinEdit();
            this.label6 = new Label();
            this.txtGap = new SpinEdit();
            this.label9 = new Label();
            this.txtCornerRounding.Properties.BeginInit();
            this.txtGap.Properties.BeginInit();
            base.SuspendLayout();
            this.imageList_0.ImageSize = new Size(10, 10);
            this.imageList_0.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            this.imageList_0.TransparentColor = Color.Transparent;
            this.btnBorderInfo.Appearance.BackColor = SystemColors.Window;
            this.btnBorderInfo.Appearance.ForeColor = SystemColors.ControlLightLight;
            this.btnBorderInfo.Appearance.Options.UseBackColor = true;
            this.btnBorderInfo.Appearance.Options.UseForeColor = true;
            this.btnBorderInfo.ButtonStyle = BorderStyles.Simple;
            this.btnBorderInfo.ImageIndex = 1;
            this.btnBorderInfo.ImageList = this.imageList_0;
            this.btnBorderInfo.Location = new Point(248, 41);
            this.btnBorderInfo.Name = "btnBorderInfo";
            this.btnBorderInfo.Size = new Size(16, 16);
            this.btnBorderInfo.TabIndex = 18;
            this.btnBorderSelector.Appearance.BackColor = SystemColors.Window;
            this.btnBorderSelector.Appearance.ForeColor = SystemColors.ControlLightLight;
            this.btnBorderSelector.Appearance.Options.UseBackColor = true;
            this.btnBorderSelector.Appearance.Options.UseForeColor = true;
            this.btnBorderSelector.ButtonStyle = BorderStyles.Simple;
            this.btnBorderSelector.ImageIndex = 0;
            this.btnBorderSelector.ImageList = this.imageList_0;
            this.btnBorderSelector.Location = new Point(248, 25);
            this.btnBorderSelector.Name = "btnBorderSelector";
            this.btnBorderSelector.Size = new Size(16, 16);
            this.btnBorderSelector.TabIndex = 17;
            this.cboBorder.DrawMode = DrawMode.OwnerDrawVariable;
            this.cboBorder.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboBorder.DropDownWidth = 160;
            this.cboBorder.Font = new Font("宋体", 15f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.cboBorder.Location = new Point(8, 25);
            this.cboBorder.Name = "cboBorder";
            this.cboBorder.Size = new Size(240, 31);
            this.cboBorder.TabIndex = 16;
            this.label16.AutoSize = true;
            this.label16.Location = new Point(8, 8);
            this.label16.Name = "label16";
            this.label16.Size = new Size(29, 17);
            this.label16.TabIndex = 19;
            this.label16.Text = "边框";
            this.label17.AutoSize = true;
            this.label17.Location = new Point(8, 64);
            this.label17.Name = "label17";
            this.label17.Size = new Size(29, 17);
            this.label17.TabIndex = 20;
            this.label17.Text = "背景";
            this.label18.AutoSize = true;
            this.label18.Location = new Point(8, 128);
            this.label18.Name = "label18";
            this.label18.Size = new Size(29, 17);
            this.label18.TabIndex = 21;
            this.label18.Text = "阴影";
            this.btnBackgroundInfo.Appearance.BackColor = SystemColors.Window;
            this.btnBackgroundInfo.Appearance.ForeColor = SystemColors.ControlLightLight;
            this.btnBackgroundInfo.Appearance.Options.UseBackColor = true;
            this.btnBackgroundInfo.Appearance.Options.UseForeColor = true;
            this.btnBackgroundInfo.ButtonStyle = BorderStyles.Simple;
            this.btnBackgroundInfo.ImageIndex = 1;
            this.btnBackgroundInfo.ImageList = this.imageList_0;
            this.btnBackgroundInfo.Location = new Point(248, 104);
            this.btnBackgroundInfo.Name = "btnBackgroundInfo";
            this.btnBackgroundInfo.Size = new Size(16, 16);
            this.btnBackgroundInfo.TabIndex = 24;
            this.btnBackgroundSelector.Appearance.BackColor = SystemColors.Window;
            this.btnBackgroundSelector.Appearance.ForeColor = SystemColors.ControlLightLight;
            this.btnBackgroundSelector.Appearance.Options.UseBackColor = true;
            this.btnBackgroundSelector.Appearance.Options.UseForeColor = true;
            this.btnBackgroundSelector.ButtonStyle = BorderStyles.Simple;
            this.btnBackgroundSelector.ImageIndex = 0;
            this.btnBackgroundSelector.ImageList = this.imageList_0;
            this.btnBackgroundSelector.Location = new Point(248, 88);
            this.btnBackgroundSelector.Name = "btnBackgroundSelector";
            this.btnBackgroundSelector.Size = new Size(16, 16);
            this.btnBackgroundSelector.TabIndex = 23;
            this.cboBackground.DrawMode = DrawMode.OwnerDrawVariable;
            this.cboBackground.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboBackground.DropDownWidth = 160;
            this.cboBackground.Font = new Font("宋体", 15f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.cboBackground.Location = new Point(8, 88);
            this.cboBackground.Name = "cboBackground";
            this.cboBackground.Size = new Size(240, 31);
            this.cboBackground.TabIndex = 22;
            this.btnshadowInfo.Appearance.BackColor = SystemColors.Window;
            this.btnshadowInfo.Appearance.ForeColor = SystemColors.ControlLightLight;
            this.btnshadowInfo.Appearance.Options.UseBackColor = true;
            this.btnshadowInfo.Appearance.Options.UseForeColor = true;
            this.btnshadowInfo.ButtonStyle = BorderStyles.Simple;
            this.btnshadowInfo.ImageIndex = 1;
            this.btnshadowInfo.ImageList = this.imageList_0;
            this.btnshadowInfo.Location = new Point(248, 168);
            this.btnshadowInfo.Name = "btnshadowInfo";
            this.btnshadowInfo.Size = new Size(16, 16);
            this.btnshadowInfo.TabIndex = 27;
            this.btnShadowSelector.Appearance.BackColor = SystemColors.Window;
            this.btnShadowSelector.Appearance.ForeColor = SystemColors.ControlLightLight;
            this.btnShadowSelector.Appearance.Options.UseBackColor = true;
            this.btnShadowSelector.Appearance.Options.UseForeColor = true;
            this.btnShadowSelector.ButtonStyle = BorderStyles.Simple;
            this.btnShadowSelector.ImageIndex = 0;
            this.btnShadowSelector.ImageList = this.imageList_0;
            this.btnShadowSelector.Location = new Point(248, 152);
            this.btnShadowSelector.Name = "btnShadowSelector";
            this.btnShadowSelector.Size = new Size(16, 16);
            this.btnShadowSelector.TabIndex = 26;
            this.cboShadow.DrawMode = DrawMode.OwnerDrawVariable;
            this.cboShadow.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboShadow.DropDownWidth = 160;
            this.cboShadow.Font = new Font("宋体", 15f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.cboShadow.Location = new Point(8, 152);
            this.cboShadow.Name = "cboShadow";
            this.cboShadow.Size = new Size(240, 31);
            this.cboShadow.TabIndex = 25;
            int[] bits = new int[4];
            this.txtCornerRounding.EditValue = new decimal(bits);
            this.txtCornerRounding.Location = new Point(184, 196);
            this.txtCornerRounding.Name = "txtCornerRounding";
            this.txtCornerRounding.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.txtCornerRounding.Properties.UseCtrlIncrement = false;
            this.txtCornerRounding.Size = new Size(48, 23);
            this.txtCornerRounding.TabIndex = 31;
            this.txtCornerRounding.EditValueChanged += new EventHandler(this.txtCornerRounding_EditValueChanged);
            this.label6.AutoSize = true;
            this.label6.Location = new Point(144, 200);
            this.label6.Name = "label6";
            this.label6.Size = new Size(35, 17);
            this.label6.TabIndex = 30;
            this.label6.Text = "圆角:";
            int[] bits2 = new int[4];
            bits2[0] = 10;
            this.txtGap.EditValue = new decimal(bits2);
            this.txtGap.Location = new Point(48, 196);
            this.txtGap.Name = "txtGap";
            this.txtGap.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.txtGap.Properties.UseCtrlIncrement = false;
            this.txtGap.Size = new Size(48, 23);
            this.txtGap.TabIndex = 29;
            this.txtGap.EditValueChanged += new EventHandler(this.txtGap_EditValueChanged);
            this.label9.AutoSize = true;
            this.label9.Location = new Point(8, 200);
            this.label9.Name = "label9";
            this.label9.Size = new Size(35, 17);
            this.label9.TabIndex = 28;
            this.label9.Text = "间隔:";
            base.Controls.Add(this.txtCornerRounding);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.txtGap);
            base.Controls.Add(this.label9);
            base.Controls.Add(this.btnshadowInfo);
            base.Controls.Add(this.btnShadowSelector);
            base.Controls.Add(this.cboShadow);
            base.Controls.Add(this.btnBackgroundInfo);
            base.Controls.Add(this.btnBackgroundSelector);
            base.Controls.Add(this.cboBackground);
            base.Controls.Add(this.label18);
            base.Controls.Add(this.label17);
            base.Controls.Add(this.label16);
            base.Controls.Add(this.btnBorderInfo);
            base.Controls.Add(this.btnBorderSelector);
            base.Controls.Add(this.cboBorder);
            base.Name = "LegendFrameUserControl";
            base.Size = new Size(288, 248);
            base.Load += new EventHandler(this.LegendFrameUserControl_Load);
            this.txtCornerRounding.Properties.EndInit();
            this.txtGap.Properties.EndInit();
            base.ResumeLayout(false);
        }

       
        private SimpleButton btnBackgroundInfo;
        private SimpleButton btnBackgroundSelector;
        private SimpleButton btnBorderInfo;
        private SimpleButton btnBorderSelector;
        private SimpleButton btnshadowInfo;
        private SimpleButton btnShadowSelector;
        private StyleComboBox cboBackground;
        private StyleComboBox cboBorder;
        private StyleComboBox cboShadow;
        private IContainer components;
        private ImageList imageList_0;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label6;
        private Label label9;
        private MapCartoTemplateLib.MapTemplateElement mapTemplateElement_0;
        private SpinEdit txtCornerRounding;
        private SpinEdit txtGap;
    }
}