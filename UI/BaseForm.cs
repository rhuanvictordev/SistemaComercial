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
            
        }

        public BaseForm(InformacoesSistema i)
        {
            Info = i;
            InitializeComponent();
            this.Text = $"Sistema Comercial, Versão {Info.VersaoAtual} ";
        }
    }
}
