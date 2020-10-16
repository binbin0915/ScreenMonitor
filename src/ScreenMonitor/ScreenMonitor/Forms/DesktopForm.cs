using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OMCS.Passive;
using ESBasic;

namespace ScreenMonitor.Forms
{
    public partial class DesktopForm : Form
    {       
        private string ownerID;

        public DesktopForm(string friendID,bool audioEnabled)
        {
            InitializeComponent();
            
            this.ownerID = friendID;
            this.Text = string.Format("正在访问{0}的桌面", this.ownerID);          
            this.desktopConnector1.ConnectEnded += new CbGeneric<ConnectResult>(desktopConnector1_ConnectEnded);
            this.desktopConnector1.Disconnected += DesktopConnector1_Disconnected;
            this.desktopConnector1.BeginConnect(this.ownerID);
            if (audioEnabled)
            {
                this.microphoneConnector1.BeginConnect(this.ownerID);
            }
        }

        private void DesktopConnector1_Disconnected(ConnectorDisconnectedType type)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric<ConnectorDisconnectedType>(this.DesktopConnector1_Disconnected), type);
            }
            else
            {
                if (type == ConnectorDisconnectedType.OwnerActiveDisconnect || type == ConnectorDisconnectedType.GuestActiveDisconnect)
                {
                    return;
                }
                MessageBox.Show("断开连接!原因：" + type);
                this.Close();
            }
        }


        void desktopConnector1_ConnectEnded(ConnectResult result)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new CbGeneric<ConnectResult>(this.desktopConnector1_ConnectEnded), result);
            }
            else
            {
                if (result != ConnectResult.Succeed)
                {
                    MessageBox.Show("连接失败!" + result.ToString());
                }    
            }
        }

        //关闭窗口时，主动断开连接，并释放连接器。
        private void DesktopForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.desktopConnector1.Disconnect();
            this.desktopConnector1.Dispose();
            this.microphoneConnector1.Disconnect();
            this.microphoneConnector1.Dispose();
        }       
    }
}
