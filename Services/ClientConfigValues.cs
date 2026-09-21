using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Services
{
    public class ClientConfigValues
    {
        public string CNPJ { get; set; }
        public string ChaveCliente { get; set; }
        public bool UsarDesconto { get; set; }
        public double ValorDesconto { get; set; }

        public void CorrigeDadosNovos()
        {
            this.CNPJ = CNPJ == null ? "" : CNPJ;
            this.ChaveCliente = ChaveCliente == null ? "" : ChaveCliente;
        }

    }
}
