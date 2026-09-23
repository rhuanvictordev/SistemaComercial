using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Framework
{
    public class DataField
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public bool Key {  get; set; }

        public DataField(int Index, string Name, bool Key)
        {
            this.Index = Index;
            this.Name = Name;
            this.Key = Key;
        }
    }
}
