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
using static TaskManagerApp.Config;

namespace TaskManagerApp
{
    /// <summary>
    /// Logika interakcji dla klasy TaskHeaderUC.xaml
    /// </summary>
    public partial class TaskHeaderUC : UserControl
    {
        public TaskHeaderUC()
        {
            InitializeComponent();
        }




        public object TaskClient
        {
            get { return (object)GetValue(TaskClientProperty); }
            set { SetValue(TaskClientProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TaskClient.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TaskClientProperty =
            DependencyProperty.Register("TaskClient", typeof(object), typeof(TaskHeaderUC), new PropertyMetadata(" "));




        public object TaskTitle
        {
            get { return (string)GetValue(TaskTitleProperty); }
            set { SetValue(TaskTitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TaskTitleProperty =
            DependencyProperty.Register("TaskTitle", typeof(object), typeof(TaskHeaderUC), new PropertyMetadata(" "));





        public object TaskTypeImage
        {
            get { return (string)GetValue(TaskTypeImageProperty); }
            set { SetValue(TaskTypeImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TaskImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TaskTypeImageProperty =
            DependencyProperty.Register("TaskTypeImage", typeof(object), typeof(TaskHeaderUC), new PropertyMetadata("QuestionMarkCircle"));

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Finish  " + this.TaskTitle);
            

        }
    }
}
