using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Updater.Model
{
    public class ArquivoConfig
    {
        public string AppVersion { get; set; }

        public ArquivoConfig(string version)
        {
            AppVersion = version;
        }
    }
}
