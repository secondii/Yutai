﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Output;

namespace Yutai.ArcGIS.Carto.UI
{
    partial class FormPrinterSetup
    {
        private Container components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrinterSetup));
            this.panel1 = new Panel();
            this.groupBox1 = new GroupBox();
            this.cboPageToPrinterMapping = new ComboBox();
            this.Label8 = new Label();
            this.checkBox_usePrinterPageSize = new CheckBox();
            this.groupBox2 = new GroupBox();
            this.label11 = new Label();
            this.optLandscape = new RadioButton();
            this.optPortrait = new RadioButton();
            this.lblInfo = new Label();
            this.label10 = new Label();
            this.label9 = new Label();
            this.txtPageHeight = new TextBox();
            this.label7 = new Label();
            this.txtPageWidth = new TextBox();
            this.label4 = new Label();
            this.cboPageSize = new ComboBox();
            this.fraPrint = new GroupBox();
            this.txbOverlap = new TextBox();
            this.Label2 = new Label();
            this.textBox_copied = new TextBox();
            this.lblPageCount = new Label();
            this.label_copied = new Label();
            this.txbStartPage = new TextBox();
            this.txbEndPage = new TextBox();
            this.Label5 = new Label();
            this.Label1 = new Label();
            this.fraPrinter = new GroupBox();
            this.button_printerAttribute = new Button();
            this.comboBox_printer = new ComboBox();
            this.lblPrinterOrientation = new Label();
            this.lblPrinterName = new Label();
            this.lblPrinterSize = new Label();
            this.frmPaper = new GroupBox();
            this.cboPaperTrays = new ComboBox();
            this.label12 = new Label();
            this.optPaperLandscape = new RadioButton();
            this.label13 = new Label();
            this.optPaperPortrait = new RadioButton();
            this.cboPrinterPageSize = new ComboBox();
            this.label3 = new Label();
            this.printDialog_0 = new PrintDialog();
            this.cmdPrint = new Button();
            this.cmdCancel = new Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.fraPrint.SuspendLayout();
            this.fraPrinter.SuspendLayout();
            this.frmPaper.SuspendLayout();
            base.SuspendLayout();
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.fraPrint);
            this.panel1.Controls.Add(this.fraPrinter);
            this.panel1.Controls.Add(this.frmPaper);
            this.panel1.Location = new Point(5, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(522, 405);
            this.panel1.TabIndex = 23;
            this.groupBox1.Controls.Add(this.cboPageToPrinterMapping);
            this.groupBox1.Controls.Add(this.Label8);
            this.groupBox1.Controls.Add(this.checkBox_usePrinterPageSize);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new Point(11, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(276, 240);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "地图页面尺寸";
            this.cboPageToPrinterMapping.BackColor = SystemColors.Window;
            this.cboPageToPrinterMapping.Cursor = Cursors.Default;
            this.cboPageToPrinterMapping.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboPageToPrinterMapping.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.cboPageToPrinterMapping.ForeColor = SystemColors.WindowText;
            this.cboPageToPrinterMapping.Location = new Point(131, 205);
            this.cboPageToPrinterMapping.Name = "cboPageToPrinterMapping";
            this.cboPageToPrinterMapping.RightToLeft = RightToLeft.No;
            this.cboPageToPrinterMapping.Size = new Size(135, 22);
            this.cboPageToPrinterMapping.TabIndex = 30;
            this.cboPageToPrinterMapping.SelectedIndexChanged += new EventHandler(this.cboPageToPrinterMapping_SelectedIndexChanged);
            this.Label8.AutoSize = true;
            this.Label8.BackColor = SystemColors.Control;
            this.Label8.Cursor = Cursors.Default;
            this.Label8.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Label8.ForeColor = SystemColors.ControlText;
            this.Label8.Location = new Point(9, 207);
            this.Label8.Name = "Label8";
            this.Label8.RightToLeft = RightToLeft.No;
            this.Label8.Size = new Size(118, 14);
            this.Label8.TabIndex = 29;
            this.Label8.Text = "页面到纸张映射模式:";
            this.checkBox_usePrinterPageSize.Checked = true;
            this.checkBox_usePrinterPageSize.CheckState = CheckState.Checked;
            this.checkBox_usePrinterPageSize.Location = new Point(12, 25);
            this.checkBox_usePrinterPageSize.Name = "checkBox_usePrinterPageSize";
            this.checkBox_usePrinterPageSize.Size = new Size(137, 19);
            this.checkBox_usePrinterPageSize.TabIndex = 28;
            this.checkBox_usePrinterPageSize.Text = "使用打印机纸张设置";
            this.checkBox_usePrinterPageSize.Click += new EventHandler(this.checkBox_usePrinterPageSize_Click);
            this.checkBox_usePrinterPageSize.CheckedChanged += new EventHandler(this.checkBox_usePrinterPageSize_CheckedChanged);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.optLandscape);
            this.groupBox2.Controls.Add(this.optPortrait);
            this.groupBox2.Controls.Add(this.lblInfo);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtPageHeight);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtPageWidth);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cboPageSize);
            this.groupBox2.Location = new Point(10, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(254, 141);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "页面";
            this.label11.AutoSize = true;
            this.label11.BackColor = SystemColors.Control;
            this.label11.Cursor = Cursors.Default;
            this.label11.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label11.ForeColor = SystemColors.ControlText;
            this.label11.Location = new Point(10, 109);
            this.label11.Name = "label11";
            this.label11.RightToLeft = RightToLeft.No;
            this.label11.Size = new Size(34, 14);
            this.label11.TabIndex = 41;
            this.label11.Text = "方向:";
            this.optLandscape.BackColor = SystemColors.Control;
            this.optLandscape.Cursor = Cursors.Default;
            this.optLandscape.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.optLandscape.ForeColor = SystemColors.ControlText;
            this.optLandscape.Location = new Point(155, 105);
            this.optLandscape.Name = "optLandscape";
            this.optLandscape.RightToLeft = RightToLeft.No;
            this.optLandscape.Size = new Size(50, 23);
            this.optLandscape.TabIndex = 40;
            this.optLandscape.TabStop = true;
            this.optLandscape.Text = "垂直";
            this.optLandscape.UseVisualStyleBackColor = false;
            this.optLandscape.Click += new EventHandler(this.optLandscape_Click);
            this.optPortrait.BackColor = SystemColors.Control;
            this.optPortrait.Cursor = Cursors.Default;
            this.optPortrait.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.optPortrait.ForeColor = SystemColors.ControlText;
            this.optPortrait.Location = new Point(79, 105);
            this.optPortrait.Name = "optPortrait";
            this.optPortrait.RightToLeft = RightToLeft.No;
            this.optPortrait.Size = new Size(50, 23);
            this.optPortrait.TabIndex = 39;
            this.optPortrait.TabStop = true;
            this.optPortrait.Text = "水平";
            this.optPortrait.UseVisualStyleBackColor = false;
            this.optPortrait.Click += new EventHandler(this.optPortrait_Click);
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = SystemColors.Control;
            this.lblInfo.Cursor = Cursors.Default;
            this.lblInfo.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblInfo.ForeColor = SystemColors.ControlText;
            this.lblInfo.Location = new Point(11, 21);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.RightToLeft = RightToLeft.No;
            this.lblInfo.Size = new Size(58, 14);
            this.lblInfo.TabIndex = 38;
            this.lblInfo.Text = "标准尺寸:";
            this.label10.AutoSize = true;
            this.label10.Location = new Point(212, 47);
            this.label10.Name = "label10";
            this.label10.Size = new Size(29, 12);
            this.label10.TabIndex = 37;
            this.label10.Text = "厘米";
            this.label9.AutoSize = true;
            this.label9.Location = new Point(212, 76);
            this.label9.Name = "label9";
            this.label9.Size = new Size(29, 12);
            this.label9.TabIndex = 36;
            this.label9.Text = "厘米";
            this.txtPageHeight.Location = new Point(73, 73);
            this.txtPageHeight.Name = "txtPageHeight";
            this.txtPageHeight.Size = new Size(135, 21);
            this.txtPageHeight.TabIndex = 35;
            this.txtPageHeight.TextChanged += new EventHandler(this.txtPageHeight_TextChanged);
            this.label7.AutoSize = true;
            this.label7.Location = new Point(11, 76);
            this.label7.Name = "label7";
            this.label7.Size = new Size(23, 12);
            this.label7.TabIndex = 34;
            this.label7.Text = "高:";
            this.txtPageWidth.Location = new Point(73, 45);
            this.txtPageWidth.Name = "txtPageWidth";
            this.txtPageWidth.Size = new Size(135, 21);
            this.txtPageWidth.TabIndex = 33;
            this.txtPageWidth.TextChanged += new EventHandler(this.txtPageWidth_TextChanged);
            this.label4.AutoSize = true;
            this.label4.Location = new Point(11, 47);
            this.label4.Name = "label4";
            this.label4.Size = new Size(23, 12);
            this.label4.TabIndex = 32;
            this.label4.Text = "宽:";
            this.cboPageSize.BackColor = SystemColors.Window;
            this.cboPageSize.Cursor = Cursors.Default;
            this.cboPageSize.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboPageSize.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.cboPageSize.ForeColor = SystemColors.WindowText;
            this.cboPageSize.Location = new Point(73, 17);
            this.cboPageSize.Name = "cboPageSize";
            this.cboPageSize.RightToLeft = RightToLeft.No;
            this.cboPageSize.Size = new Size(169, 22);
            this.cboPageSize.TabIndex = 31;
            this.cboPageSize.SelectedIndexChanged += new EventHandler(this.cboPageSize_SelectedIndexChanged);
            this.fraPrint.BackColor = SystemColors.Control;
            this.fraPrint.Controls.Add(this.txbOverlap);
            this.fraPrint.Controls.Add(this.Label2);
            this.fraPrint.Controls.Add(this.textBox_copied);
            this.fraPrint.Controls.Add(this.lblPageCount);
            this.fraPrint.Controls.Add(this.label_copied);
            this.fraPrint.Controls.Add(this.txbStartPage);
            this.fraPrint.Controls.Add(this.txbEndPage);
            this.fraPrint.Controls.Add(this.Label5);
            this.fraPrint.Controls.Add(this.Label1);
            this.fraPrint.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.fraPrint.ForeColor = SystemColors.ControlText;
            this.fraPrint.Location = new Point(291, 254);
            this.fraPrint.Name = "fraPrint";
            this.fraPrint.RightToLeft = RightToLeft.No;
            this.fraPrint.Size = new Size(220, 140);
            this.fraPrint.TabIndex = 25;
            this.fraPrint.TabStop = false;
            this.fraPrint.Text = "打印页设置";
            this.txbOverlap.AcceptsReturn = true;
            this.txbOverlap.BackColor = SystemColors.Window;
            this.txbOverlap.Cursor = Cursors.IBeam;
            this.txbOverlap.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txbOverlap.ForeColor = SystemColors.WindowText;
            this.txbOverlap.Location = new Point(85, 113);
            this.txbOverlap.MaxLength = 0;
            this.txbOverlap.Name = "txbOverlap";
            this.txbOverlap.RightToLeft = RightToLeft.No;
            this.txbOverlap.Size = new Size(122, 20);
            this.txbOverlap.TabIndex = 26;
            this.txbOverlap.Text = "0";
            this.txbOverlap.Leave += new EventHandler(this.txbOverlap_Leave);
            this.Label2.AutoSize = true;
            this.Label2.BackColor = SystemColors.Control;
            this.Label2.Cursor = Cursors.Default;
            this.Label2.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Label2.ForeColor = SystemColors.ControlText;
            this.Label2.Location = new Point(11, 113);
            this.Label2.Name = "Label2";
            this.Label2.RightToLeft = RightToLeft.No;
            this.Label2.Size = new Size(46, 14);
            this.Label2.TabIndex = 27;
            this.Label2.Text = "重叠度:";
            this.textBox_copied.Location = new Point(85, 15);
            this.textBox_copied.Name = "textBox_copied";
            this.textBox_copied.Size = new Size(122, 20);
            this.textBox_copied.TabIndex = 25;
            this.textBox_copied.Text = "1";
            this.textBox_copied.Leave += new EventHandler(this.textBox_copied_Leave);
            this.lblPageCount.BackColor = SystemColors.Control;
            this.lblPageCount.Cursor = Cursors.Default;
            this.lblPageCount.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblPageCount.ForeColor = SystemColors.ControlText;
            this.lblPageCount.Location = new Point(10, 43);
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.RightToLeft = RightToLeft.No;
            this.lblPageCount.Size = new Size(129, 14);
            this.lblPageCount.TabIndex = 24;
            this.lblPageCount.Text = "页            数: ";
            this.label_copied.AutoSize = true;
            this.label_copied.Location = new Point(10, 19);
            this.label_copied.Name = "label_copied";
            this.label_copied.Size = new Size(67, 14);
            this.label_copied.TabIndex = 13;
            this.label_copied.Text = "打 印 份 数:";
            this.txbStartPage.AcceptsReturn = true;
            this.txbStartPage.BackColor = SystemColors.Window;
            this.txbStartPage.Cursor = Cursors.IBeam;
            this.txbStartPage.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txbStartPage.ForeColor = SystemColors.WindowText;
            this.txbStartPage.Location = new Point(85, 57);
            this.txbStartPage.MaxLength = 0;
            this.txbStartPage.Name = "txbStartPage";
            this.txbStartPage.RightToLeft = RightToLeft.No;
            this.txbStartPage.Size = new Size(122, 20);
            this.txbStartPage.TabIndex = 7;
            this.txbStartPage.Text = "1";
            this.txbStartPage.Leave += new EventHandler(this.txbStartPage_Leave);
            this.txbEndPage.AcceptsReturn = true;
            this.txbEndPage.BackColor = SystemColors.Window;
            this.txbEndPage.Cursor = Cursors.IBeam;
            this.txbEndPage.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txbEndPage.ForeColor = SystemColors.WindowText;
            this.txbEndPage.Location = new Point(85, 83);
            this.txbEndPage.MaxLength = 0;
            this.txbEndPage.Name = "txbEndPage";
            this.txbEndPage.RightToLeft = RightToLeft.No;
            this.txbEndPage.Size = new Size(122, 20);
            this.txbEndPage.TabIndex = 6;
            this.txbEndPage.Text = "0";
            this.txbEndPage.Leave += new EventHandler(this.txbEndPage_Leave);
            this.Label5.AutoSize = true;
            this.Label5.BackColor = SystemColors.Control;
            this.Label5.Cursor = Cursors.Default;
            this.Label5.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Label5.ForeColor = SystemColors.ControlText;
            this.Label5.Location = new Point(6, 65);
            this.Label5.Name = "Label5";
            this.Label5.RightToLeft = RightToLeft.No;
            this.Label5.Size = new Size(70, 14);
            this.Label5.TabIndex = 12;
            this.Label5.Text = "打印开始页:";
            this.Label1.AutoSize = true;
            this.Label1.BackColor = SystemColors.Control;
            this.Label1.Cursor = Cursors.Default;
            this.Label1.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Label1.ForeColor = SystemColors.ControlText;
            this.Label1.Location = new Point(9, 89);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = RightToLeft.No;
            this.Label1.Size = new Size(70, 14);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "打印结束页:";
            this.fraPrinter.BackColor = SystemColors.Control;
            this.fraPrinter.Controls.Add(this.button_printerAttribute);
            this.fraPrinter.Controls.Add(this.comboBox_printer);
            this.fraPrinter.Controls.Add(this.lblPrinterOrientation);
            this.fraPrinter.Controls.Add(this.lblPrinterName);
            this.fraPrinter.Controls.Add(this.lblPrinterSize);
            this.fraPrinter.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.fraPrinter.ForeColor = SystemColors.ControlText;
            this.fraPrinter.Location = new Point(10, 12);
            this.fraPrinter.Name = "fraPrinter";
            this.fraPrinter.RightToLeft = RightToLeft.No;
            this.fraPrinter.Size = new Size(499, 132);
            this.fraPrinter.TabIndex = 23;
            this.fraPrinter.TabStop = false;
            this.fraPrinter.Text = "打印机信息：";
            this.button_printerAttribute.Location = new Point(424, 21);
            this.button_printerAttribute.Name = "button_printerAttribute";
            this.button_printerAttribute.Size = new Size(67, 23);
            this.button_printerAttribute.TabIndex = 26;
            this.button_printerAttribute.Text = "属性";
            this.button_printerAttribute.Click += new EventHandler(this.button_printerAttribute_Click);
            this.comboBox_printer.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox_printer.Location = new Point(71, 22);
            this.comboBox_printer.Name = "comboBox_printer";
            this.comboBox_printer.Size = new Size(346, 22);
            this.comboBox_printer.TabIndex = 25;
            this.comboBox_printer.SelectedIndexChanged += new EventHandler(this.comboBox_printer_SelectedIndexChanged);
            this.lblPrinterOrientation.BackColor = SystemColors.Control;
            this.lblPrinterOrientation.Cursor = Cursors.Default;
            this.lblPrinterOrientation.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblPrinterOrientation.ForeColor = SystemColors.ControlText;
            this.lblPrinterOrientation.Location = new Point(10, 81);
            this.lblPrinterOrientation.Name = "lblPrinterOrientation";
            this.lblPrinterOrientation.RightToLeft = RightToLeft.No;
            this.lblPrinterOrientation.Size = new Size(216, 19);
            this.lblPrinterOrientation.TabIndex = 24;
            this.lblPrinterOrientation.Text = "纸张方向：";
            this.lblPrinterName.AutoSize = true;
            this.lblPrinterName.BackColor = SystemColors.Control;
            this.lblPrinterName.Cursor = Cursors.Default;
            this.lblPrinterName.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblPrinterName.ForeColor = SystemColors.ControlText;
            this.lblPrinterName.Location = new Point(10, 26);
            this.lblPrinterName.Name = "lblPrinterName";
            this.lblPrinterName.RightToLeft = RightToLeft.No;
            this.lblPrinterName.Size = new Size(64, 14);
            this.lblPrinterName.TabIndex = 3;
            this.lblPrinterName.Text = "名       称：";
            this.lblPrinterSize.BackColor = SystemColors.Control;
            this.lblPrinterSize.Cursor = Cursors.Default;
            this.lblPrinterSize.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.lblPrinterSize.ForeColor = SystemColors.ControlText;
            this.lblPrinterSize.Location = new Point(8, 55);
            this.lblPrinterSize.Name = "lblPrinterSize";
            this.lblPrinterSize.RightToLeft = RightToLeft.No;
            this.lblPrinterSize.Size = new Size(216, 18);
            this.lblPrinterSize.TabIndex = 1;
            this.lblPrinterSize.Text = "纸张大小：";
            this.frmPaper.BackColor = SystemColors.Control;
            this.frmPaper.Controls.Add(this.cboPaperTrays);
            this.frmPaper.Controls.Add(this.label12);
            this.frmPaper.Controls.Add(this.optPaperLandscape);
            this.frmPaper.Controls.Add(this.label13);
            this.frmPaper.Controls.Add(this.optPaperPortrait);
            this.frmPaper.Controls.Add(this.cboPrinterPageSize);
            this.frmPaper.Controls.Add(this.label3);
            this.frmPaper.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.frmPaper.ForeColor = SystemColors.ControlText;
            this.frmPaper.Location = new Point(291, 153);
            this.frmPaper.Name = "frmPaper";
            this.frmPaper.RightToLeft = RightToLeft.No;
            this.frmPaper.Size = new Size(220, 97);
            this.frmPaper.TabIndex = 22;
            this.frmPaper.TabStop = false;
            this.frmPaper.Text = "纸张";
            this.cboPaperTrays.BackColor = SystemColors.Window;
            this.cboPaperTrays.Cursor = Cursors.Default;
            this.cboPaperTrays.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboPaperTrays.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.cboPaperTrays.ForeColor = SystemColors.WindowText;
            this.cboPaperTrays.Location = new Point(74, 42);
            this.cboPaperTrays.Name = "cboPaperTrays";
            this.cboPaperTrays.RightToLeft = RightToLeft.No;
            this.cboPaperTrays.Size = new Size(140, 22);
            this.cboPaperTrays.TabIndex = 43;
            this.cboPaperTrays.SelectedIndexChanged += new EventHandler(this.cboPaperTrays_SelectedIndexChanged);
            this.label12.AutoSize = true;
            this.label12.BackColor = SystemColors.Control;
            this.label12.Cursor = Cursors.Default;
            this.label12.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label12.ForeColor = SystemColors.ControlText;
            this.label12.Location = new Point(10, 72);
            this.label12.Name = "label12";
            this.label12.RightToLeft = RightToLeft.No;
            this.label12.Size = new Size(34, 14);
            this.label12.TabIndex = 46;
            this.label12.Text = "方向:";
            this.optPaperLandscape.BackColor = SystemColors.Control;
            this.optPaperLandscape.Cursor = Cursors.Default;
            this.optPaperLandscape.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.optPaperLandscape.ForeColor = SystemColors.ControlText;
            this.optPaperLandscape.Location = new Point(153, 68);
            this.optPaperLandscape.Name = "optPaperLandscape";
            this.optPaperLandscape.RightToLeft = RightToLeft.No;
            this.optPaperLandscape.Size = new Size(50, 23);
            this.optPaperLandscape.TabIndex = 45;
            this.optPaperLandscape.TabStop = true;
            this.optPaperLandscape.Text = "垂直";
            this.optPaperLandscape.UseVisualStyleBackColor = false;
            this.optPaperLandscape.Click += new EventHandler(this.optPaperLandscape_Click);
            this.label13.AutoSize = true;
            this.label13.BackColor = SystemColors.Control;
            this.label13.Cursor = Cursors.Default;
            this.label13.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label13.ForeColor = SystemColors.ControlText;
            this.label13.Location = new Point(10, 42);
            this.label13.Name = "label13";
            this.label13.RightToLeft = RightToLeft.No;
            this.label13.Size = new Size(58, 14);
            this.label13.TabIndex = 42;
            this.label13.Text = "纸张来源:";
            this.optPaperPortrait.BackColor = SystemColors.Control;
            this.optPaperPortrait.Cursor = Cursors.Default;
            this.optPaperPortrait.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.optPaperPortrait.ForeColor = SystemColors.ControlText;
            this.optPaperPortrait.Location = new Point(75, 68);
            this.optPaperPortrait.Name = "optPaperPortrait";
            this.optPaperPortrait.RightToLeft = RightToLeft.No;
            this.optPaperPortrait.Size = new Size(50, 23);
            this.optPaperPortrait.TabIndex = 44;
            this.optPaperPortrait.TabStop = true;
            this.optPaperPortrait.Text = "水平";
            this.optPaperPortrait.UseVisualStyleBackColor = false;
            this.optPaperPortrait.Click += new EventHandler(this.optPaperPortrait_Click);
            this.cboPrinterPageSize.BackColor = SystemColors.Window;
            this.cboPrinterPageSize.Cursor = Cursors.Default;
            this.cboPrinterPageSize.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboPrinterPageSize.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.cboPrinterPageSize.ForeColor = SystemColors.WindowText;
            this.cboPrinterPageSize.Location = new Point(74, 16);
            this.cboPrinterPageSize.Name = "cboPrinterPageSize";
            this.cboPrinterPageSize.RightToLeft = RightToLeft.No;
            this.cboPrinterPageSize.Size = new Size(140, 22);
            this.cboPrinterPageSize.TabIndex = 24;
            this.cboPrinterPageSize.SelectedIndexChanged += new EventHandler(this.cboPrinterPageSize_SelectedIndexChanged);
            this.label3.AutoSize = true;
            this.label3.BackColor = SystemColors.Control;
            this.label3.Cursor = Cursors.Default;
            this.label3.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.label3.ForeColor = SystemColors.ControlText;
            this.label3.Location = new Point(10, 18);
            this.label3.Name = "label3";
            this.label3.RightToLeft = RightToLeft.No;
            this.label3.Size = new Size(34, 14);
            this.label3.TabIndex = 23;
            this.label3.Text = "纸型:";
            this.cmdPrint.BackColor = SystemColors.Control;
            this.cmdPrint.Cursor = Cursors.Default;
            this.cmdPrint.Font = new Font("Arial", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.cmdPrint.ForeColor = SystemColors.ControlText;
            this.cmdPrint.Location = new Point(353, 414);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.RightToLeft = RightToLeft.No;
            this.cmdPrint.Size = new Size(75, 23);
            this.cmdPrint.TabIndex = 24;
            this.cmdPrint.Text = "打印";
            this.cmdPrint.UseVisualStyleBackColor = false;
            this.cmdPrint.Click += new EventHandler(this.cmdPrint_Click);
            this.cmdCancel.Location = new Point(446, 414);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new Size(75, 23);
            this.cmdCancel.TabIndex = 25;
            this.cmdCancel.Text = "取消";
            this.cmdCancel.Click += new EventHandler(this.cmdCancel_Click);
            this.AutoScaleBaseSize = new Size(6, 14);
            base.ClientSize = new Size(535, 445);
            base.Controls.Add(this.cmdCancel);
            base.Controls.Add(this.cmdPrint);
            base.Controls.Add(this.panel1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FormPrinterSetup";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "打印设置窗口";
            base.Load += new EventHandler(this.FormPrinterSetup_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.fraPrint.ResumeLayout(false);
            this.fraPrint.PerformLayout();
            this.fraPrinter.ResumeLayout(false);
            this.fraPrinter.PerformLayout();
            this.frmPaper.ResumeLayout(false);
            this.frmPaper.PerformLayout();
            base.ResumeLayout(false);
        }

       
        private Button button_printerAttribute;
        private ComboBox cboPageSize;
        private ComboBox cboPageToPrinterMapping;
        private ComboBox cboPaperTrays;
        private ComboBox cboPrinterPageSize;
        private CheckBox checkBox_usePrinterPageSize;
        private Button cmdCancel;
        private Button cmdPrint;
        private ComboBox comboBox_printer;
        private GroupBox fraPrint;
        private GroupBox fraPrinter;
        private GroupBox frmPaper;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private IPageLayoutControl ipageLayoutControl_0;
        private Label label_copied;
        private Label Label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label Label2;
        private Label label3;
        private Label label4;
        private Label Label5;
        private Label label7;
        private Label Label8;
        private Label label9;
        private Label lblInfo;
        private Label lblPageCount;
        private Label lblPrinterName;
        private Label lblPrinterOrientation;
        private Label lblPrinterSize;
        private RadioButton optLandscape;
        private RadioButton optPaperLandscape;
        private RadioButton optPaperPortrait;
        private RadioButton optPortrait;
        private Panel panel1;
        private PrintDialog printDialog_0;
        private PrinterSettings printerSettings_0;
        private TextBox textBox_copied;
        private TextBox txbEndPage;
        private TextBox txbOverlap;
        private TextBox txbStartPage;
        private TextBox txtPageHeight;
        private TextBox txtPageWidth;
            private System.Drawing.Printing.PaperSize paperSize_0;
            private int int_0;
            private string string_0;
          
    }
}