namespace ScreenMonitor.Forms
{
    partial class MonitorForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.desktop_Btn = new System.Windows.Forms.Button();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_state = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_loginfo = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 23);
            this.label2.TabIndex = 15;
            this.label2.Text = "目标帐号：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_id
            // 
            this.textBox_id.Location = new System.Drawing.Point(71, 9);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.Size = new System.Drawing.Size(100, 21);
            this.textBox_id.TabIndex = 16;
            this.textBox_id.Text = "aa01";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(193, 11);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "监听声音";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // desktop_Btn
            // 
            this.desktop_Btn.Location = new System.Drawing.Point(12, 49);
            this.desktop_Btn.Name = "desktop_Btn";
            this.desktop_Btn.Size = new System.Drawing.Size(75, 23);
            this.desktop_Btn.TabIndex = 18;
            this.desktop_Btn.Text = "观看屏幕";
            this.desktop_Btn.UseVisualStyleBackColor = true;
            this.desktop_Btn.Click += new System.EventHandler(this.desktop_Btn_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_state,
            this.toolStripLabel_loginfo});
            this.toolStrip2.Location = new System.Drawing.Point(0, 115);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(334, 25);
            this.toolStrip2.TabIndex = 19;
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
            // MonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 140);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.desktop_Btn);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox_id);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MonitorForm";
            this.ShowIcon = false;
            this.Text = "监控端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button desktop_Btn;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_state;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_loginfo;
    }
}