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
    public partial class BaseForm : Form
    {
        public InformacoesSistema Info;

        public BaseForm()
        {
            InitializeComponent();
        }

        public BaseForm(InformacoesSistema i)
        {
            Info = i;
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
        }
    }
}
