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
    public partial class InputForm : Form
    {
        public string Valor { get; private set; }

        private InputForm(string title)
        {
            InitializeComponent();
            lblTitle.Text = title;
        }

        public static string Show(string title)
        {
            using (InputForm form = new InputForm(title))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    return form.txtValor.Text;

                return string.Empty;
            }
        }

        private void txtValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
