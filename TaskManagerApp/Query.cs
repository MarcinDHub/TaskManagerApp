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
            c.Close();

            return data;
        }


        // Lista klientów
        public static DataTable ClientsList()
        {
            SqlCommand command = new SqlCommand();
            DataTable data = new DataTable();

            command.Connection = c;
            command.CommandText = "SELECT * FROM dbo.Clients ORDER BY name;";


            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            c.Close();

            return data;
        }

        // Lista kategorii
        public static DataTable CategoriesList()
        {
            SqlCommand command = new SqlCommand();
            DataTable data = new DataTable();

            command.Connection = c;
            command.CommandText = "SELECT * FROM dbo.Category ORDER BY name;";


            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            c.Close();

            return data;
        }

        // List zadań
        public static DataTable TaskList()
        {
            SqlCommand command = new SqlCommand();
            DataTable data = new DataTable();

            command.Connection = c;
            command.CommandText = "SELECT * FROM dbo.Tasks ;";

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            c.Close();
            return data;
        }





        // WPISY DO BAZY DANYCH
        public class Insert
        {
            public static void Task(TaskClass task)
            {
                SqlCommand command = new SqlCommand();
                c.Open();
                command.Connection = c;

                string query = String.Format("INSERT INTO dbo.Tasks VALUES ({0}, {1}, '{2}', '{3}', '{4}', '{5}', {6});",
                    task.userID,
                    task.clientID,
                    task.title,
                    task.subtitle,
                    task.createdDate.ToString("yyyy/MM/dd HH:mm"),
                    task.deadlineDate.ToString("yyyy/MM/dd HH:mm"),
                    task.category);

                command.CommandText = query;
                command.ExecuteNonQuery();
                c.Close();
            }
        }

    }
}
