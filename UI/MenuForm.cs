
using Sistema.Models;
using System;

namespace Sistema.UI
{
    public partial class MenuForm : BaseForm
    {
        public MenuForm(InformacoesSistema info) : base(info)
        {
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            label2.Text = base.Info.UsuarioLogado.Nome;
        }
    }
}
