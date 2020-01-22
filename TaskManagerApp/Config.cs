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

    }
}
