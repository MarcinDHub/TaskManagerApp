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
using static TaskManagerApp.Config;
using System.Data;

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

            List<TaskClass> taskList = new List<TaskClass>();
            DataTable dt = Query.TaskList();

            foreach(DataRow row in dt.Rows)
            {
                taskList.Add(new TaskClass
                {
                    ID = Convert.ToInt32(row["ID"]),
                    userID = Convert.ToInt32(row["UserID"]),
                    clientID = Convert.ToInt32(row["ClientID"]),
                    title = row["Title"].ToString(),
                    subtitle = row["Subtitle"].ToString(),
                    createdDate = (DateTime)row["CreatedDate"],
                    deadlineDate = (DateTime)row["DeadlineDate"],
                    category = Convert.ToInt32(row["Category"])
                });
            }

            foreach (TaskClass task in taskList)
            {
                TaskHeaderUC taskHeader = new TaskHeaderUC();

                taskHeader.TaskClient = task.clientID;
                taskHeader.TaskTypeImage = "RadioAm";
                taskHeader.TaskTitle = task.title;
                ListBox.Items.Add(taskHeader);
            }
            //TaskHeaderUC taskH = new TaskHeaderUC();
            //taskH.TaskClient = "Haber";
            //taskH.TaskTypeImage = "RadioAm";
            //taskH.TaskTitle = "instalka";
            //ListBox.Items.Add(taskH);


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
            selectedTab = "TASKS";
        }

        private void MenuButtonReports_Click(object sender, RoutedEventArgs e)
        {
            Style style = this.FindResource("MaterialDesignRaisedLightButton") as Style;
            MenuClearSelection();
            MenuButtonReports.Style = style;
            selectedTab = "REPORTS";
        }

        private void MenuButtonImplementations_Click(object sender, RoutedEventArgs e)
        {
            Style style = this.FindResource("MaterialDesignRaisedLightButton") as Style;
            MenuClearSelection();
            MenuButtonImplementations.Style = style;
            selectedTab = "IMPLEMENTATIONS";
        }


        private void MenuClearSelection()
        {
            Style style = this.FindResource("MaterialDesignRaisedButton") as Style;
            MenuButtonTasks.Style = style;
            MenuButtonReports.Style = style;
            MenuButtonImplementations.Style = style;
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            AddTask addTask = new AddTask();
            addTask.Show();
        }
    }
}
