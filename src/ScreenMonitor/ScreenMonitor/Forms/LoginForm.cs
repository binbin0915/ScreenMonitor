using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScreenMonitor
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private string currentUserID;
        public string CurrentUserID
        {
            get { return currentUserID; }
        }

        private bool isMonitor = false;

        public bool IsMonitor
        {
            get { return this.isMonitor; }
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string userID = this.textBox_id.Text.Trim();
            if (userID.Length > 10)
            {
                MessageBox.Show("ID长度必须小于10.");
                return;
            }
            this.isMonitor = this.radioButton1.Checked;
            this.currentUserID = userID;
            this.DialogResult = DialogResult.OK;
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != System.Windows.Forms.DialogResult.OK)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }
    }
}
