using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
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
using static TaskManagerApp.Config;

namespace TaskManagerApp
{
    /// <summary>
    /// Logika interakcji dla klasy Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();

            try
            {
                c.Open();
                MessageBox.Show("Połączono");
            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;

            var macAddr = (from nic in NetworkInterface.GetAllNetworkInterfaces()
                            where nic.OperationalStatus == OperationalStatus.Up
                            select nic.GetPhysicalAddress().ToString()
                            ).FirstOrDefault();
            Console.WriteLine(macAddr);
            if (isValid)
            {

                LoadUserList();
                LoadClientList();


                foreach (Employee item in employeesList)
                {
                    Console.WriteLine(item.FirstName + " " + item.LastName);
                }

                foreach (Client item in clientsList)
                {
                    Console.WriteLine(item.Name + " " + item.Priority);
                }

                Hide();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            else
            {

            }


        }

        private void LoadUserList()
        {
            DataTable employeesTable = new DataTable();
            employeesTable = Query.EmployeesList();

            foreach (DataRow dr in employeesTable.Rows)
            {
                employeesList.Add(new Employee { ID = Convert.ToInt32(dr[0]), FirstName = dr[1].ToString(), LastName = dr[2].ToString() });
            }
        }


        private void LoadClientList()
        {
            DataTable clientsTable = new DataTable();
            clientsTable = Query.ClientsList();

            foreach (DataRow dr in clientsTable.Rows)
            {
                clientsList.Add(new Client { ID = Convert.ToInt32(dr[0]), Name = dr[1].ToString(), Priority = Convert.ToInt32(dr[2]) });
            }
        }


    }
}
