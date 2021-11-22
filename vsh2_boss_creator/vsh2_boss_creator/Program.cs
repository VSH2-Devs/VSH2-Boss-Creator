using System;
using System.Windows.Forms;

namespace vsh2_boss_creator
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }

        public static void CreateErrorNotification(string _sText)
        {
            NotifyIcon notification = new NotifyIcon()
            {
                Visible = true,
                Icon = System.Drawing.SystemIcons.Error,
                BalloonTipTitle = Application.ProductName,
                BalloonTipText = _sText,
            };
            notification.ShowBalloonTip(5000);
            notification.BalloonTipClosed += (_, __) => notification.Dispose();
            notification.BalloonTipClicked += (_, __) => notification.Dispose();
        }
    }
}
