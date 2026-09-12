using Newtonsoft.Json;
using Sistema.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaComercial
{
    public partial class FormBase : Form
    {
        public string VersaoSistema { get; set; }
        public bool CLIENTE_DESATUALIZADO { get; set; }

        public FormBase(bool clienteDesatualizado, string versao)
        {
            InitializeComponent();
            CLIENTE_DESATUALIZADO = clienteDesatualizado;
            VersaoSistema = versao;
            DefineTituloJanela();
        }

        public void DefineTituloJanela()
        {
            this.Text = $"Sistema Comercial - v{VersaoSistema}";
            if (CLIENTE_DESATUALIZADO)
            {
                this.Text += "  -  [ CLIENTE DESATUALIZADO, NECESSÁRIO ATUALIZAR ]";
            }
        }
    }
}
