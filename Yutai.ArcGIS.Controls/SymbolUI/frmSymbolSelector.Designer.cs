﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using Yutai.ArcGIS.Common.AELicenseProvider;
using Yutai.ArcGIS.Common.Symbol;
using Yutai.ArcGIS.Common.SymbolLib;
using Yutai.Shared;

namespace Yutai.ArcGIS.Controls.SymbolUI
{
  //  [LicenseProvider(typeof(AELicenseProviderEx)), Guid("E8A66E3D-33F6-42e4-84AE-701A02ACF4D1")]
    partial class frmSymbolSelector
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.components != null)
                {
                    this.components.Dispose();
                }
                this.m_pSG = null;
            }
            base.Dispose(disposing);
        }

       
        private void InitializeComponent()
        {
            this.components = new Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSymbolSelector));
            this.groupBox1 = new GroupBox();
            this.symbolItem1 = new SymbolItem();
            this.symbolListView1 = new SymbolListViewEx();
            this.StyleSetManagerMenu = new ContextMenu();
            this.menuItemAddStyleSet1 = new MenuItem();
            this.groupBoxFill = new GroupBox();
            this.colorEditOutline = new ColorEdit();
            this.label2 = new Label();
            this.label1 = new Label();
            this.colorEditFill = new ColorEdit();
            this.groupBoxLine = new GroupBox();
            this.spinEditWidth = new SpinEdit();
            this.label3 = new Label();
            this.label4 = new Label();
            this.colorEditLine = new ColorEdit();
            this.groupBoxMarker = new GroupBox();
            this.spinEditSize = new SpinEdit();
            this.label5 = new Label();
            this.label6 = new Label();
            this.colorEditMarker = new ColorEdit();
            this.barManager1 = new BarManager(this.components);
            this.barAndDockingController1 = new BarAndDockingController(this.components);
            this.barDockControlTop = new BarDockControl();
            this.barDockControlBottom = new BarDockControl();
            this.barDockControlLeft = new BarDockControl();
            this.barDockControlRight = new BarDockControl();
            this.menuItemAddStyleSet = new BarButtonItem();
            this.popupMenu1 = new PopupMenu(this.components);
            this.btnProperty = new SimpleButton();
            this.btnMoreSymbol = new SimpleButton();
            this.btnOK = new SimpleButton();
            this.btnCancel = new SimpleButton();
            this.comboBoxEdit = new ComboBoxEdit();
            this.label7 = new Label();
            this.groupBox1.SuspendLayout();
            this.groupBoxFill.SuspendLayout();
            this.colorEditOutline.Properties.BeginInit();
            this.colorEditFill.Properties.BeginInit();
            this.groupBoxLine.SuspendLayout();
            this.spinEditWidth.Properties.BeginInit();
            this.colorEditLine.Properties.BeginInit();
            this.groupBoxMarker.SuspendLayout();
            this.spinEditSize.Properties.BeginInit();
            this.colorEditMarker.Properties.BeginInit();
            this.barManager1.BeginInit();
            this.barAndDockingController1.BeginInit();
            this.popupMenu1.BeginInit();
            this.comboBoxEdit.Properties.BeginInit();
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.symbolItem1);
            this.groupBox1.Location = new Point(310, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(168, 120);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "预览";
            this.symbolItem1.BackColor = SystemColors.ControlLight;
            this.symbolItem1.Location = new Point(16, 24);
            this.symbolItem1.Name = "symbolItem1";
            this.symbolItem1.Size = new Size(144, 88);
            this.symbolItem1.Symbol = null;
            this.symbolItem1.TabIndex = 0;
            this.symbolListView1.BackColor = SystemColors.Window;
            this.symbolListView1.CanEditLabel = false;
            this.symbolListView1.Location = new Point(2, 48);
            this.symbolListView1.Name = "symbolListView1";
            this.symbolListView1.Size = new Size(303, 368);
            this.symbolListView1.TabIndex = 0;
            this.symbolListView1.UseCompatibleStateImageBehavior = false;
            this.symbolListView1.SelectedIndexChanged += new EventHandler(this.symbolListView1_SelectedIndexChanged);
            this.StyleSetManagerMenu.MenuItems.AddRange(new MenuItem[] { this.menuItemAddStyleSet1 });
            this.menuItemAddStyleSet1.Index = 0;
            this.menuItemAddStyleSet1.Text = "添加";
            this.menuItemAddStyleSet1.Click += new EventHandler(this.menuItemAddStyleSet1_Click);
            this.groupBoxFill.Controls.Add(this.colorEditOutline);
            this.groupBoxFill.Controls.Add(this.label2);
            this.groupBoxFill.Controls.Add(this.label1);
            this.groupBoxFill.Controls.Add(this.colorEditFill);
            this.groupBoxFill.Location = new Point(310, 144);
            this.groupBoxFill.Name = "groupBoxFill";
            this.groupBoxFill.Size = new Size(168, 88);
            this.groupBoxFill.TabIndex = 6;
            this.groupBoxFill.TabStop = false;
            this.groupBoxFill.Text = "选项";
            this.groupBoxFill.Visible = false;
            this.colorEditOutline.EditValue = Color.Empty;
            this.colorEditOutline.Location = new Point(72, 56);
            this.colorEditOutline.Name = "colorEditOutline";
            this.colorEditOutline.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.colorEditOutline.Size = new Size(48, 21);
            this.colorEditOutline.TabIndex = 3;
            this.colorEditOutline.EditValueChanged += new EventHandler(this.colorEditOutline_EditValueChanged);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(8, 56);
            this.label2.Name = "label2";
            this.label2.Size = new Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "轮廓线色";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "填充色";
            this.colorEditFill.EditValue = Color.Empty;
            this.colorEditFill.Location = new Point(72, 24);
            this.colorEditFill.Name = "colorEditFill";
            this.colorEditFill.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.colorEditFill.Size = new Size(48, 21);
            this.colorEditFill.TabIndex = 0;
            this.colorEditFill.EditValueChanged += new EventHandler(this.colorEditFill_EditValueChanged);
            this.groupBoxLine.Controls.Add(this.spinEditWidth);
            this.groupBoxLine.Controls.Add(this.label3);
            this.groupBoxLine.Controls.Add(this.label4);
            this.groupBoxLine.Controls.Add(this.colorEditLine);
            this.groupBoxLine.Location = new Point(311, 144);
            this.groupBoxLine.Name = "groupBoxLine";
            this.groupBoxLine.Size = new Size(168, 88);
            this.groupBoxLine.TabIndex = 7;
            this.groupBoxLine.TabStop = false;
            this.groupBoxLine.Text = "选项";
            this.groupBoxLine.Visible = false;
            this.spinEditWidth.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditWidth.Location = new Point(48, 56);
            this.spinEditWidth.Name = "spinEditWidth";
            this.spinEditWidth.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.spinEditWidth.Properties.DisplayFormat.FormatString = "0.####";
            this.spinEditWidth.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.spinEditWidth.Properties.EditFormat.FormatString = "0.####";
            this.spinEditWidth.Properties.EditFormat.FormatType = FormatType.Numeric;
            this.spinEditWidth.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spinEditWidth.Size = new Size(75, 21);
            this.spinEditWidth.TabIndex = 3;
            this.spinEditWidth.EditValueChanged += new EventHandler(this.spinEditWidth_EditValueChanged);
            this.label3.AutoSize = true;
            this.label3.Location = new Point(8, 56);
            this.label3.Name = "label3";
            this.label3.Size = new Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "宽度";
            this.label4.AutoSize = true;
            this.label4.Location = new Point(8, 24);
            this.label4.Name = "label4";
            this.label4.Size = new Size(29, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "颜色";
            this.colorEditLine.EditValue = Color.Empty;
            this.colorEditLine.Location = new Point(48, 24);
            this.colorEditLine.Name = "colorEditLine";
            this.colorEditLine.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.colorEditLine.Size = new Size(48, 21);
            this.colorEditLine.TabIndex = 0;
            this.colorEditLine.EditValueChanged += new EventHandler(this.colorEditLine_EditValueChanged);
            this.groupBoxMarker.Controls.Add(this.spinEditSize);
            this.groupBoxMarker.Controls.Add(this.label5);
            this.groupBoxMarker.Controls.Add(this.label6);
            this.groupBoxMarker.Controls.Add(this.colorEditMarker);
            this.groupBoxMarker.Location = new Point(310, 144);
            this.groupBoxMarker.Name = "groupBoxMarker";
            this.groupBoxMarker.Size = new Size(168, 88);
            this.groupBoxMarker.TabIndex = 8;
            this.groupBoxMarker.TabStop = false;
            this.groupBoxMarker.Text = "选项";
            this.groupBoxMarker.Visible = false;
            this.spinEditSize.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditSize.Location = new Point(48, 56);
            this.spinEditSize.Name = "spinEditSize";
            this.spinEditSize.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.spinEditSize.Properties.DisplayFormat.FormatString = "0.####";
            this.spinEditSize.Properties.DisplayFormat.FormatType = FormatType.Numeric;
            this.spinEditSize.Properties.EditFormat.FormatString = "0.####";
            this.spinEditSize.Properties.EditFormat.FormatType = FormatType.Numeric;
            this.spinEditSize.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spinEditSize.Size = new Size(75, 21);
            this.spinEditSize.TabIndex = 3;
            this.spinEditSize.EditValueChanged += new EventHandler(this.spinEditSize_EditValueChanged);
            this.label5.AutoSize = true;
            this.label5.Location = new Point(8, 56);
            this.label5.Name = "label5";
            this.label5.Size = new Size(29, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "大小";
            this.label6.AutoSize = true;
            this.label6.Location = new Point(8, 24);
            this.label6.Name = "label6";
            this.label6.Size = new Size(29, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "颜色";
            this.colorEditMarker.EditValue = Color.Empty;
            this.colorEditMarker.Location = new Point(48, 24);
            this.colorEditMarker.Name = "colorEditMarker";
            this.colorEditMarker.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.colorEditMarker.Size = new Size(48, 21);
            this.colorEditMarker.TabIndex = 0;
            this.colorEditMarker.EditValueChanged += new EventHandler(this.colorEditMarker_EditValueChanged);
            this.barManager1.Controller = this.barAndDockingController1;
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new BarItem[] { this.menuItemAddStyleSet });
            this.barManager1.MaxItemId = 1;
            this.barAndDockingController1.PaintStyleName = "Skin";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            this.menuItemAddStyleSet.Caption = "添加";
            this.menuItemAddStyleSet.Id = 0;
            this.menuItemAddStyleSet.Name = "menuItemAddStyleSet";
            this.menuItemAddStyleSet.ItemClick += new ItemClickEventHandler(this.menuItemAddStyleSet_ItemClick);
            this.popupMenu1.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.menuItemAddStyleSet) });
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            this.btnProperty.Location = new Point(320, 304);
            this.btnProperty.Name = "btnProperty";
            this.btnProperty.Size = new Size(128, 24);
            this.btnProperty.TabIndex = 13;
            this.btnProperty.Text = "属性...";
            this.btnProperty.Click += new EventHandler(this.btnProperty_Click);
            this.btnMoreSymbol.Location = new Point(320, 344);
            this.btnMoreSymbol.Name = "btnMoreSymbol";
            this.btnMoreSymbol.Size = new Size(128, 24);
            this.btnMoreSymbol.TabIndex = 14;
            this.btnMoreSymbol.Text = "更多符号...";
            this.btnMoreSymbol.Click += new EventHandler(this.btnMoreSymbol_Click);
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new Point(320, 384);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(56, 24);
            this.btnOK.TabIndex = 15;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new EventHandler(this.btnOK_Click);
            this.btnCancel.Location = new Point(392, 384);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(56, 24);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.comboBoxEdit.EditValue = "";
            this.comboBoxEdit.Location = new Point(56, 8);
            this.comboBoxEdit.Name = "comboBoxEdit";
            this.comboBoxEdit.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.comboBoxEdit.Size = new Size(224, 21);
            this.comboBoxEdit.TabIndex = 17;
            this.comboBoxEdit.SelectedIndexChanged += new EventHandler(this.comboBoxEdit_SelectedIndexChanged);
            this.label7.AutoSize = true;
            this.label7.Location = new Point(16, 13);
            this.label7.Name = "label7";
            this.label7.Size = new Size(35, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "类别:";
            this.AutoScaleBaseSize = new Size(6, 14);
            base.ClientSize = new Size(482, 423);
            base.Controls.Add(this.label7);
            base.Controls.Add(this.comboBoxEdit);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnOK);
            base.Controls.Add(this.btnMoreSymbol);
            base.Controls.Add(this.btnProperty);
            base.Controls.Add(this.groupBoxMarker);
            base.Controls.Add(this.groupBoxLine);
            base.Controls.Add(this.groupBoxFill);
            base.Controls.Add(this.symbolListView1);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.barDockControlLeft);
            base.Controls.Add(this.barDockControlRight);
            base.Controls.Add(this.barDockControlBottom);
            base.Controls.Add(this.barDockControlTop);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmSymbolSelector";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "符号选择器";
            base.Load += new EventHandler(this.frmSymbolSelector_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBoxFill.ResumeLayout(false);
            this.groupBoxFill.PerformLayout();
            this.colorEditOutline.Properties.EndInit();
            this.colorEditFill.Properties.EndInit();
            this.groupBoxLine.ResumeLayout(false);
            this.groupBoxLine.PerformLayout();
            this.spinEditWidth.Properties.EndInit();
            this.colorEditLine.Properties.EndInit();
            this.groupBoxMarker.ResumeLayout(false);
            this.groupBoxMarker.PerformLayout();
            this.spinEditSize.Properties.EndInit();
            this.colorEditMarker.Properties.EndInit();
            this.barManager1.EndInit();
            this.barAndDockingController1.EndInit();
            this.popupMenu1.EndInit();
            this.comboBoxEdit.Properties.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private BarAndDockingController barAndDockingController1;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private BarDockControl barDockControlTop;
        private BarManager barManager1;
        private SimpleButton btnCancel;
        private SimpleButton btnMoreSymbol;
        private SimpleButton btnOK;
        private SimpleButton btnProperty;
        private ColorEdit colorEditFill;
        private ColorEdit colorEditLine;
        private ColorEdit colorEditMarker;
        private ColorEdit colorEditOutline;
        private ComboBoxEdit comboBoxEdit;
        private GroupBox groupBox1;
        private GroupBox groupBoxFill;
        private GroupBox groupBoxLine;
        private GroupBox groupBoxMarker;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private BarButtonItem menuItemAddStyleSet;
        private MenuItem menuItemAddStyleSet1;
        private PopupMenu popupMenu1;
        private SpinEdit spinEditSize;
        private SpinEdit spinEditWidth;
        private ContextMenu StyleSetManagerMenu;
        private SymbolItem symbolItem1;
        private SymbolListViewEx symbolListView1;
    }
}