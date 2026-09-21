
using Sistema.Models;
using Sistema.Services;
using System;
using System.Windows.Forms;

namespace Sistema.UI
{
    public partial class MenuForm : BaseForm
    {
        public MenuForm() : base()
        {
            InitializeComponent();
        }

        public MenuForm(InformacoesSistema info, ClientConfigValues p) : base(info, p)
        {
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            menuParametros.Visible = true;
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
            string senha = InputForm.Show("Informe a senha");

            if (senha == "123")
            {
                ParametrosClienteForm f = new ParametrosClienteForm();
                f.MdiParent = this;
                f.WindowState = FormWindowState.Normal;
                f.Show();
            }
        }
    }
}
