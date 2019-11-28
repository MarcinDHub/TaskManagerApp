using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using Tray;

namespace TaskManagerApp
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TrayClass trayClass;
        public MainWindow()
        {
            InitializeComponent();
            Closing += OnClosingWindow;
            trayClass = new TrayClass(this);

            TaskHeaderUC taskH = new TaskHeaderUC();
            taskH.TaskClient = "Haber";
            taskH.TaskTypeImage = "RadioAm";
            taskH.TaskTitle = "instalka";
            ListBox.Items.Add(taskH);

            TaskHeaderUC taskH1 = new TaskHeaderUC();
            taskH1.TaskClient = "Rybacka";
            taskH1.TaskTypeImage = "Refresh";
            taskH1.TaskTitle = "kalibracja";
            ListBox.Items.Add(taskH1);

            TaskHeaderUC taskH2 = new TaskHeaderUC();
            taskH2.TaskClient = "Port Gdański Eksploatacja";
            taskH2.TaskTypeImage = "Read";
            taskH2.TaskTitle = "ciągle są problemy ze stacją; przepływomierz liczy dziwne impulsy; komunikator migocze";
            ListBox.Items.Add(taskH2);

            TaskHeaderUC taskH3 = new TaskHeaderUC();
            taskH3.TaskClient = "MTM";
            taskH3.TaskTypeImage = "Recycle";
            taskH3.TaskTitle = "szkolenie";
            ListBox.Items.Add(taskH3);
        }

        private void OnClosingWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            trayClass.ShowTrayInformation("Tytuł", "Treść");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }


        private void PlayPauseButton_Click(object sender, RoutedEventArgs e)
        {
            //if (PlayPauseButtonIcon.Kind == MaterialDesignThemes.Wpf.PackIconKind.Pause)
            //{
            //    PlayPauseButtonIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Play;
            //}
            //else
            //{
            //    PlayPauseButtonIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Pause;
            //}
        }

        private void MenuButtonTasks_Click(object sender, RoutedEventArgs e)
        {
            Style style = this.FindResource("MaterialDesignRaisedLightButton") as Style;
            MenuClearSelection();
            MenuButtonTasks.Style = style;
        }

        private void MenuButtonReports_Click(object sender, RoutedEventArgs e)
        {
            Style style = this.FindResource("MaterialDesignRaisedLightButton") as Style;
            MenuClearSelection();
            MenuButtonReports.Style = style;
        }

        private void MenuButtonImplementations_Click(object sender, RoutedEventArgs e)
        {
            Style style = this.FindResource("MaterialDesignRaisedLightButton") as Style;
            MenuClearSelection();
            MenuButtonImplementations.Style = style;
        }


        private void MenuClearSelection()
        {
            Style style = this.FindResource("MaterialDesignRaisedButton") as Style;
            MenuButtonTasks.Style = style;
            MenuButtonReports.Style = style;
            MenuButtonImplementations.Style = style;
        }
    }
}
