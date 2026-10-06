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
            // deve implementar o codigo na classe que herdar
            throw new NotImplementedException();
        }


        public virtual bool Load(long id)
        {
            // deve implementar o codigo na classe que herdar
            throw new NotImplementedException();
        }


        public virtual bool Delete(long id)
        {
            // deve implementar o codigo na classe que herdar
            throw new NotImplementedException();
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
                            exchangeValues[field.Index] = reader[field.Name] == DBNull.Value ? null : reader[field.Name];
                        }

                        item.ExchangeValues = exchangeValues;

                        result.Add(item);
                    }
                }
            }

            return result;
        }
    }
}
