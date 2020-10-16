using OMCS.Passive;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace ScreenMonitor.Forms
{
    public partial class ProviderForm : Form
    {
        private IMultimediaManager multimediaManager;
        private string userID;
        private List<string> monitors = new List<string>();
        public ProviderForm(IMultimediaManager mgr, string currentUserID)
        {
            InitializeComponent();
            this.userID = currentUserID;
            this.multimediaManager = mgr;

            //预定与OMCS服务器的连接断开、重连成功事件
            this.multimediaManager.ConnectionInterrupted += new ESBasic.CbGeneric<IPEndPoint>(multimediaManager_ConnectionInterrupted);
            this.multimediaManager.ConnectionRebuildSucceed += new ESBasic.CbGeneric<IPEndPoint>(multimediaManager_ConnectionRebuildSucceed);
            this.multimediaManager.DeviceConnected += MultimediaManager_DeviceConnected;
            this.multimediaManager.DeviceDisconnected += MultimediaManager_DeviceDisconnected;
            this.toolStripLabel_loginfo.Text = string.Format("当前登录：{0}", this.userID);
            this.toolStripLabel_state.Text = "连接状态：正常";
            this.label_startTime.Text = "启动时间：" + DateTime.Now.ToString();
        }

        private void MultimediaManager_DeviceDisconnected(string targetID, OMCS.MultimediaDeviceType type)
        {
            if (this.monitors.Contains(targetID) && type == OMCS.MultimediaDeviceType.Desktop)
            {
                this.monitors.Remove(targetID);
                this.ShowTips();
            }
        }

        private void MultimediaManager_DeviceConnected(string targetID, OMCS.MultimediaDeviceType type)
        {

            if (!this.monitors.Contains(targetID) && type == OMCS.MultimediaDeviceType.Desktop)
            {
                this.monitors.Add(targetID);
                this.ShowTips();
            }
        }

        private void ShowTips()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ESBasic.CbGeneric(this.ShowTips));
            }
            else {
                this.label_tips.Text = monitors.Count > 0 ? "以下用户在观看我的屏幕：\r\n" + ESBasic.Helpers.StringHelper.ContactString<string>(",", monitors.ToArray()) : "";
            }
        }

        #region multimediaManager_ConnectionRebuildSucceed
        void multimediaManager_ConnectionRebuildSucceed(IPEndPoint ipEndPoint)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ESBasic.CbGeneric<IPEndPoint>(this.multimediaManager_ConnectionRebuildSucceed), ipEndPoint);
            }
            else
            {
                this.toolStripLabel_state.Text = "连接状态：正常（重连成功）";
                this.toolStripLabel_state.ForeColor = Color.Black;


            }
        }
        #endregion 

        #region multimediaManager_ConnectionInterrupted
        void multimediaManager_ConnectionInterrupted(IPEndPoint ipEndPoint)
        {
            if (this.isClosing)
            {
                return;
            }
            if (this.InvokeRequired)
            {
                this.Invoke(new ESBasic.CbGeneric<IPEndPoint>(this.multimediaManager_ConnectionInterrupted), ipEndPoint);
            }
            else
            {
                this.toolStripLabel_state.Text = "连接状态：断开";
                this.toolStripLabel_state.ForeColor = Color.Red;
            }
        }
        #endregion

        private bool isClosing = false;
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //若不是确定退出，则最小化窗体，取消关闭操作
            if (!this.isExit)
            {
                this.Visible = false;
                e.Cancel = true;
                return;
            }
            this.isClosing = true;
            this.multimediaManager.Dispose();
        }
        private bool isExit;
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ESBasic.Helpers.WindowsHelper.ShowQuery("您确定要退出被控端吗？"))
            {
                this.isExit = true;
                this.Dispose();
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip1.Show();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = !this.Visible;
            this.Activate();
        }
    }
}
