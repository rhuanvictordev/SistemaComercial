using Sistema.Services;
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
    public partial class ParametrosClienteForm : Form
    {
        ClientConfigValues values;
        public ParametrosClienteForm()
        {
            InitializeComponent();
            values = ClientConfigHandler.LerArquivo();
        }

        private void ParametrosClienteForm_Load(object sender, EventArgs e)
        {
            txtCNPJ.Text = values.CNPJ;
            txtChave.Text = values.ChaveCliente;
            checkBox1.Checked = values.UsarDesconto;
            numericUpDown1.Value = (int)values.ValorDesconto;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            values.CNPJ = txtCNPJ.Text;
            values.ChaveCliente = txtChave.Text;
            values.UsarDesconto = checkBox1.Checked;
            values.ValorDesconto = (int)numericUpDown1.Value;

            if (ClientConfigHandler.EscreverArquivo(values) == true)
            {
                MessageBox.Show("Parâmetros alterados com sucesso!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocorreu um erro ao tentar salvar os parâmetros");
            }
            
        }
    }
}
