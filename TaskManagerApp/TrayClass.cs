using System;
using System.IO;
using System.Windows.Forms;
using TaskManagerApp;

namespace Tray
{
    public class TrayClass
    {
        private MainWindow mainWindow;

        private ContextMenu m_menu;
        private NotifyIcon ni;

        public TrayClass(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            /* */
            ni = new NotifyIcon();
            Stream iconStream = System.Windows.Application.GetResourceStream(new Uri("pack://application:,,,/Resources/ico.ico")).Stream;
            ni.Icon = new System.Drawing.Icon(iconStream);
            ni.Text = "Tray test";
            ni.Visible = true;

            ni.DoubleClick += TrayOpen_Click;

            /* menu */
            m_menu = new ContextMenu();
            m_menu.MenuItems.Add(0,
                new MenuItem("Otwórz", new System.EventHandler(TrayOpen_Click)));
            m_menu.MenuItems.Add(1,
                new MenuItem("Zamknij", new System.EventHandler(TrayExit_Click)));
            ni.ContextMenu = m_menu;
        }

        public void ShowTrayInformation(string Title, string Content)
        {
            ni.BalloonTipTitle = Title;
            ni.BalloonTipText = Content;
            ni.BalloonTipIcon = ToolTipIcon.None;
            ni.Visible = true;
            ni.ShowBalloonTip(30000);

            ni.BalloonTipClicked += delegate (object sender, EventArgs args)
            {
                mainWindow.Show();
                mainWindow.Activate();
            };
        }

        private void TrayExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void TrayOpen_Click(object sender, EventArgs e)
        {
            mainWindow.Show();
            mainWindow.Activate();
        }
    }
}