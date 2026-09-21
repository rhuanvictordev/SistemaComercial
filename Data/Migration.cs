using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Database
{
    public class Migration
    {
        public int Versao { get; set; }
        public string NomeMigracao { get; set; }
        public string CommandText { get; set; }

        public Migration(int versaoMigracao, string nomeMigracao, string conteudoMigracao)
        {
            Versao = versaoMigracao;
            CommandText = conteudoMigracao;
            NomeMigracao = nomeMigracao;
        }
    }
}
