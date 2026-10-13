using Sistema.Data;
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
    public partial class FornecedoresDialog : BaseDialog
    {
        

        public FornecedoresDialog()
        {
            InitializeComponent();
        }

        public void DataShow()
        {
            
        }

        private void EstoqueDialog_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EstoqueInput dialog = new EstoqueInput();
            dialog.ShowDialog();
        }
    }
}
