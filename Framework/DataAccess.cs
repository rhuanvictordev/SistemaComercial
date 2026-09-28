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
        public virtual bool Save()
        {
            return false;
        }


        public virtual bool Load()
        {
            return false;
        }

        public virtual List<T> Query<T>() where T : IDataExchange, new()
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

        public virtual void Delete(IDataExchange values)
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
