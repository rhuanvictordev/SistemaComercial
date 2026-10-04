using Sistema.Data;
using Sistema.Models;
using System;
using System.Collections.Generic;
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
        private const int COLUMN_USUARIO_EXCLUIR = 6;
        private const int COLUMN_USUARIO_COUNT = 7;

        private const int COLUMN_GRUPO_ID = 0;
        private const int COLUMN_GRUPO_NOME = 1;
        private const int COLUMN_GRUPO_DESCRICAO = 2;
        private const int COLUMN_GRUPO_CRIADO = 3;
        private const int COLUMN_GRUPO_ALTERADO = 4;
        private const int COLUMN_GRUPO_EXCLUIR = 5;
        private const int COLUMN_GRUPO_COUNT = 6;

        private const int COLUMN_PERMISSAO_IDGRUPO = 0;
        private const int COLUMN_PERMISSAO_RECURSO = 1;
        private const int COLUMN_PERMISSAO_DESCRICAO = 2;
        private const int COLUMN_PERMISSAO_ATIVAR = 3;
        private const int COLUMN_PERMISSAO_COUNT = 4;

        private bool isEditingUser = false;
        private bool isEditingGroup = false;

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

            dgvUsuarios.Rows.Clear(); dgvUsuarios.SuspendLayout();
            dgvGrupos.Rows.Clear(); dgvGrupos.SuspendLayout();

            object[] rowG = new object[COLUMN_GRUPO_COUNT];
            cboGrupo.Items.Clear();
            foreach (var g in grupos)
            {
                /*if (g.Nome.ToUpper() == "SUPORTE")
                    continue;*/

                rowG[COLUMN_GRUPO_ID] = g.IdGrupo;
                rowG[COLUMN_GRUPO_NOME] = g.Nome;
                rowG[COLUMN_GRUPO_DESCRICAO] = g.Descricao;
                rowG[COLUMN_GRUPO_CRIADO] = g.Criado;
                rowG[COLUMN_GRUPO_ALTERADO] = g.Alterado;
                rowG[COLUMN_GRUPO_EXCLUIR] = "Excluir";
                int index = dgvGrupos.Rows.Add(rowG);
                cboGrupo.Items.Add($"{g.IdGrupo}-{g.Nome}");
            }

            object[] row = new object[COLUMN_USUARIO_COUNT];
            foreach (var u in usuarios)
            {
                /*if (u.Nome.ToUpper() == "SUPORTE")
                    continue;*/

                Grupo g = new Grupo();
                row[COLUMN_USUARIO_ID] = u.IdUsuario;
                row[COLUMN_USUARIO_NOME] = u.Nome;
                row[COLUMN_USUARIO_EMAIL] = u.Email;
                row[COLUMN_USUARIO_GRUPO] = "";

                if (g.Load(u.IdGrupo))
                    row[COLUMN_USUARIO_GRUPO] = $"{g.IdGrupo}-{g.Nome}";

                row[COLUMN_USUARIO_CRIADO] = u.Criado;
                row[COLUMN_USUARIO_ALTERADO] = u.Alterado;
                row[COLUMN_USUARIO_EXCLUIR] = "Excluir";
                int index = dgvUsuarios.Rows.Add(row);
                dgvUsuarios.Rows[index].Height = 30;
            }

            dgvGrupos.ResumeLayout(); dgvUsuarios.ClearSelection();
            dgvUsuarios.ResumeLayout(); dgvGrupos.ClearSelection();
            dgvPermissoes.Rows.Clear();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.Trim();
            string email = txtEmail.Text.Trim();
            string senha = txtSenha.Text.Trim();
            string idGrupo = cboGrupo.Text.Split('-')[0].Trim();
            long idUserSelected = String.IsNullOrEmpty(lblUsuarioID.Text) ? 0 : long.Parse(lblUsuarioID.Text);

            if (String.IsNullOrEmpty(nome) || String.IsNullOrEmpty(email) || String.IsNullOrEmpty(senha) || String.IsNullOrEmpty(idGrupo))
            {
                MessageBox.Show("Informe todos os campos", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Usuario u = new Usuario() { IdUsuario = idUserSelected, Nome = nome, Email = email, Senha = senha, IdGrupo = long.Parse(idGrupo), Criado = DateTime.Now, Alterado = DateTime.Now };
            if (u.Load(""))
            { 
                
            }
            
            
            if (u.Save())
            {
                if (isEditingUser)
                    MessageBox.Show("Usuário editado com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Usuário criado com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Erro ao criar/alterar o usuário\nTalvez já exista um usuário com esse email!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            LimpaCamposUsuario();
            DataShow();
        }

        private void dgvGrupos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvGrupos.Rows[e.RowIndex];
            txtGNome.Text = row.Cells[COLUMN_GRUPO_NOME].Value.ToString();
            txtGDescricao.Text = row.Cells[COLUMN_GRUPO_DESCRICAO].Value.ToString();

            string idGrupo = row.Cells[COLUMN_GRUPO_ID].Value.ToString();
            Grupo grupo = new Grupo() { IdGrupo = long.Parse(idGrupo) };
            var permissoesDoGrupo = grupo.ObterPermissoes();

            dgvPermissoes.Rows.Clear();
            foreach (var menu in this.Menus)
            {
                var rowP = new object[COLUMN_PERMISSAO_COUNT];
                rowP[COLUMN_PERMISSAO_IDGRUPO] = idGrupo;
                rowP[COLUMN_PERMISSAO_RECURSO] = menu.Split('-')[0].Trim();
                rowP[COLUMN_PERMISSAO_DESCRICAO] = menu.Split('-')[1].Trim();
                rowP[COLUMN_PERMISSAO_ATIVAR] = permissoesDoGrupo.Contains(menu.Split('-')[0].Trim());
                dgvPermissoes.Rows.Add(rowP);
            }

            if (e.ColumnIndex == COLUMN_GRUPO_EXCLUIR)
            {
                if (MessageBox.Show("Confirma a exclusão desse grupo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    grupo.Delete();
                }
                DataShow();
            }
        }

        private void btnCriarGrupo_Click(object sender, EventArgs e)
        {
            string nome = txtGNome.Text.Trim();
            string descricao = txtGDescricao.Text.Trim();

            if (String.IsNullOrEmpty(nome) || String.IsNullOrEmpty(descricao))
            {
                MessageBox.Show("Digite todos os campos","Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            Grupo g = new Grupo() { Nome = nome, Descricao = descricao, Criado = DateTime.Now, Alterado = DateTime.Now };
            if (g.Save())
                MessageBox.Show("Grupo cadastrado com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Erro ao salvar o grupo\nTalvez já exista um grupo com esse nome!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            LimpaCamposGrupo();
            DataShow();
        }

        public void LimpaCamposUsuario()
        {
            txtNome.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtSenha.Text = String.Empty;
            cboGrupo.Text = String.Empty;
            btnCriarUsuario.Text = "Criar usuário";
            isEditingUser = false;
        }

        public void LimpaCamposGrupo()
        {
            txtGNome.Text = String.Empty;
            txtGDescricao.Text = String.Empty;
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvUsuarios.Rows[e.RowIndex];
            txtNome.Text = row.Cells[COLUMN_USUARIO_NOME].Value.ToString();
            txtEmail.Text = row.Cells[COLUMN_USUARIO_EMAIL].Value.ToString();
            cboGrupo.Text = row.Cells[COLUMN_USUARIO_GRUPO].Value.ToString();
            lblUsuarioID.Text = row.Cells[COLUMN_USUARIO_ID].Value.ToString();
            btnCriarUsuario.Text = "Editar";
            isEditingUser = true;
           
            if (e.ColumnIndex == COLUMN_USUARIO_EXCLUIR)
            {
                if (MessageBox.Show("Confirma a exclusão desse usuário?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string id = row.Cells[COLUMN_USUARIO_ID].Value.ToString();
                    Usuario u = new Usuario();
                    u.Delete(id);
                    DataShow();
                }
            }
        }

        private void UsuariosDialog_Click(object sender, EventArgs e)
        {
            dgvUsuarios.ClearSelection();
            dgvGrupos.ClearSelection();
        }

        private void btnSalvarPermissoes_Click(object sender, EventArgs e)
        {
            if (dgvPermissoes.Rows.Count < 0)
                return;

            string idGrupo = dgvPermissoes.Rows[0].Cells[COLUMN_PERMISSAO_IDGRUPO].Value.ToString();
            Permissao p = new Permissao();
            p.DeletePermissoesDoGrupo(idGrupo);
            dgvPermissoes.EndEdit();
            foreach (DataGridViewRow row in dgvPermissoes.Rows)
            {
                bool ativar = (bool)row.Cells[COLUMN_PERMISSAO_ATIVAR].Value;
                string recurso = row.Cells[COLUMN_PERMISSAO_RECURSO].Value.ToString();
                if (ativar)
                {
                    p.Recurso = recurso;
                    p.IdGrupo = long.Parse(idGrupo);
                    p.Save();
                }
            }
            MessageBox.Show("Permissões do grupo atualizadas com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataShow();
        }
    }
}
