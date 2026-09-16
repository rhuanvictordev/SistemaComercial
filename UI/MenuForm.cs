
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

        public MenuForm(InformacoesSistema info, ParametrosLocais p) : base(info, p)
        {
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", "Confirmação", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
