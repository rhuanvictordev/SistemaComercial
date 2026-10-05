using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Framework
{
    public class DataFilterEqual : DataFilter
    {
        public DataFilterEqual(object value)
        {
            this.Value = value;
            this.Type = "EQUAL";
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
                        if (record.Filters[i].Value is string)
                        {
                            sb.Append($" {record.Fields[i].Name} = '{record.Filters[i].Value}' ");
                        }
                        else
                        {
                            sb.Append($" {record.Fields[i].Name} = {record.Filters[i].Value} ");
                        }
                        first = false;
                    }
                    else
                    {
                        if (record.Filters[i].Value is string)
                        {
                            sb.Append($" AND {record.Fields[i].Name} = '{record.Filters[i].Value}' ");
                        }
                        else
                        {
                            sb.Append($" AND {record.Fields[i].Name} = {record.Filters[i].Value} ");
                        }
                    }
                }
            }

            return sb.ToString();
        }

    }
}
