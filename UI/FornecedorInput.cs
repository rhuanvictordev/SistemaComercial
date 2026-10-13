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
    public partial class FornecedorInput : Form
    {
        public FornecedorInput()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            string estado = cboEstado.Text.Trim();
            string cidade = txtCidade.Text.Trim();
            string bairro = txtBairro.Text.Trim();
            string numero = txtNumero.Text.Trim();
            string cpfCnpj = txtCpfCnpj.Text.Trim();
            string telefone1 = txtTelefone1.Text.Trim().Replace("(  )       -", "");
            string telefone2 = txtTelefone2.Text.Trim().Replace("(  )       -", "");

            if (String.IsNullOrEmpty(nome) || String.IsNullOrEmpty(estado) || String.IsNullOrEmpty(cidade) || ( String.IsNullOrEmpty(telefone1) && String.IsNullOrEmpty(telefone2) ))
            {
                MessageBox.Show("Nome, estado, cidade e um telefone são obrigatórios!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if ((telefone1.Length != 0 && !txtTelefone1.MaskFull) || (telefone2.Length != 0 && !txtTelefone2.MaskFull))
            {
                MessageBox.Show("Verifique a digitação do telefone!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            Fornecedor f = new Fornecedor() 
            {  
                IdFornecedor = 0,
                Nome = nome,
                Estado = estado,
                Cidade = cidade,
                Bairro = bairro,
                Numero = numero,
                CpfCnpj= cpfCnpj,
                Telefone1 = telefone1,
                Telefone2 = telefone2,
                Criado = DateTime.Now,
                Alterado = DateTime.Now
            };

            //Console.WriteLine(Database.PrintObject(f.CreateDataRecord(), f));

            DbResult result = f.Save();
            if (result.Success)
            {
                MessageBox.Show("Fornecedor cadastrado com sucesso!", this.Text);
                this.Close();
            }
            else
                MessageBox.Show(result.ErrorMessage, this.Text);
        }

        private void FornecedorInput_Load(object sender, EventArgs e)
        {
            lblCriado.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblAlterado.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}
