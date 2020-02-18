using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TaskManagerApp
{
    class Config
    {

        public static SqlConnection c = new SqlConnection("Data Source = DESKTOP-ESGOPDU\\SQLEXPRESS; Initial Catalog = TaskManager; Integrated Security = True;");


        public static List<Employee> employeesList = new List<Employee>();
        public static List<Client> clientsList = new List<Client>();
        public static List<Category> categoriesList = new List<Category>();

        public static string selectedTab = "ZADANIA";


        public class Employee
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class Client
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Priority { get; set; }
        }

        public class Category
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Icon { get; set; }
        }

        public class TaskClass
        {
            public int ID { get; set; }
            public int userID { get; set; }
            public int clientID { get; set; }
            public string title { get; set; }
            public string subtitle { get; set; }
            public DateTime createdDate { get; set; }
            public DateTime deadlineDate { get; set; }
            public int Priority { get; set; }
            public int category { get; set; }
        }
    }
}
