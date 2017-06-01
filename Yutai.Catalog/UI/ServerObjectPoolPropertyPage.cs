﻿namespace Yutai.Catalog.UI
{
    using ESRI.ArcGIS.GISClient;
    using ESRI.ArcGIS.Server;
    
    
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    internal class ServerObjectPoolPropertyPage : UserControl
    {
        private bool bool_0 = false;
        private bool bool_1 = false;
        private Container container_0 = null;
        private GroupBox groupBox1;
        private IAGSServerConnectionAdmin iagsserverConnectionAdmin_0 = null;
        private IServerObjectConfiguration iserverObjectConfiguration_0 = null;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox rdoIsPooled;
        private string string_0 = "Started";
        private Button txtMaxInstances;
        private Button txtMaxInstances1;
        private Button txtMaxUsageTime;
        private Button txtMaxWaitTime;
        private Button txtMinInstances;

        public ServerObjectPoolPropertyPage()
        {
            this.InitializeComponent();
        }

        public void Apply()
        {
            if (this.bool_0)
            {
                this.bool_0 = false;
                if (this.rdoIsPooled.SelectedIndex == 0)
                {
                    this.iserverObjectConfiguration_0.IsPooled = true;
                    this.iserverObjectConfiguration_0.MaxInstances = int.Parse(this.txtMaxInstances.Text);
                    this.iserverObjectConfiguration_0.MinInstances = int.Parse(this.txtMinInstances.Text);
                }
                else
                {
                    this.iserverObjectConfiguration_0.IsPooled = false;
                    this.iserverObjectConfiguration_0.MaxInstances = int.Parse(this.txtMaxInstances.Text);
                }
                this.iserverObjectConfiguration_0.WaitTimeout = int.Parse(this.txtMaxWaitTime.Text);
                this.iserverObjectConfiguration_0.UsageTimeout = int.Parse(this.txtMaxUsageTime.Text);
            }
        }

        protected override void Dispose(bool bool_2)
        {
            if (bool_2 && (this.container_0 != null))
            {
                this.container_0.Dispose();
            }
            base.Dispose(bool_2);
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new GroupBox();
            this.txtMaxInstances1 = new Button();
            this.label3 = new Label();
            this.txtMaxInstances = new Button();
            this.txtMinInstances = new Button();
            this.label2 = new Label();
            this.label1 = new Label();
            this.rdoIsPooled = new ComboBox();
            this.txtMaxUsageTime = new Button();
            this.label4 = new Label();
            this.txtMaxWaitTime = new Button();
            this.label5 = new Label();
            this.groupBox1.SuspendLayout();
           
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.txtMaxInstances1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMaxInstances);
            this.groupBox1.Controls.Add(this.txtMinInstances);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rdoIsPooled);
            this.groupBox1.Location = new Point(0x10, 0x10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x150, 160);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.txtMaxInstances1.Text = "4";
            this.txtMaxInstances1.Location = new Point(120, 130);
            this.txtMaxInstances1.Name = "txtMaxInstances1";
            this.txtMaxInstances1.Size = new Size(0x58, 0x17);
            this.txtMaxInstances1.TabIndex = 6;
            this.txtMaxInstances1.TextChanged += new EventHandler(this.txtMaxInstances1_EditValueChanged);
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x20, 0x86);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x55, 0x11);
            this.label3.TabIndex = 5;
            this.label3.Text = "最可用实例数:";
            this.txtMaxInstances.Text = "4";
            this.txtMaxInstances.Location = new Point(120, 0x56);
            this.txtMaxInstances.Name = "txtMaxInstances";
            this.txtMaxInstances.Size = new Size(0x58, 0x17);
            this.txtMaxInstances.TabIndex = 4;
            this.txtMaxInstances.TextChanged += new EventHandler(this.txtMaxInstances_EditValueChanged);
            this.txtMinInstances.Text = "2";
            this.txtMinInstances.Location = new Point(120, 0x36);
            this.txtMinInstances.Name = "txtMinInstances";
            this.txtMinInstances.Size = new Size(0x58, 0x17);
            this.txtMinInstances.TabIndex = 3;
            this.txtMinInstances.TextChanged += new EventHandler(this.txtMinInstances_EditValueChanged);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x20, 0x56);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x48, 0x11);
            this.label2.TabIndex = 2;
            this.label2.Text = "最大实例数:";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x20, 0x3e);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x48, 0x11);
            this.label1.TabIndex = 1;
            this.label1.Text = "最小实例数:";
            this.rdoIsPooled.Location = new Point(8, 14);
            this.rdoIsPooled.Name = "rdoIsPooled";
        
            this.rdoIsPooled.Items.AddRange(new object[] {  "缓冲", "无缓冲" });
            this.rdoIsPooled.Size = new Size(0xa8, 0x88);
            this.rdoIsPooled.TabIndex = 0;
            this.rdoIsPooled.SelectedIndexChanged += new EventHandler(this.rdoIsPooled_SelectedIndexChanged);
            this.txtMaxUsageTime.Text = "600";
            this.txtMaxUsageTime.Location = new Point(0xd8, 0xb8);
            this.txtMaxUsageTime.Name = "txtMaxUsageTime";
            this.txtMaxUsageTime.Size = new Size(0x58, 0x17);
            this.txtMaxUsageTime.TabIndex = 8;
            this.txtMaxUsageTime.TextChanged += new EventHandler(this.txtMaxUsageTime_EditValueChanged);
            this.label4.AutoSize = true;
            this.label4.Location = new Point(40, 0xc0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0xab, 0x11);
            this.label4.TabIndex = 7;
            this.label4.Text = "Server Objects最大使用时间:";
            this.txtMaxWaitTime.Text = "60";
            this.txtMaxWaitTime.Location = new Point(0xd8, 0xd8);
            this.txtMaxWaitTime.Name = "txtMaxWaitTime";
            this.txtMaxWaitTime.Size = new Size(0x58, 0x17);
            this.txtMaxWaitTime.TabIndex = 10;
            this.txtMaxWaitTime.TextChanged += new EventHandler(this.txtMaxWaitTime_EditValueChanged);
            this.label5.AutoSize = true;
            this.label5.Location = new Point(40, 0xe0);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0xab, 0x11);
            this.label5.TabIndex = 9;
            this.label5.Text = "Server Objects最大等待时间:";
            base.Controls.Add(this.txtMaxWaitTime);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.txtMaxUsageTime);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.groupBox1);
            base.Name = "ServerObjectPoolPropertyPage";
            base.Size = new Size(400, 0x110);
            base.Load += new EventHandler(this.ServerObjectPoolPropertyPage_Load);
            this.groupBox1.ResumeLayout(false);
         
            base.ResumeLayout(false);
        }

        private void method_0()
        {
            if (this.iserverObjectConfiguration_0.IsPooled)
            {
                this.rdoIsPooled.SelectedIndex = 0;
            }
            else
            {
                this.rdoIsPooled.SelectedIndex = 1;
            }
            this.txtMaxInstances.Text = this.iserverObjectConfiguration_0.MaxInstances.ToString();
            this.txtMaxInstances1.Text = this.iserverObjectConfiguration_0.MaxInstances.ToString();
            this.txtMinInstances.Text = this.iserverObjectConfiguration_0.MinInstances.ToString();
            this.txtMaxUsageTime.Text = this.iserverObjectConfiguration_0.UsageTimeout.ToString();
            this.txtMaxWaitTime.Text = this.iserverObjectConfiguration_0.WaitTimeout.ToString();
            if (this.string_0 == "Stoped")
            {
                this.rdoIsPooled.Enabled = true;
                this.txtMaxInstances.Enabled = true;
                this.txtMaxInstances1.Enabled = true;
                this.txtMinInstances.Enabled = true;
                this.txtMaxUsageTime.Enabled = true;
                this.txtMaxWaitTime.Enabled = true;
            }
            else
            {
                this.rdoIsPooled.Enabled = false;
                this.txtMaxInstances.Enabled = false;
                this.txtMaxInstances1.Enabled = false;
                this.txtMinInstances.Enabled = false;
                this.txtMaxUsageTime.Enabled = false;
                this.txtMaxWaitTime.Enabled = false;
            }
        }

        private void rdoIsPooled_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rdoIsPooled.SelectedIndex == 0)
            {
                this.txtMaxInstances.Enabled = true;
                this.txtMinInstances.Enabled = true;
                this.txtMaxInstances1.Enabled = false;
            }
            else
            {
                this.txtMaxInstances1.Enabled = true;
                this.txtMaxInstances.Enabled = false;
                this.txtMinInstances.Enabled = false;
            }
            if (this.bool_1)
            {
                this.bool_0 = true;
            }
        }

        private void ServerObjectPoolPropertyPage_Load(object sender, EventArgs e)
        {
            this.method_0();
            this.bool_1 = true;
        }

        private void txtMaxInstances_EditValueChanged(object sender, EventArgs e)
        {
            if (this.bool_1)
            {
                this.bool_0 = true;
            }
        }

        private void txtMaxInstances1_EditValueChanged(object sender, EventArgs e)
        {
            if (this.bool_1)
            {
                this.bool_0 = true;
            }
        }

        private void txtMaxUsageTime_EditValueChanged(object sender, EventArgs e)
        {
            if (this.bool_1)
            {
                this.bool_0 = true;
            }
        }

        private void txtMaxWaitTime_EditValueChanged(object sender, EventArgs e)
        {
            if (this.bool_1)
            {
                this.bool_0 = true;
            }
        }

        private void txtMinInstances_EditValueChanged(object sender, EventArgs e)
        {
            if (this.bool_1)
            {
                this.bool_0 = true;
            }
        }

        public IAGSServerConnectionAdmin AGSConnectionAdmin
        {
            set
            {
                this.iagsserverConnectionAdmin_0 = value;
            }
        }

        public IServerObjectConfiguration ServerObjectConfiguration
        {
            get
            {
                return this.iserverObjectConfiguration_0;
            }
            set
            {
                this.iserverObjectConfiguration_0 = value;
            }
        }

        public string Status
        {
            set
            {
                this.string_0 = value;
            }
        }
    }
}
