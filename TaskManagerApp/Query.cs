using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TaskManagerApp.Config;

namespace TaskManagerApp
{
    class Query
    {

        // Wpis do bazy
        public static void InsertIntoDatabase(string query)
        {
            SqlCommand command = new SqlCommand();
            c.Open();
            command.Connection = c;
            command.CommandText = query;
            command.ExecuteNonQuery();
            c.Close();
        }


        // Lista użytkowników
        public static DataTable EmployeesList()
        {
            SqlCommand command = new SqlCommand();
            DataTable data = new DataTable();

            command.Connection = c;
            command.CommandText = "SELECT * FROM dbo.Users;";


            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);

            return data;
        }

    }
}
