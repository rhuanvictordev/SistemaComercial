using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Framework
{
    public class DataFilterDateEqual : DataFilter
    {
        public DataFilterDateEqual(DateTime date)
        {
            this.Value = date;
            this.Type = "DATE_EQUAL";
        }

        public override string GetSQL(DataRecord record)
        {
            StringBuilder sb = new StringBuilder();

            DateTime date = (DateTime)this.Value;
            DateTime nextDate = date.Date.AddDays(1);

            bool first = true;

            for (int i = 0; i < record.Fields.Length; i++)
            {
                if (record.Filters[i] != null && record.Filters[i].Type == this.Type)
                {
                    if (first)
                    {
                        sb.Append($" {record.Fields[i].Name} >= '{date.Date:yyyy-MM-dd HH:mm:ss}'");
                        sb.Append($" AND {record.Fields[i].Name} < '{nextDate:yyyy-MM-dd HH:mm:ss}'");
                        first = false;
                    }
                    else
                    {
                        sb.Append($" AND {record.Fields[i].Name} >= '{date.Date:yyyy-MM-dd HH:mm:ss}'");
                        sb.Append($" AND {record.Fields[i].Name} < '{nextDate:yyyy-MM-dd HH:mm:ss}'");
                    }
                }
            }

            return sb.ToString();
        }
    }
}
