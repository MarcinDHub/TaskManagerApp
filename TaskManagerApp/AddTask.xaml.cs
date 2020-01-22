﻿using System;
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
        }

        private void AddTaskCreate_Click(object sender, RoutedEventArgs e)
        {
            string q = null;
            

            InsertIntoDatabase(q);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
