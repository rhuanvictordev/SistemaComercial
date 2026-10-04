using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Framework
{
    public class DataFilterLike : IDataFilter
    {
        public DataFilterLike(object value)
        {
            this.Value = value;
        }

        public override string GetSQL(DataRecord record)
        {
            string retorno = "";
            for (int i = 0; i < record.Fields.Length; i++)
            {
                if (record.Filters[i] != null)
                    retorno = $" WHERE {record.Fields[i].Name} LIKE '%{record.Filters[i].Value}%'";
            }
            return retorno;
        }

    }
}
