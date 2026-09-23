using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Framework
{
    public class DataRecord
    {
        public string Name { get; set; }
        public DataField[] Fields { get; set; }

        public DataRecord(string RecordName, DataField[] RecordFields)
        {
            Name = RecordName;
            Fields = RecordFields;
        }
    }
}
