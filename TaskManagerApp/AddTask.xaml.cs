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
using System.Windows.Shapes;
using static TaskManagerApp.Query;
using static TaskManagerApp.Config;

namespace TaskManagerApp
{
    /// <summary>
    /// Logika interakcji dla klasy AddTask.xaml
    /// </summary>
    public partial class AddTask : Window
    {
        public AddTask()
        {
            InitializeComponent();
            AddTaskUser.ItemsSource = Config.employeesList;
            AddTaskClient.ItemsSource = Config.clientsList;
            AddTaskCategory.ItemsSource = Config.categoriesList;
        }

        private void AddTaskCreate_Click(object sender, RoutedEventArgs e)
        {
            TaskClass newTask = new TaskClass
            {
                userID = ((Employee)AddTaskUser.SelectedItem).ID,
                clientID = ((Client)AddTaskClient.SelectedItem).ID,
                title = AddTaskTitle.Text,
                subtitle = AddTaskContent.Text.Replace("'",""),
                createdDate = DateTime.Now,
                deadlineDate = AddTaskDeadline.SelectedDate.Value,
                category = ((Category)AddTaskCategory.SelectedItem).ID,
            };

            Query.Insert.Task(newTask);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void AddTaskCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
