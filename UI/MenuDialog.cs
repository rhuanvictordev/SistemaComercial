
using Sistema.Models;
using Sistema.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Sistema.UI
{
    public partial class MenuDialog : BaseDialog
    {
        
        
        public MenuDialog() : base()
        {
            InitializeComponent();
        }


        public MenuDialog(InformacoesSistema info, ClientConfigValues p) : base(info, p)
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Interval = 1000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblUsuarioNome.Text = "Login: " + this.Info.UsuarioLogado.Nome + "  -  " + DateTime.Now.ToString("dd/MM/yyyy /  HH:mm:ss");
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            Grupo g = new Grupo();
            if (g.Load(this.Info.UsuarioLogado.IdGrupo))
            {
                var permissoes = g.ObterPermissoes();

                menuUGP.Enabled = permissoes.Contains("menuUGP");
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", "Confirmação", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void menuParametros_Click(object sender, EventArgs e)
        {
            string senha = InputDialog.Show("Informe a senha");

            if (senha == "123")
            {
                ParametrosDialog f = new ParametrosDialog();
                f.MdiParent = this;
                f.WindowState = FormWindowState.Normal;
                f.Show();
            }
        }

        private void cadUsuariosMenuItem_Click(object sender, EventArgs e)
        {
            AbrirMenu(typeof(UsuariosDialog));
        }

        private void AbrirMenu(Type tipo)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == tipo)
                {
                    f.BringToFront();
                    f.WindowState = FormWindowState.Maximized;
                    return;
                }
            }
            Form dialog = (Form)Activator.CreateInstance(tipo);
            dialog.MdiParent = this;
            dialog.WindowState = FormWindowState.Maximized;
            dialog.Show();
        }

        private void parâmetrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string senha = InputDialog.Show("Informe a senha");

            if (senha == "123")
            {
                ParametrosDialog f = new ParametrosDialog();
                f.MdiParent = this;
                f.WindowState = FormWindowState.Normal;
                f.Show();
            }
        }
    }
}
