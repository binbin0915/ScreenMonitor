using OMCS.Passive;
using ScreenMonitor.Forms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace ScreenMonitor
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            IMultimediaManager multimediaManager = MultimediaManagerFactory.GetSingleton();
            multimediaManager.CameraDeviceIndex = 0;
            multimediaManager.CameraVideoSize = new System.Drawing.Size(640, 480);
            multimediaManager.MaxDesktopFrameRate = 10;
            multimediaManager.CameraEncodeQuality = 10;
            multimediaManager.MicrophoneDeviceIndex = 0;
            multimediaManager.MaxDesktopFrameRate = 5;
            multimediaManager.DesktopRegion = null;
            multimediaManager.DesktopEncodeQuality = 12;
            multimediaManager.Advanced.UseOriginImage4Myself = false;

            multimediaManager.Initialize(loginForm.CurrentUserID, "", ConfigurationManager.AppSettings["ServerIP"], int.Parse(ConfigurationManager.AppSettings["ServerPort"]));
            Form mainForm;
            if (loginForm.IsMonitor)
            {
                mainForm = new MonitorForm(multimediaManager, loginForm.CurrentUserID);
            }
            else {
                mainForm = new ProviderForm(multimediaManager, loginForm.CurrentUserID);
            }

            Application.Run(mainForm);
        }
    }
}
