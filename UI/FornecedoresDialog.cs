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
        private const int COLUMN_ID = 0;
        private const int COLUMN_NOME = 1;
        private const int COLUMN_ESTADO = 2;
        private const int COLUMN_CIDADE = 3;
        private const int COLUMN_BAIRRO = 4;
        private const int COLUMN_NUMERO = 5;
        private const int COLUMN_CPF_CNPJ = 6;
        private const int COLUMN_TELEFONE1 = 7;
        private const int COLUMN_TELEFONE2 = 8;
        private const int COLUMN_CRIADO = 9;
        private const int COLUMN_ALTERADO = 10;
        private const int COLUMN_COUNT = 11;

        public FornecedoresDialog()
        {
            InitializeComponent();
        }

        public void DataShow()
        {
            var fornecedores = Database.Query<Fornecedor>();
            dgvFornecedores.Rows.Clear();
            dgvFornecedores.SuspendLayout();
            foreach (var item in fornecedores)
            {
                object[] row = new object[COLUMN_COUNT];
                row[COLUMN_ID] = item.IdFornecedor;
                row[COLUMN_NOME] = item.Nome;
                row[COLUMN_ESTADO] = item.Estado;
                row[COLUMN_CIDADE] = item.Cidade;
                row[COLUMN_BAIRRO] = item.Bairro;
                row[COLUMN_NUMERO] = item.Numero;
                row[COLUMN_CPF_CNPJ] = item.CpfCnpj;
                row[COLUMN_TELEFONE1] = item.Telefone1;
                row[COLUMN_TELEFONE2] = item.Telefone2;
                row[COLUMN_CRIADO] = item.Criado;
                row[COLUMN_ALTERADO] = item.Alterado;
                int index = dgvFornecedores.Rows.Add(row);
                dgvFornecedores.Rows[index].Height = 30;
            }
            dgvFornecedores.ResumeLayout();
            dgvFornecedores.ClearSelection();
        }

        private void FornecedoresDialog_Load(object sender, EventArgs e)
        {
            DataShow();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FornecedorInput dialog = new FornecedorInput();
            if (dialog.ShowDialog() == DialogResult.OK)
                DataShow();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataShow();
        }
    }
}
