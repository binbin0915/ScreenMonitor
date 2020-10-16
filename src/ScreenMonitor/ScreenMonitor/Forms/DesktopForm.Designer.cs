using OMCS.Passive.RemoteDesktop;
namespace ScreenMonitor.Forms
{
    partial class DesktopForm
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
            this.desktopConnector1 = new OMCS.Passive.RemoteDesktop.DesktopConnector();
            this.microphoneConnector1 = new OMCS.Passive.Audio.MicrophoneConnector(this.components);
            this.SuspendLayout();
            // 
            // desktopConnector1
            // 
            this.desktopConnector1.AdaptiveToViewerSize = false;
            this.desktopConnector1.AutoScroll = true;
            this.desktopConnector1.BackColor = System.Drawing.Color.White;
            this.desktopConnector1.Cursor = System.Windows.Forms.Cursors.No;
            this.desktopConnector1.DisplayVideoParameters = true;
            this.desktopConnector1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.desktopConnector1.Location = new System.Drawing.Point(0, 0);
            this.desktopConnector1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.desktopConnector1.Name = "desktopConnector1";
            this.desktopConnector1.ShowMouseCursor = false;
            this.desktopConnector1.Size = new System.Drawing.Size(795, 512);
            this.desktopConnector1.TabIndex = 0;
            this.desktopConnector1.WaitOwnerOnlineSpanInSecs = 0;
            this.desktopConnector1.WatchingOnly = false;
            // 
            // microphoneConnector1
            // 
            this.microphoneConnector1.Mute = false;
            this.microphoneConnector1.SpringReceivedEventWhenMute = false;
            this.microphoneConnector1.WaitOwnerOnlineSpanInSecs = 0;
            // 
            // DesktopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 512);
            this.Controls.Add(this.desktopConnector1);
            this.Name = "DesktopForm";
            this.Text = "DesktopForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DesktopForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private DesktopConnector desktopConnector1;
        private OMCS.Passive.Audio.MicrophoneConnector microphoneConnector1;
    }
}