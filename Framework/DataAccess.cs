using MySql.Data.MySqlClient;
using Sistema.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema.Framework
{
    public class DataAccess
    {
        public void Update(DataRecord record, IDataExchange values)
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

                cmd.ExecuteNonQuery();
            }
        }

        public void Save(DataRecord dataRecord, IDataExchange values)
        {
            DataRecord record = values.CreateDataRecord();

            if (Exists(record, values))
                Update(record, values);
            else
                Insert(record, values);
        }

        public bool Exists(DataRecord record, IDataExchange values)
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
                    throw new Exception("Nenhuma chave foi definida no DataRecord.");

                cmd.CommandText = $"SELECT 1 FROM {record.Name} WHERE {string.Join(" AND ", conditions)} LIMIT 1";

                return cmd.ExecuteScalar() != null;
            }
        }

        public void Insert(DataRecord record, IDataExchange values)
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
                cmd.ExecuteNonQuery();
            }
        }

        public bool Load(IDataExchange values)
        {
            DataRecord record = values.CreateDataRecord();

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
                    throw new Exception("Nenhuma chave foi definida no DataRecord.");

                cmd.CommandText =
                    $"SELECT {string.Join(", ", record.Fields.Select(f => f.Name))} " +
                    $"FROM {record.Name} WHERE {string.Join(" AND ", conditions)} LIMIT 1";

                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        return false;

                    object[] exchangeValues = new object[record.Fields.Length];

                    foreach (DataField field in record.Fields)
                    {
                        exchangeValues[field.Index] =
                            reader[field.Name] == DBNull.Value ? null : reader[field.Name];
                    }

                    values.ExchangeValues = exchangeValues;

                    return true;
                }
            }
        }

        public List<T> Query<T>() where T : IDataExchange, new()
        {
            T model = new T();
            DataRecord record = model.CreateDataRecord();

            List<T> result = new List<T>();

            using (var cmd = Database.Connect().CreateCommand())
            {
                cmd.CommandText =
                    $"SELECT {string.Join(", ", record.Fields.Select(f => f.Name))} " +
                    $"FROM {record.Name}";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        T item = new T();

                        object[] exchangeValues = new object[record.Fields.Length];

                        foreach (DataField field in record.Fields)
                        {
                            exchangeValues[field.Index] =
                                reader[field.Name] == DBNull.Value ? null : reader[field.Name];
                        }

                        item.ExchangeValues = exchangeValues;

                        result.Add(item);
                    }
                }
            }

            return result;
        }

        public void Delete(IDataExchange values)
        {
            DataRecord record = values.CreateDataRecord();

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
                    throw new Exception("Nenhuma chave foi definida no DataRecord.");

                cmd.CommandText =
                    $"DELETE FROM {record.Name} WHERE {string.Join(" AND ", conditions)}";

                cmd.ExecuteNonQuery();
            }
        }
    }
}
