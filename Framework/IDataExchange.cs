using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Framework
{
    public interface IDataExchange
    {
        object[] ExchangeValues { get; set; }
        DataRecord CreateDataRecord();
    }
}
