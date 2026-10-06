using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Sistema.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Data
{
    public static class Database
    {
        public static string connectionStringWithoutSchema = "Server=localhost;Port=3306;User ID=root;Password=root;";
        public static string connectionString = "Server=localhost;Port=3306;Database=sistema;User ID=root;Password=root;";

        public static MySqlConnection Connect()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        public static void CreateSchema()
        {
            using (var connection = new MySqlConnection(connectionStringWithoutSchema))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "CREATE DATABASE IF NOT EXISTS sistema;";
                    command.ExecuteNonQuery();
                }
            }
        }

        public static bool Save(DataRecord record, IDataExchange values)
        {
            if (Exists(record, values))
                return Update(record, values);
            else
                return Insert(record, values);
        }

        public static bool Update(DataRecord record, IDataExchange values)
        {
            try
            {
                List<string> sets = new List<string>();
                List<string> conditions = new List<string>();

                using (var connection = Connect())
                using (var command = connection.CreateCommand())
                {
                    foreach (DataField field in record.Fields)
                    {
                        string parameterName = $"@p{field.Index}";

                        if (field.Key)
                        {
                            conditions.Add($"{field.Name} = {parameterName}");
                        }
                        else
                        {
                            sets.Add($"{field.Name} = {parameterName}");
                        }

                        command.Parameters.AddWithValue( parameterName, values.ExchangeValues[field.Index] ?? DBNull.Value );
                    }

                    if (conditions.Count == 0)
                        throw new Exception("Nenhuma chave foi definida no DataRecord.");

                    command.CommandText =
                        $"UPDATE {record.Name} SET {string.Join(", ", sets)} " +
                        $"WHERE {string.Join(" AND ", conditions)}";

                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex) 
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public static bool Insert(DataRecord record, IDataExchange values)
        {
            try
            {
                List<string> columns = new List<string>();
                List<string> parameters = new List<string>();

                using (var connection = Connect())
                using (var command = connection.CreateCommand())
                {
                    foreach (DataField field in record.Fields)
                    {
                        if (field.Key)
                            continue;

                        string parameterName = $"@p{field.Index}";
                        columns.Add(field.Name);
                        parameters.Add(parameterName);
                        command.Parameters.AddWithValue(parameterName, values.ExchangeValues[field.Index] ?? DBNull.Value);
                    }
                    string sql = $"INSERT INTO {record.Name} ({string.Join(", ", columns)}) VALUES ({string.Join(", ", parameters)})";
                    command.CommandText = sql;
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex) 
            {
                Debug.WriteLine(ex);
                return false;
            }
        }


        public static bool Exists(DataRecord record, IDataExchange values)
        {
            List<string> conditions = new List<string>();

            using (var connection = Connect())
            using (var command = connection.CreateCommand())
            {
                foreach (DataField field in record.Fields)
                {
                    if (!field.Key)
                        continue;

                    string parameterName = $"@p{field.Index}";

                    conditions.Add($"{field.Name} = {parameterName}");

                    command.Parameters.AddWithValue( parameterName, values.ExchangeValues[field.Index] ?? DBNull.Value );
                }

                if (conditions.Count == 0)
                    throw new InvalidOperationException("Nenhuma chave foi definida no DataRecord.");

                command.CommandText = $"SELECT 1 FROM {record.Name} WHERE {string.Join(" AND ", conditions)} LIMIT 1";

                return command.ExecuteScalar() != null;
            }
        }


        public static object[] Load(DataRecord record)
        {
            StringBuilder sb = new StringBuilder("SELECT ");
            string finalSQL = "";

            for (int i = 0; i < record.Fields.Length; i++)
            {
                sb.Append(record.Fields[i].Name);
                if (i < record.Fields.Length - 1)
                    sb.Append(", ");
            }
            sb.Append($" FROM {record.Name}");
            finalSQL = sb.ToString();

            List<string> conditions = new List<string>();

            for (int i = 0; i < record.Fields.Length; i++)
            {
                if (record.Filters[i] != null)
                {
                    conditions.Add(record.Filters[i].GetSQL(record));
                }
            }

            if (conditions.Count > 0)
            {
                finalSQL += " WHERE " + string.Join(" AND ", conditions);
            }

            try
            {
                using (var connection = Connect())
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = finalSQL;
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            object[] values = new object[record.Fields.Length];

                            for (int i = 0; i < record.Fields.Length; i++)
                            {
                                values[i] = reader[i] == DBNull.Value ? null : reader[i];
                            }

                            return values;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            
            return null;
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
                            values[i] = reader[i] == DBNull.Value ? null : reader[i];
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
