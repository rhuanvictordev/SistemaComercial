using Sistema;
using Sistema.Data;
using Sistema.Framework;
using Sistema.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.UI
{
    public partial class LoginDialog : Form
    {
        public InformacoesSistema info;

        public LoginDialog(InformacoesSistema info)
        {
            this.info = info;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario();
            if (u.Login(txtEmail.Text, txtSenha.Text))
            {
                info.UsuarioLogado = u;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuário e/ou senha inválidos", "Credenciais inválidas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.Text = info.NomeSistema + " - " + "Login";

            if (Debugger.IsAttached)
            {
                button3.Visible = true;
                txtEmail.Text = "suporte@email.com";
                txtSenha.Text = "123";
                button1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var usuarios = Database.Query<Usuario>();
            foreach (Usuario u in usuarios)
            {
                MessageBox.Show(u.Nome);
            }
        }
    }
}
