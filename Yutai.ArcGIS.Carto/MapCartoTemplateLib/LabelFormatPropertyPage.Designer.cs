﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using Yutai.ArcGIS.Controls.SymbolUI;
using IPropertyPage = Yutai.ArcGIS.Common.BaseClasses.IPropertyPage;
using IPropertyPageEvents = Yutai.ArcGIS.Common.BaseClasses.IPropertyPageEvents;
using OnValueChangeEventHandler = Yutai.ArcGIS.Common.BaseClasses.OnValueChangeEventHandler;

namespace Yutai.ArcGIS.Carto.MapCartoTemplateLib
{
    partial class LabelFormatPropertyPage
    {
        protected override void Dispose(bool bool_2)
        {
            if (bool_2 && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(bool_2);
        }

       
        private void InitializeComponent()
        {
            this.components = new Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapCartoTemplateLib.LabelFormatPropertyPage));
            this.groupBox3 = new GroupBox();
            this.chkverticalRight = new CheckBox();
            this.chkverticalBottom = new CheckBox();
            this.chkverticalLeft = new CheckBox();
            this.chkverticalTop = new CheckBox();
            this.label10 = new Label();
            this.groupBox2 = new GroupBox();
            this.btnProperty = new Button();
            this.label4 = new Label();
            this.label3 = new Label();
            this.label2 = new Label();
            this.label1 = new Label();
            this.cboFontSize = new System.Windows.Forms.ComboBox();
            this.colorEdit1 = new ColorEdit();
            this.chkUnderLine = new CheckBox();
            this.imageList_0 = new ImageList(this.components);
            this.chkIta = new CheckBox();
            this.chkBold = new CheckBox();
            this.cboFontName = new System.Windows.Forms.ComboBox();
            this.cboFormat = new System.Windows.Forms.ComboBox();
            this.label9 = new Label();
            this.chkLabelRight = new CheckBox();
            this.chkLabelBottom = new CheckBox();
            this.chkLabelLeft = new CheckBox();
            this.chkLabelTop = new CheckBox();
            this.groupBox1 = new GroupBox();
            this.txtLabelOffset = new DomainUpDown();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.colorEdit1.Properties.BeginInit();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.groupBox3.Controls.Add(this.chkverticalRight);
            this.groupBox3.Controls.Add(this.chkverticalBottom);
            this.groupBox3.Controls.Add(this.chkverticalLeft);
            this.groupBox3.Controls.Add(this.chkverticalTop);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new Point(130, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(150, 66);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "边框属性";
            this.chkverticalRight.Location = new Point(104, 42);
            this.chkverticalRight.Name = "chkverticalRight";
            this.chkverticalRight.Size = new Size(48, 19);
            this.chkverticalRight.TabIndex = 16;
            this.chkverticalRight.Text = "右";
            this.chkverticalRight.CheckedChanged += new EventHandler(this.chkLabelTop_CheckedChanged);
            this.chkverticalBottom.Location = new Point(62, 42);
            this.chkverticalBottom.Name = "chkverticalBottom";
            this.chkverticalBottom.Size = new Size(48, 19);
            this.chkverticalBottom.TabIndex = 15;
            this.chkverticalBottom.Text = "下";
            this.chkverticalBottom.CheckedChanged += new EventHandler(this.chkverticalBottom_CheckedChanged);
            this.chkverticalLeft.Location = new Point(104, 17);
            this.chkverticalLeft.Name = "chkverticalLeft";
            this.chkverticalLeft.Size = new Size(48, 19);
            this.chkverticalLeft.TabIndex = 14;
            this.chkverticalLeft.Text = "左";
            this.chkverticalLeft.CheckedChanged += new EventHandler(this.chkLabelTop_CheckedChanged);
            this.chkverticalTop.Location = new Point(62, 17);
            this.chkverticalTop.Name = "chkverticalTop";
            this.chkverticalTop.Size = new Size(48, 19);
            this.chkverticalTop.TabIndex = 13;
            this.chkverticalTop.Text = "上";
            this.chkverticalTop.CheckedChanged += new EventHandler(this.chkLabelTop_CheckedChanged);
            this.label10.AutoSize = true;
            this.label10.Location = new Point(6, 17);
            this.label10.Name = "label10";
            this.label10.Size = new Size(53, 12);
            this.label10.TabIndex = 12;
            this.label10.Text = "垂直标注";
            this.groupBox2.Controls.Add(this.txtLabelOffset);
            this.groupBox2.Controls.Add(this.btnProperty);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cboFontSize);
            this.groupBox2.Controls.Add(this.colorEdit1);
            this.groupBox2.Controls.Add(this.chkUnderLine);
            this.groupBox2.Controls.Add(this.chkIta);
            this.groupBox2.Controls.Add(this.chkBold);
            this.groupBox2.Controls.Add(this.cboFontName);
            this.groupBox2.Controls.Add(this.cboFormat);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new Point(8, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(272, 168);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "标注样式";
            this.btnProperty.Location = new Point(40, 136);
            this.btnProperty.Name = "btnProperty";
            this.btnProperty.Size = new Size(88, 24);
            this.btnProperty.TabIndex = 32;
            this.btnProperty.Text = "附加属性";
            this.btnProperty.Click += new EventHandler(this.btnProperty_Click);
            this.label4.AutoSize = true;
            this.label4.Location = new Point(8, 72);
            this.label4.Name = "label4";
            this.label4.Size = new Size(35, 12);
            this.label4.TabIndex = 30;
            this.label4.Text = "大小:";
            this.label3.AutoSize = true;
            this.label3.Location = new Point(120, 112);
            this.label3.Name = "label3";
            this.label3.Size = new Size(59, 12);
            this.label3.TabIndex = 29;
            this.label3.Text = "标注偏移:";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(8, 104);
            this.label2.Name = "label2";
            this.label2.Size = new Size(35, 12);
            this.label2.TabIndex = 28;
            this.label2.Text = "颜色:";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(8, 48);
            this.label1.Name = "label1";
            this.label1.Size = new Size(35, 12);
            this.label1.TabIndex = 27;
            this.label1.Text = "字体:";
            this.cboFontSize.Text = "5";
            this.cboFontSize.Location = new Point(48, 72);
            this.cboFontSize.Name = "cboFontSize";
            this.cboFontSize.Items.AddRange(new object[] { 
                "5", "6", "7", "8", "9", "10", "11", "12", "14", "16", "18", "20", "22", "24", "26", "28", 
                "34", "36", "48", "72"
             });
            this.cboFontSize.Size = new Size(64, 21);
            this.cboFontSize.TabIndex = 26;
            this.cboFontSize.SelectedIndexChanged += new EventHandler(this.cboFontSize_SelectedIndexChanged);
            this.colorEdit1.EditValue = Color.Empty;
            this.colorEdit1.Location = new Point(48, 104);
            this.colorEdit1.Name = "colorEdit1";
            this.colorEdit1.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.colorEdit1.Size = new Size(48, 21);
            this.colorEdit1.TabIndex = 25;
            this.colorEdit1.EditValueChanged += new EventHandler(this.colorEdit1_EditValueChanged);
            this.chkUnderLine.Appearance = Appearance.Button;
            this.chkUnderLine.ImageIndex = 2;
            this.chkUnderLine.ImageList = this.imageList_0;
            this.chkUnderLine.Location = new Point(216, 72);
            this.chkUnderLine.Name = "chkUnderLine";
            this.chkUnderLine.Size = new Size(28, 24);
            this.chkUnderLine.TabIndex = 24;
            this.chkUnderLine.CheckedChanged += new EventHandler(this.chkBold_CheckedChanged);
            this.imageList_0.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            this.imageList_0.TransparentColor = Color.Magenta;
            this.imageList_0.Images.SetKeyName(0, "");
            this.imageList_0.Images.SetKeyName(1, "");
            this.imageList_0.Images.SetKeyName(2, "");
            this.imageList_0.Images.SetKeyName(3, "");
            this.imageList_0.Images.SetKeyName(4, "");
            this.imageList_0.Images.SetKeyName(5, "");
            this.imageList_0.Images.SetKeyName(6, "");
            this.chkIta.Appearance = Appearance.Button;
            this.chkIta.ImageIndex = 1;
            this.chkIta.ImageList = this.imageList_0;
            this.chkIta.Location = new Point(184, 72);
            this.chkIta.Name = "chkIta";
            this.chkIta.Size = new Size(28, 24);
            this.chkIta.TabIndex = 23;
            this.chkIta.CheckedChanged += new EventHandler(this.chkBold_CheckedChanged);
            this.chkBold.Appearance = Appearance.Button;
            this.chkBold.ImageIndex = 0;
            this.chkBold.ImageList = this.imageList_0;
            this.chkBold.Location = new Point(152, 72);
            this.chkBold.Name = "chkBold";
            this.chkBold.Size = new Size(28, 24);
            this.chkBold.TabIndex = 22;
            this.chkBold.CheckedChanged += new EventHandler(this.chkBold_CheckedChanged);
            this.cboFontName.Location = new Point(48, 48);
            this.cboFontName.Name = "cboFontName";
            this.cboFontName.Size = new Size(184, 20);
            this.cboFontName.TabIndex = 21;
            this.cboFontName.SelectedIndexChanged += new EventHandler(this.cboFontName_SelectedIndexChanged);
            this.cboFormat.Text = "格式化";
            this.cboFormat.Location = new Point(48, 16);
            this.cboFormat.Name = "cboFormat";
            this.cboFormat.Items.AddRange(new object[] { "格式化", "混合字体", "角标注" });
            this.cboFormat.Size = new Size(128, 21);
            this.cboFormat.TabIndex = 20;
            this.cboFormat.SelectedIndexChanged += new EventHandler(this.cboFormat_SelectedIndexChanged);
            this.label9.AutoSize = true;
            this.label9.Location = new Point(8, 24);
            this.label9.Name = "label9";
            this.label9.Size = new Size(35, 12);
            this.label9.TabIndex = 18;
            this.label9.Text = "格式:";
            this.chkLabelRight.Location = new Point(48, 41);
            this.chkLabelRight.Name = "chkLabelRight";
            this.chkLabelRight.Size = new Size(48, 19);
            this.chkLabelRight.TabIndex = 3;
            this.chkLabelRight.Text = "右";
            this.chkLabelRight.CheckedChanged += new EventHandler(this.chkLabelTop_CheckedChanged);
            this.chkLabelBottom.Location = new Point(6, 41);
            this.chkLabelBottom.Name = "chkLabelBottom";
            this.chkLabelBottom.Size = new Size(48, 19);
            this.chkLabelBottom.TabIndex = 2;
            this.chkLabelBottom.Text = "下";
            this.chkLabelBottom.CheckedChanged += new EventHandler(this.chkLabelTop_CheckedChanged);
            this.chkLabelLeft.Location = new Point(48, 20);
            this.chkLabelLeft.Name = "chkLabelLeft";
            this.chkLabelLeft.Size = new Size(48, 19);
            this.chkLabelLeft.TabIndex = 1;
            this.chkLabelLeft.Text = "左";
            this.chkLabelLeft.CheckedChanged += new EventHandler(this.chkLabelTop_CheckedChanged);
            this.chkLabelTop.Location = new Point(8, 20);
            this.chkLabelTop.Name = "chkLabelTop";
            this.chkLabelTop.Size = new Size(48, 19);
            this.chkLabelTop.TabIndex = 0;
            this.chkLabelTop.Text = "上";
            this.chkLabelTop.CheckedChanged += new EventHandler(this.chkLabelTop_CheckedChanged);
            this.groupBox1.Controls.Add(this.chkLabelRight);
            this.groupBox1.Controls.Add(this.chkLabelBottom);
            this.groupBox1.Controls.Add(this.chkLabelLeft);
            this.groupBox1.Controls.Add(this.chkLabelTop);
            this.groupBox1.Location = new Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(112, 66);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "标注轴";
            this.txtLabelOffset.Location = new Point(185, 108);
            this.txtLabelOffset.Name = "txtLabelOffset";
            this.txtLabelOffset.Size = new Size(47, 21);
            this.txtLabelOffset.TabIndex = 33;
            this.txtLabelOffset.Text = "0";
            base.Controls.Add(this.groupBox3);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox1);
            base.Name = "LabelFormatPropertyPage";
            base.Size = new Size(306, 260);
            base.Load += new EventHandler(this.LabelFormatPropertyPage_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.colorEdit1.Properties.EndInit();
            this.groupBox1.ResumeLayout(false);
            base.ResumeLayout(false);
        }

       
        private Button btnProperty;
        private System.Windows.Forms.ComboBox cboFontName;
        private System.Windows.Forms.ComboBox cboFontSize;
        private System.Windows.Forms.ComboBox cboFormat;
        private CheckBox chkBold;
        private CheckBox chkIta;
        private CheckBox chkLabelBottom;
        private CheckBox chkLabelLeft;
        private CheckBox chkLabelRight;
        private CheckBox chkLabelTop;
        private CheckBox chkUnderLine;
        private CheckBox chkverticalBottom;
        private CheckBox chkverticalLeft;
        private CheckBox chkverticalRight;
        private CheckBox chkverticalTop;
        private ColorEdit colorEdit1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private IContainer components;
        private ImageList imageList_0;
        private Label label1;
        private Label label10;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label9;
        private MapCartoTemplateLib.MapTemplate mapTemplate_0;
        private DomainUpDown txtLabelOffset;
    }
}