using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Framework
{
    public class DataFilterEqual : IDataFilterType
    {
        public object Value;

        public DataFilterEqual(object value)
        {
            Value = value;
        }
    }
}
