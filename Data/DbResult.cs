using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Data
{
    public class DbResult
    {
        public bool Success { get; set; }
        public long IdGenerated { get; set; }
        public string ErrorMessage { get; set; }
        public object Value { get; set; }
    }
}
