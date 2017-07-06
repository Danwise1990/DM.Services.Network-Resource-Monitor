namespace DM.Services.NetworkResourceMonitor.GUI
{
    partial class GUI
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
            this.btn_TriggerException = new System.Windows.Forms.Button();
            this.btn_PingResources = new System.Windows.Forms.Button();
            this.txtbx_MonitorOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_TriggerException
            // 
            this.btn_TriggerException.Location = new System.Drawing.Point(121, 12);
            this.btn_TriggerException.Name = "btn_TriggerException";
            this.btn_TriggerException.Size = new System.Drawing.Size(103, 23);
            this.btn_TriggerException.TabIndex = 0;
            this.btn_TriggerException.Text = "Trigger Exception";
            this.btn_TriggerException.UseVisualStyleBackColor = true;
            this.btn_TriggerException.Click += new System.EventHandler(this.btn_TriggerException_Click);
            // 
            // btn_PingResources
            // 
            this.btn_PingResources.Location = new System.Drawing.Point(12, 12);
            this.btn_PingResources.Name = "btn_PingResources";
            this.btn_PingResources.Size = new System.Drawing.Size(103, 23);
            this.btn_PingResources.TabIndex = 1;
            this.btn_PingResources.Text = "Ping Resources";
            this.btn_PingResources.UseVisualStyleBackColor = true;
            this.btn_PingResources.Click += new System.EventHandler(this.btn_PingResources_Click);
            // 
            // txtbx_MonitorOutput
            // 
            this.txtbx_MonitorOutput.Location = new System.Drawing.Point(12, 41);
            this.txtbx_MonitorOutput.Multiline = true;
            this.txtbx_MonitorOutput.Name = "txtbx_MonitorOutput";
            this.txtbx_MonitorOutput.ReadOnly = true;
            this.txtbx_MonitorOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbx_MonitorOutput.Size = new System.Drawing.Size(405, 266);
            this.txtbx_MonitorOutput.TabIndex = 2;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 319);
            this.Controls.Add(this.txtbx_MonitorOutput);
            this.Controls.Add(this.btn_PingResources);
            this.Controls.Add(this.btn_TriggerException);
            this.Name = "GUI";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Network Resource Monitor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_TriggerException;
        private System.Windows.Forms.Button btn_PingResources;
        private System.Windows.Forms.TextBox txtbx_MonitorOutput;
    }
}