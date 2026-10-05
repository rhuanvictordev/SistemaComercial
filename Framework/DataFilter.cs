using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Framework
{
    public class DataFilter
    {
        public string Type { get; set; }   // EQUAL / LIKE / BETWEEN
        public object Value { get; set; }

        public virtual string GetSQL(DataRecord record)
        {
            // deve sobrescrever na classe que herdar
            throw new NotImplementedException();
        }
    }
}
