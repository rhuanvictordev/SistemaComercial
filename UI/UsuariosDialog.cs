using Sistema.Data;
using Sistema.Models;
using System;
using System.Windows.Forms;

namespace Sistema.UI
{
    public partial class UsuariosDialog : BaseDialog
    {
        private const int COLUMN_USUARIO_ID = 0;
        private const int COLUMN_USUARIO_NOME = 1;
        private const int COLUMN_USUARIO_EMAIL = 2;
        private const int COLUMN_USUARIO_GRUPO = 3;
        private const int COLUMN_USUARIO_CRIADO = 4;
        private const int COLUMN_USUARIO_ALTERADO = 5;
        private const int COLUMN_USUARIO_COUNT = 6;

        private const int COLUMN_GRUPO_ID = 0;
        private const int COLUMN_GRUPO_NOME = 1;
        private const int COLUMN_GRUPO_DESCRICAO = 2;
        private const int COLUMN_GRUPO_CRIADO = 3;
        private const int COLUMN_GRUPO_ALTERADO = 4;
        private const int COLUMN_GRUPO_COUNT = 5;

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
            var grupos = Database.Query<Grupo>();

            dgvUsuarios.Rows.Clear();
            dgvGrupos.Rows.Clear();

            object[] rowG = new object[COLUMN_GRUPO_COUNT];
            cboGrupo.Items.Clear();
            foreach (var g in grupos)
            {
                rowG[COLUMN_GRUPO_ID] = g.IdGrupo;
                rowG[COLUMN_GRUPO_NOME] = g.Nome;
                rowG[COLUMN_GRUPO_DESCRICAO] = g.Descricao;
                rowG[COLUMN_GRUPO_CRIADO] = g.Criado;
                rowG[COLUMN_GRUPO_ALTERADO] = g.Alterado;
                int index = dgvGrupos.Rows.Add(rowG);
                cboGrupo.Items.Add(g.Nome);
            }

            object[] row = new object[COLUMN_USUARIO_COUNT];
            foreach (var u in usuarios)
            {
                Grupo g = new Grupo();
                row[COLUMN_USUARIO_ID] = u.IdUsuario;
                row[COLUMN_USUARIO_NOME] = u.Nome;
                row[COLUMN_USUARIO_EMAIL] = u.Email;
                row[COLUMN_USUARIO_GRUPO] = u.IdGrupo;
                
                if (g.Load(u.IdGrupo))
                    row[COLUMN_USUARIO_GRUPO] = g.Nome;

                row[COLUMN_USUARIO_CRIADO] = u.Criado;
                row[COLUMN_USUARIO_ALTERADO] = u.Alterado;
                int index = dgvUsuarios.Rows.Add(row);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario() { Nome = txtNome.Text, Email = txtEmail.Text, Senha = txtSenha.Text, IdGrupo = 1, Criado = DateTime.Now, Alterado = DateTime.Now };
            if (u.Save())
            {
                MessageBox.Show("Usuário cadastrado com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Erro ao salvar o usuário", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvGrupos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvGrupos.Rows[e.RowIndex];
            txtNome.Text = row.Cells[COLUMN_USUARIO_NOME].Value.ToString();
            txtEmail.Text = row.Cells[COLUMN_USUARIO_EMAIL].Value.ToString();
            
        }

        private void btnCriarGrupo_Click(object sender, EventArgs e)
        {
            Grupo g = new Grupo() { Nome = txtGNome.Text, Descricao = txtGDescricao.Text, Criado = DateTime.Now, Alterado = DateTime.Now };
            if (g.Save())
            { 
                MessageBox.Show("Grupo cadastrado com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvUsuarios.Rows[e.RowIndex];
            txtNome.Text = row.Cells[COLUMN_USUARIO_NOME].Value.ToString();
            txtEmail.Text = row.Cells[COLUMN_USUARIO_EMAIL].Value.ToString();
            cboGrupo.Text = row.Cells[COLUMN_USUARIO_GRUPO].Value.ToString();
        }
    }
}
