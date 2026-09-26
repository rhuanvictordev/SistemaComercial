using Sistema.Data;
using Sistema.Models;
using System;
using System.Windows.Forms;

namespace Sistema.UI
{
    public partial class UsuariosDialog : BaseForm
    {
        private const int COLUMN_ID = 0;
        private const int COLUMN_NOME = 1;
        private const int COLUMN_EMAIL = 2;
        private const int COLUMN_SENHA = 3;
        private const int COLUMN_GRUPO = 4;
        private const int COLUMN_CRIADO = 5;
        private const int COLUMN_ALTERADO = 6;
        private const int COLUMN_COUNT = 7;

        public UsuariosDialog()
        {
            InitializeComponent();
        }

        private void UsuariosDialog_Load(object sender, EventArgs e)
        {
            DataShow();
        }

        public void DataShow()
        {
            var usuarios = Database.Query<Usuario>();

            dataGridView1.Rows.Clear();

            object[] row = new object[COLUMN_COUNT];
            foreach (var u in usuarios)
            {
                for (int i = 0; i < 2; i++)
                {
                    row[COLUMN_ID] = u.IdUsuario;
                    row[COLUMN_NOME] = u.Nome;
                    row[COLUMN_EMAIL] = u.Email;
                    row[COLUMN_SENHA] = u.Senha;
                    row[COLUMN_GRUPO] = u.IdGrupo;
                    row[COLUMN_CRIADO] = u.Criado;
                    row[COLUMN_ALTERADO] = u.Alterado;
                    int index = dataGridView1.Rows.Add(row);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            txtNome.Text = row.Cells[COLUMN_NOME].Value.ToString();
            txtEmail.Text = row.Cells[COLUMN_EMAIL].Value.ToString();
            txtSenha.Text = row.Cells[COLUMN_SENHA].Value.ToString();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario() { Nome = txtNome.Text, Email = txtEmail.Text, Senha = txtSenha.Text, IdGrupo = 1, Criado = DateTime.Now, Alterado = DateTime.Now };
            u.Save();
        }
    }
}
