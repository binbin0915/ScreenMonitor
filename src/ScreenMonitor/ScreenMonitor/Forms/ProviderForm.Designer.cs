namespace ScreenMonitor.Forms
{
    partial class ProviderForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProviderForm));
            this.label_tips = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_state = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_loginfo = new System.Windows.Forms.ToolStripLabel();
            this.label_startTime = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_tips
            // 
            this.label_tips.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_tips.AutoEllipsis = true;
            this.label_tips.Location = new System.Drawing.Point(11, 34);
            this.label_tips.Name = "label_tips";
            this.label_tips.Size = new System.Drawing.Size(313, 77);
            this.label_tips.TabIndex = 20;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_state,
            this.toolStripLabel_loginfo});
            this.toolStrip2.Location = new System.Drawing.Point(0, 116);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(337, 25);
            this.toolStrip2.TabIndex = 21;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel_state
            // 
            this.toolStripLabel_state.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel_state.Name = "toolStripLabel_state";
            this.toolStripLabel_state.Size = new System.Drawing.Size(92, 22);
            this.toolStripLabel_state.Text = "连接状态：正常";
            // 
            // toolStripLabel_loginfo
            // 
            this.toolStripLabel_loginfo.Name = "toolStripLabel_loginfo";
            this.toolStripLabel_loginfo.Size = new System.Drawing.Size(100, 22);
            this.toolStripLabel_loginfo.Text = "当前登录：david";
            // 
            // label_startTime
            // 
            this.label_startTime.AutoSize = true;
            this.label_startTime.Location = new System.Drawing.Point(22, 13);
            this.label_startTime.Name = "label_startTime";
            this.label_startTime.Size = new System.Drawing.Size(53, 12);
            this.label_startTime.TabIndex = 22;
            this.label_startTime.Text = "启动时间";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "被控端";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // ProviderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 141);
            this.Controls.Add(this.label_startTime);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.label_tips);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ProviderForm";
            this.ShowIcon = false;
            this.Text = "被控端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_tips;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_state;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_loginfo;
        private System.Windows.Forms.Label label_startTime;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
    }
}