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
        public string Versao { get; set; }

        public FormBase()
        {
            InitializeComponent();
            this.Text = "Sistema Comercial";
            DefineTituloJanela();
        }

        public void DefineTituloJanela()
        {
            string arqConfig = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");

            if (File.Exists(arqConfig))
            {
                string conteudo = File.ReadAllText(arqConfig);
                ArquivoConfig config = JsonConvert.DeserializeObject<ArquivoConfig>(conteudo);
                this.Text += " v" + config.AppVersion;
            }
        }
    }
}
