namespace GPUTemperatureMonitor
{
    partial class HomeScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gpuTempLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.appStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.appMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gpuTempChart = new LiveCharts.WinForms.CartesianChart();
            this.groupBox1.SuspendLayout();
            this.appStatusStrip.SuspendLayout();
            this.appMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpuTempLabel
            // 
            this.gpuTempLabel.AutoSize = true;
            this.gpuTempLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpuTempLabel.Location = new System.Drawing.Point(327, 40);
            this.gpuTempLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gpuTempLabel.Name = "gpuTempLabel";
            this.gpuTempLabel.Size = new System.Drawing.Size(50, 45);
            this.gpuTempLabel.TabIndex = 0;
            this.gpuTempLabel.Text = "0°";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "GPU Temperature :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gpuTempChart);
            this.groupBox1.Controls.Add(this.gpuTempLabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(18, 75);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(909, 490);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GPU Data";
            // 
            // appStatusStrip
            // 
            this.appStatusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.appStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.appStatusStrip.Location = new System.Drawing.Point(0, 605);
            this.appStatusStrip.Name = "appStatusStrip";
            this.appStatusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.appStatusStrip.Size = new System.Drawing.Size(1259, 32);
            this.appStatusStrip.TabIndex = 3;
            this.appStatusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(92, 25);
            this.toolStripStatusLabel1.Text = "Greetings!";
            // 
            // appMenuStrip
            // 
            this.appMenuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.appMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.appMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.appMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.appMenuStrip.Name = "appMenuStrip";
            this.appMenuStrip.Size = new System.Drawing.Size(1259, 36);
            this.appMenuStrip.TabIndex = 4;
            this.appMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 30);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // gpuTempChart
            // 
            this.gpuTempChart.Location = new System.Drawing.Point(443, 52);
            this.gpuTempChart.Name = "gpuTempChart";
            this.gpuTempChart.Size = new System.Drawing.Size(417, 346);
            this.gpuTempChart.TabIndex = 4;
            this.gpuTempChart.Text = "cartesianChart1";
            // 
            // HomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 637);
            this.Controls.Add(this.appStatusStrip);
            this.Controls.Add(this.appMenuStrip);
            this.Controls.Add(this.groupBox1);
            this.MainMenuStrip = this.appMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "HomeScreen";
            this.Text = "System Monitor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.appStatusStrip.ResumeLayout(false);
            this.appStatusStrip.PerformLayout();
            this.appMenuStrip.ResumeLayout(false);
            this.appMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label gpuTempLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip appStatusStrip;
        private System.Windows.Forms.MenuStrip appMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private LiveCharts.WinForms.CartesianChart gpuTempChart;
    }
}

