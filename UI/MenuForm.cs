
using Sistema.Models;
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

        public MenuForm(InformacoesSistema info) : base(info)
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
