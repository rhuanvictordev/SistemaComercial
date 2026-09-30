using Sistema.Models;
using Sistema.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.UI
{
    public partial class BaseDialog : Form
    {
        public InformacoesSistema Info;
        public ClientConfigValues ParametrosLocais;
        public List<string> Menus;

        public BaseDialog()
        {
            InitializeComponent();
            Menus = new List<string>()
            {
                "menuUGP - Usuários Grupos e Permissões"
            };
        }

        public BaseDialog(InformacoesSistema i, ClientConfigValues p)
        {
            Info = i;
            ParametrosLocais = p;
            InitializeComponent();
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            if (Info == null)
                return;

            this.Text = $"{Info.NomeSistema}, Versão {Info.VersaoAtual}";

            if (!Info.ClienteAtualizado)
            {
                this.Text += " [Cliente Desatualizado]";
            }

            this.WindowState = FormWindowState.Maximized;
        }
    }
}
