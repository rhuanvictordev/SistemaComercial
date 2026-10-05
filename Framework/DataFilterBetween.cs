using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Framework
{
    public class DataFilterBetween : DataFilter
    {
        private double StartValue { get; set; }
        private double EndValue { get; set; }

        public DataFilterBetween(double startValue, double endValue)
        {
            this.Type = "BETWEEN";
            this.StartValue = startValue;
            this.EndValue = endValue;
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
                        sb.Append($"{record.Fields[i].Name} >= {this.StartValue} AND {record.Fields[i].Name} <= {this.EndValue}");
                        first = false;
                    }
                    else
                    {
                        sb.Append($" AND {record.Fields[i].Name} >= {this.StartValue} AND {record.Fields[i].Name} <= {this.EndValue}");
                    }
                }
            }

            return sb.ToString();
        }
    }
}
