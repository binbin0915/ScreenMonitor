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
    public partial class MonitorForm : Form
    {
        private IMultimediaManager multimediaManager;
        private string userID;

        public MonitorForm(IMultimediaManager mgr, string currentUserID)
        {
            InitializeComponent();
            this.userID = currentUserID;
            this.multimediaManager = mgr;

            //预定与OMCS服务器的连接断开、重连成功事件
            this.multimediaManager.ConnectionInterrupted += new ESBasic.CbGeneric<IPEndPoint>(multimediaManager_ConnectionInterrupted);
            this.multimediaManager.ConnectionRebuildSucceed += new ESBasic.CbGeneric<IPEndPoint>(multimediaManager_ConnectionRebuildSucceed);

            this.toolStripLabel_loginfo.Text = string.Format("当前登录：{0}", this.userID);
            this.toolStripLabel_state.Text = "连接状态：正常";
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
            this.isClosing = true;
            this.multimediaManager.Dispose();
        }

        private void desktop_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                string targetID = this.textBox_id.Text;
                if (string.IsNullOrEmpty(targetID))
                {
                    MessageBox.Show("连接目标不能为空！");
                    return;
                }

                DesktopForm form = new DesktopForm(targetID, this.checkBox1.Checked);
                form.Show();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
