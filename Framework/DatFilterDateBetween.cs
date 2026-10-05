using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Framework
{
    public class DataFilterDateBetween : DataFilter
    {
        private DateTime ValueInicial;
        private DateTime ValueFinal;

        public DataFilterDateBetween(DateTime dateInicial, DateTime dateFinal)
        {
            this.ValueInicial = dateInicial;
            this.ValueFinal = dateFinal;
            this.Type = "DATE_BETWEEN";
        }

        public override string GetSQL(DataRecord record)
        {
            StringBuilder sb = new StringBuilder();

            bool first = true;
            for (int i = 0; i < record.Fields.Length; i++)
            {
                if (record.Filters[i] != null && record.Filters[i].Type == this.Type)
                {
                    if (first)
                    {
                        sb.Append($" {record.Fields[i].Name} BETWEEN '{ValueInicial:yyyy-MM-dd HH:mm:ss}' AND '{ValueFinal:yyyy-MM-dd HH:mm:ss}'");
                        first = false;
                    }
                    else
                    {
                        sb.Append($" AND {record.Fields[i].Name} BETWEEN '{ValueInicial:yyyy-MM-dd HH:mm:ss}' AND '{ValueFinal:yyyy-MM-dd HH:mm:ss}'");
                    }
                }
            }

            return sb.ToString();
        }
    }
}
