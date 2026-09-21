using Sistema;
using Sistema.Models;
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
    public partial class LoginForm : Form
    {
        public InformacoesSistema info;

        public LoginForm(InformacoesSistema info)
        {
            this.info = info;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            info.UsuarioLogado = new Usuario() { Nome = textBox1.Text };
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.Text = info.NomeSistema + " - " +  info.VersaoAtual ;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
