﻿using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;

namespace Yutai.ArcGIS.Carto.UI
{
    partial class frmPageLayoutTemp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPageLayoutTemp));
            this.axPageLayoutControl1 = new AxPageLayoutControl();
            this.axPageLayoutControl1.BeginInit();
            base.SuspendLayout();
            this.axPageLayoutControl1.Dock = DockStyle.Fill;
            this.axPageLayoutControl1.Location = new Point(0, 0);
            this.axPageLayoutControl1.Name = "axPageLayoutControl1";
            this.axPageLayoutControl1.OcxState = (AxHost.State) resources.GetObject("axPageLayoutControl1.OcxState") ;
            this.axPageLayoutControl1.Size = new Size(284, 262);
            this.axPageLayoutControl1.TabIndex = 0;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(284, 262);
            base.Controls.Add(this.axPageLayoutControl1);
            base.Name = "frmPageLayoutTemp";
            this.Text = "frmPageLayoutTemp";
            this.axPageLayoutControl1.EndInit();
            base.ResumeLayout(false);
        }
    
    }
}