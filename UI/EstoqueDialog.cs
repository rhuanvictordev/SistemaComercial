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
    public partial class EstoqueDialog : BaseDialog
    {
        private const int COLUMN_ID = 0;
        private const int COLUMN_NOME = 1;
        private const int COLUMN_DESCRICAO = 2;
        private const int COLUMN_PRECO = 3;
        private const int COLUMN_EAN = 4;
        private const int COLUMN_QTD = 5;
        private const int COLUMN_QTD_MIN = 6;
        private const int COLUMN_IDFORNECEDOR = 7;
        private const int COLUMN_REVENDA = 8;
        private const int COLUMN_PRECO_REVENDA = 9;
        private const int COLUMN_CRIADO = 10;
        private const int COLUMN_ALTERADO = 11;
        private const int COLUMN_COUNT = 12;

        public EstoqueDialog()
        {
            InitializeComponent();
        }

        public void DataShow()
        {
            var itens = Database.Query<Estoque>();
            foreach (var item in itens)
            {
                object[] row = new object[COLUMN_COUNT];
                row[COLUMN_ID] = item.IdEstoque;
                row[COLUMN_NOME] = item.Nome;
                row[COLUMN_DESCRICAO] = item.Descricao;
                row[COLUMN_PRECO] = item.Preco;
                row[COLUMN_EAN] = item.EAN;
                row[COLUMN_QTD] = item.Qtd;
                row[COLUMN_QTD_MIN] = item.QtdMin;
                row[COLUMN_IDFORNECEDOR] = item.IdFornecedor;
                row[COLUMN_REVENDA] = item.Revenda;
                row[COLUMN_PRECO_REVENDA] = item.PrecoRevenda;
                row[COLUMN_CRIADO] = item.Criado;
                row[COLUMN_ALTERADO] = item.Alterado;
                dgvEstoque.Rows.Add(row);
            }
        }

        private void EstoqueDialog_Load(object sender, EventArgs e)
        {
            DataShow();
        }
    }
}
