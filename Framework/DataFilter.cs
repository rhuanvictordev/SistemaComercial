using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Framework
{
    public class DataFilter
    {
        public int IndexColumn { get; set; }
        public string FilterName { get; set; }
        public object FilterValue { get; set; }

        public DataFilter(int index, string filterName, object filterValue)
        {
            this.IndexColumn = index;
            this.FilterName = filterName;
            this.FilterValue = filterValue;
        }
    }
}
