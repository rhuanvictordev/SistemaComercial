using MySql.Data.MySqlClient;
using Mysqlx.Crud;
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

                using (var cmd = Database.Connect().CreateCommand())
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

                        cmd.Parameters.AddWithValue(
                            parameterName,
                            values.ExchangeValues[field.Index] ?? DBNull.Value
                        );
                    }

                    if (conditions.Count == 0)
                        throw new Exception("Nenhuma chave foi definida no DataRecord.");

                    cmd.CommandText =
                        $"UPDATE {record.Name} SET {string.Join(", ", sets)} " +
                        $"WHERE {string.Join(" AND ", conditions)}";

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

        public static bool Insert(DataRecord record, IDataExchange values)
        {
            try
            {
                List<string> columns = new List<string>();
                List<string> parameters = new List<string>();

                using (var cmd = Database.Connect().CreateCommand())
                {
                    foreach (DataField field in record.Fields)
                    {
                        if (field.Key)
                            continue;

                        string parameterName = $"@p{field.Index}";
                        columns.Add(field.Name);
                        parameters.Add(parameterName);
                        cmd.Parameters.AddWithValue(parameterName, values.ExchangeValues[field.Index] ?? DBNull.Value);
                    }
                    string sql = $"INSERT INTO {record.Name} ({string.Join(", ", columns)}) VALUES ({string.Join(", ", parameters)})";
                    cmd.CommandText = sql;
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

        public static bool Exists(DataRecord record, IDataExchange values)
        {
            List<string> conditions = new List<string>();

            using (var cmd = Database.Connect().CreateCommand())
            {
                foreach (DataField field in record.Fields)
                {
                    if (!field.Key)
                        continue;

                    string parameterName = $"@p{field.Index}";

                    conditions.Add($"{field.Name} = {parameterName}");

                    cmd.Parameters.AddWithValue(
                        parameterName,
                        values.ExchangeValues[field.Index] ?? DBNull.Value
                    );
                }

                if (conditions.Count == 0)
                    return false;

                cmd.CommandText = $"SELECT 1 FROM {record.Name} WHERE {string.Join(" AND ", conditions)} LIMIT 1";

                return cmd.ExecuteScalar() != null;
            }
        }


        public static object[] Load(DataRecord record)
        {
            StringBuilder sb = new StringBuilder("SELECT ");
            string finalSQL = "";

            string equalPart = "";
            string likePart = "";
            string dateEqualPart = "";
            string dateBetweenPart = "";
            string betweenPart = "";

            for (int i = 0; i < record.Fields.Length; i++)
            {
                sb.Append(record.Fields[i].Name);
                if (i < record.Fields.Length - 1)
                    sb.Append(", ");
            }
            sb.Append($" FROM {record.Name}");
            finalSQL = sb.ToString();

            for(int i = 0; i < record.Fields.Length; i++)
            {
                if (record.Filters[i] != null)
                {
                    switch (record.Filters[i].Type)
                    {
                        case "EQUAL":
                            equalPart = record.Filters[i].GetSQL(record);
                            break;

                        case "LIKE":
                            likePart = record.Filters[i].GetSQL(record);
                            break;

                        case "DATE_EQUAL":
                            dateEqualPart = record.Filters[i].GetSQL(record);
                            break;

                        case "DATE_BETWEEN":
                            dateBetweenPart = record.Filters[i].GetSQL(record);
                            break;

                        case "BETWEEN":
                            betweenPart = record.Filters[i].GetSQL(record);
                            break;

                        default:
                            break;
                    }
                }
            }

            if (equalPart != "" && likePart == "")
            {
                finalSQL += (" WHERE " + equalPart);
            }
            else if (equalPart != "" && likePart != "")
            {
                finalSQL += (" WHERE " + equalPart + " AND " + likePart);
            }

            if (dateEqualPart != "")
            {
                finalSQL += " AND " + dateEqualPart;
            }

            if (dateBetweenPart != "")
            {
                finalSQL += " AND " + dateBetweenPart;
            }

            if (betweenPart != "")
            {
                if (equalPart == "")
                {
                    finalSQL += " WHERE " + betweenPart;
                }
                else
                {
                    finalSQL += " AND " + betweenPart;
                }
            }

            try
            {
                using (var command = Connect().CreateCommand())
                {
                    command.CommandText = finalSQL;
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            object[] values = new object[record.Fields.Length];

                            for (int i = 0; i < record.Fields.Length; i++)
                            {
                                values[i] = reader[i];
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

        

        public static object[] Load(DataRecord record, long id)
        {
            object[] values = new object[record.Fields.Length];

            StringBuilder sb = new StringBuilder("SELECT ");

            for (int i = 0; i < record.Fields.Length; i++)
            {
                sb.Append(record.Fields[i].Name);

                if (i < record.Fields.Length - 1)
                    sb.Append(", ");
            }

            sb.Append($" FROM {record.Name}");

            foreach (DataField field in record.Fields)
            {
                if (field.Key)
                {
                    sb.Append($" WHERE {field.Name} = @id");
                    break;
                }
            }

            using (var connection = Database.Connect())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = sb.ToString();
                command.Parameters.AddWithValue("@id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        for (int i = 0; i < record.Fields.Length; i++)
                        {
                            values[i] = reader[i];
                        }
                    }
                }
            }

            return values;
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
