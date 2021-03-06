﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.Analyst3D;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Location;
using Yutai.ArcGIS.Common.Carto;

namespace Yutai.ArcGIS.Carto.UI
{
    partial class frmLayerPropertyEx
    {
        protected override void Dispose(bool bool_0)
        {
            if (bool_0 && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(bool_0);
        }

       
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLayerPropertyEx));
            this.panel1 = new Panel();
            this.tabControl1 = new TabControl();
            this.panel2 = new Panel();
            this.btnCancel = new SimpleButton();
            this.btnOK = new SimpleButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            base.SuspendLayout();
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = DockStyle.Top;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(621, 374);
            this.panel1.TabIndex = 0;
            this.tabControl1.Dock = DockStyle.Fill;
            this.tabControl1.Location = new Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new Size(621, 374);
            this.tabControl1.TabIndex = 0;
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Dock = DockStyle.Bottom;
            this.panel2.Location = new Point(0, 376);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(621, 32);
            this.panel2.TabIndex = 1;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new Point(488, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(56, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnOK.Location = new Point(424, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(56, 24);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new EventHandler(this.btnOK_Click);
            this.AutoScaleBaseSize = new Size(6, 14);
            base.ClientSize = new Size(621, 408);
            base.Controls.Add(this.panel2);
            base.Controls.Add(this.panel1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmLayerPropertyEx";
            this.Text = "图层属性";
            base.Load += new EventHandler(this.frmLayerPropertyEx_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            base.ResumeLayout(false);
        }

       
        private SimpleButton btnCancel;
        private SimpleButton btnOK;
        private Panel panel1;
        private Panel panel2;
        private TabControl tabControl1;
    }
}