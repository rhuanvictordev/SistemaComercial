using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.UI
{
    public partial class ProdutosInput : BaseDialog
    {
        public ProdutosInput()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Thread.CurrentThread.GetApartmentState().ToString());
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Imagens (*.jpg;*.png)|*.jpg;*.png";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.FileName;
                MessageBox.Show(path);
            }
        }
    }
}
