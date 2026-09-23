using MySql.Data.MySqlClient;
using Sistema.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Data
{
    public static class Database
    {
        public static string CONNECTION_STRING_WITHOUT_SCHEMA = "Server=localhost;Port=3306;User ID=root;Password=root;";
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
            using (var connection = new MySqlConnection(CONNECTION_STRING_WITHOUT_SCHEMA))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "CREATE DATABASE IF NOT EXISTS sistema;";
                    command.ExecuteNonQuery();
                }
            }
        }

        public static List<T> Query<T>() where T : IDataExchange, new()
        {
            T model = new T();
            List<T> list = new List<T>();

            DataRecord record = model.CreateDataRecord();

            StringBuilder sb = new StringBuilder("SELECT ");

            for (int i = 0; i < record.Fields.Length; i++)
            {
                sb.Append(record.Fields[i].Name);

                if (i < record.Fields.Length - 1)
                    sb.Append(", ");
            }

            sb.Append($" FROM {record.Name}");

            using (var connection = Connect())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = sb.ToString();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        T item = new T();

                        object[] values = new object[record.Fields.Length];

                        for (int i = 0; i < record.Fields.Length; i++)
                        {
                            values[i] = reader[i];
                        }

                        item.ExchangeValues = values;

                        list.Add(item);
                    }
                }
            }

            return list;
        }
    }
}
