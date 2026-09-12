using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Models
{
    public class InformacoesSistema
    {
        public string NomeSistema {  get; set; }
        public string VersaoAtual {  get; set; }
        public bool ClienteAtualizado { get; set; }
        public Usuario UsuarioLogado { get; set; }

    }
}
