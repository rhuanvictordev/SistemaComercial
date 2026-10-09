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
    public partial class ProdutosDialog : BaseDialog
    {
        private const int COLUMN_ID = 0;
        private const int COLUMN_NOME = 1;
        private const int COLUMN_DESCRICAO = 2;
        private const int COLUMN_PRECO = 3;
        private const int COLUMN_PESO = 4;
        private const int COLUMN_IMAGEM = 5;
        private const int COLUMN_CRIADO = 6;
        private const int COLUMN_ALTERADO = 7;
        private const int COLUMN_ATIVO = 8;
        private const int COLUMN_COUNT = 9;

        public ProdutosDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProdutosInput p = new ProdutosInput();
            p.ShowDialog();
            DataShow();
        }

        private void ProdutosDialog_Load(object sender, EventArgs e)
        {
            //DataShow();
        }

        public void DataShow()
        {
            dgvProdutos.Rows.Clear();
            dgvProdutos.SuspendLayout();
            var produtos = Database.Query<Produto>();
            foreach (Produto produto in produtos)
            {
                if (!String.IsNullOrEmpty(txtNome.Text))
                    if (!produto.Nome.ToUpper().Contains(txtNome.Text.ToUpper()))
                        continue;

                var row = new object[COLUMN_COUNT];
                row[COLUMN_ID] = produto.IdProduto;
                row[COLUMN_NOME] = produto.Nome;
                row[COLUMN_DESCRICAO] = produto.Descricao;
                row[COLUMN_PRECO] = produto.Preco;
                row[COLUMN_PESO] = produto.Peso;
                row[COLUMN_IMAGEM] = produto.Imagem;
                row[COLUMN_CRIADO] = produto.Criado;
                row[COLUMN_ALTERADO] = produto.Alterado;
                row[COLUMN_ATIVO] = produto.Ativo;
                int index = dgvProdutos.Rows.Add(row);
                dgvProdutos.Rows[index].Height = 30;
            }
            dgvProdutos.ResumeLayout();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            dgvProdutos.ClearSelection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataShow();
        }
    }
}
