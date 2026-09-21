using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Database
{
    public static class Database
    {
        public static string CONNECTION_STRING_SERVER = "Server=localhost;Port=3306;User ID=root;Password=root;";
        public static string CONNECTION_STRING = "Server=localhost;Port=3306;Database=sistema;User ID=root;Password=root;";

        public static MySqlConnection Connect()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(CONNECTION_STRING);
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void CreateSchema()
        {
            using (var connection = new MySqlConnection(CONNECTION_STRING_SERVER))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "CREATE DATABASE IF NOT EXISTS sistema;";
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
