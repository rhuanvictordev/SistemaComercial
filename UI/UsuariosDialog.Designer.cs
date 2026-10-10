namespace Sistema.UI
{
    partial class UsuariosDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Criado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alterado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Excluir = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnCriarUsuario = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboGrupo = new System.Windows.Forms.ComboBox();
            this.dgvGrupos = new System.Windows.Forms.DataGridView();
            this.IdGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrupoCriado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrupoAlterado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditarG = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ExcluirG = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtGDescricao = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGNome = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCriarGrupo = new System.Windows.Forms.Button();
            this.dgvPermissoes = new System.Windows.Forms.DataGridView();
            this.IdGrp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecursoCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecursoDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrupoPermissao = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSalvarPermissoes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissoes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Nome,
            this.Email,
            this.Grupo,
            this.Criado,
            this.Alterado,
            this.Editar,
            this.Excluir});
            this.dgvUsuarios.Location = new System.Drawing.Point(9, 43);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(456, 62);
            this.dgvUsuarios.TabIndex = 0;
            this.dgvUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellClick);
            // 
            // ID
            // 
            this.ID.FillWeight = 12.69035F;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 200;
            // 
            // Nome
            // 
            this.Nome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Nome.FillWeight = 12.69035F;
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            this.Nome.Width = 60;
            // 
            // Email
            // 
            this.Email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Email.FillWeight = 10F;
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 100;
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // Grupo
            // 
            this.Grupo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Grupo.FillWeight = 12.69035F;
            this.Grupo.HeaderText = "Grupo";
            this.Grupo.Name = "Grupo";
            this.Grupo.ReadOnly = true;
            this.Grupo.Width = 61;
            // 
            // Criado
            // 
            this.Criado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Criado.FillWeight = 12.69035F;
            this.Criado.HeaderText = "Criado";
            this.Criado.Name = "Criado";
            this.Criado.ReadOnly = true;
            this.Criado.Width = 62;
            // 
            // Alterado
            // 
            this.Alterado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Alterado.FillWeight = 12.69035F;
            this.Alterado.HeaderText = "Alterado";
            this.Alterado.Name = "Alterado";
            this.Alterado.ReadOnly = true;
            this.Alterado.Width = 71;
            // 
            // Editar
            // 
            this.Editar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Editar.HeaderText = "";
            this.Editar.Name = "Editar";
            this.Editar.ReadOnly = true;
            this.Editar.Width = 5;
            // 
            // Excluir
            // 
            this.Excluir.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Excluir.HeaderText = "";
            this.Excluir.Name = "Excluir";
            this.Excluir.ReadOnly = true;
            this.Excluir.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Excluir.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Excluir.Width = 19;
            // 
            // btnCriarUsuario
            // 
            this.btnCriarUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCriarUsuario.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCriarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCriarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCriarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnCriarUsuario.Location = new System.Drawing.Point(355, 139);
            this.btnCriarUsuario.Name = "btnCriarUsuario";
            this.btnCriarUsuario.Size = new System.Drawing.Size(110, 23);
            this.btnCriarUsuario.TabIndex = 4;
            this.btnCriarUsuario.Text = "Criar usuário";
            this.btnCriarUsuario.UseVisualStyleBackColor = false;
            this.btnCriarUsuario.Click += new System.EventHandler(this.btnNovoUsuario_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Grupo";
            // 
            // txtSenha
            // 
            this.txtSenha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSenha.Location = new System.Drawing.Point(50, 164);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(206, 20);
            this.txtSenha.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Senha";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtEmail.Location = new System.Drawing.Point(50, 136);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(206, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Email";
            // 
            // txtNome
            // 
            this.txtNome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNome.Location = new System.Drawing.Point(50, 112);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(206, 20);
            this.txtNome.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nome";
            // 
            // cboGrupo
            // 
            this.cboGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboGrupo.FormattingEnabled = true;
            this.cboGrupo.Location = new System.Drawing.Point(304, 112);
            this.cboGrupo.Name = "cboGrupo";
            this.cboGrupo.Size = new System.Drawing.Size(161, 21);
            this.cboGrupo.TabIndex = 3;
            // 
            // dgvGrupos
            // 
            this.dgvGrupos.AllowUserToAddRows = false;
            this.dgvGrupos.AllowUserToDeleteRows = false;
            this.dgvGrupos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGrupos.BackgroundColor = System.Drawing.Color.White;
            this.dgvGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrupos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdGrupo,
            this.NomeGrupo,
            this.DescGrupo,
            this.GrupoCriado,
            this.GrupoAlterado,
            this.EditarG,
            this.ExcluirG});
            this.dgvGrupos.Location = new System.Drawing.Point(9, 231);
            this.dgvGrupos.Name = "dgvGrupos";
            this.dgvGrupos.ReadOnly = true;
            this.dgvGrupos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrupos.Size = new System.Drawing.Size(456, 182);
            this.dgvGrupos.TabIndex = 3;
            this.dgvGrupos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrupos_CellClick);
            // 
            // IdGrupo
            // 
            this.IdGrupo.HeaderText = "IdGrupo";
            this.IdGrupo.Name = "IdGrupo";
            this.IdGrupo.ReadOnly = true;
            this.IdGrupo.Visible = false;
            // 
            // NomeGrupo
            // 
            this.NomeGrupo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NomeGrupo.HeaderText = "Nome";
            this.NomeGrupo.Name = "NomeGrupo";
            this.NomeGrupo.ReadOnly = true;
            this.NomeGrupo.Width = 60;
            // 
            // DescGrupo
            // 
            this.DescGrupo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DescGrupo.HeaderText = "Descrição";
            this.DescGrupo.Name = "DescGrupo";
            this.DescGrupo.ReadOnly = true;
            this.DescGrupo.Width = 80;
            // 
            // GrupoCriado
            // 
            this.GrupoCriado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.GrupoCriado.HeaderText = "Criado";
            this.GrupoCriado.Name = "GrupoCriado";
            this.GrupoCriado.ReadOnly = true;
            this.GrupoCriado.Width = 62;
            // 
            // GrupoAlterado
            // 
            this.GrupoAlterado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.GrupoAlterado.HeaderText = "Alterado";
            this.GrupoAlterado.Name = "GrupoAlterado";
            this.GrupoAlterado.ReadOnly = true;
            this.GrupoAlterado.Width = 71;
            // 
            // EditarG
            // 
            this.EditarG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.EditarG.HeaderText = "";
            this.EditarG.Name = "EditarG";
            this.EditarG.ReadOnly = true;
            this.EditarG.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EditarG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.EditarG.Width = 19;
            // 
            // ExcluirG
            // 
            this.ExcluirG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ExcluirG.HeaderText = "";
            this.ExcluirG.Name = "ExcluirG";
            this.ExcluirG.ReadOnly = true;
            this.ExcluirG.Width = 5;
            // 
            // txtGDescricao
            // 
            this.txtGDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtGDescricao.Location = new System.Drawing.Point(238, 422);
            this.txtGDescricao.Name = "txtGDescricao";
            this.txtGDescricao.Size = new System.Drawing.Size(198, 20);
            this.txtGDescricao.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(177, 425);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Descrição";
            // 
            // txtGNome
            // 
            this.txtGNome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtGNome.Location = new System.Drawing.Point(50, 422);
            this.txtGNome.Name = "txtGNome";
            this.txtGNome.Size = new System.Drawing.Size(121, 20);
            this.txtGNome.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 425);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Nome";
            // 
            // btnCriarGrupo
            // 
            this.btnCriarGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCriarGrupo.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCriarGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCriarGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCriarGrupo.ForeColor = System.Drawing.Color.White;
            this.btnCriarGrupo.Location = new System.Drawing.Point(442, 422);
            this.btnCriarGrupo.Name = "btnCriarGrupo";
            this.btnCriarGrupo.Size = new System.Drawing.Size(110, 23);
            this.btnCriarGrupo.TabIndex = 7;
            this.btnCriarGrupo.Text = "Criar grupo";
            this.btnCriarGrupo.UseVisualStyleBackColor = false;
            this.btnCriarGrupo.Click += new System.EventHandler(this.btnCriarGrupo_Click);
            // 
            // dgvPermissoes
            // 
            this.dgvPermissoes.AllowUserToAddRows = false;
            this.dgvPermissoes.AllowUserToDeleteRows = false;
            this.dgvPermissoes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPermissoes.BackgroundColor = System.Drawing.Color.White;
            this.dgvPermissoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermissoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdGrp,
            this.RecursoCodigo,
            this.RecursoDescricao,
            this.GrupoPermissao});
            this.dgvPermissoes.Location = new System.Drawing.Point(470, 42);
            this.dgvPermissoes.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPermissoes.Name = "dgvPermissoes";
            this.dgvPermissoes.RowTemplate.Height = 24;
            this.dgvPermissoes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPermissoes.Size = new System.Drawing.Size(321, 371);
            this.dgvPermissoes.TabIndex = 6;
            // 
            // IdGrp
            // 
            this.IdGrp.HeaderText = "Grupo";
            this.IdGrp.Name = "IdGrp";
            this.IdGrp.Visible = false;
            // 
            // RecursoCodigo
            // 
            this.RecursoCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RecursoCodigo.HeaderText = "Recurso";
            this.RecursoCodigo.Name = "RecursoCodigo";
            this.RecursoCodigo.Visible = false;
            // 
            // RecursoDescricao
            // 
            this.RecursoDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RecursoDescricao.HeaderText = "Menu";
            this.RecursoDescricao.Name = "RecursoDescricao";
            // 
            // GrupoPermissao
            // 
            this.GrupoPermissao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.GrupoPermissao.HeaderText = "Ativar";
            this.GrupoPermissao.Name = "GrupoPermissao";
            this.GrupoPermissao.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.GrupoPermissao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.GrupoPermissao.Width = 59;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.Color.SteelBlue;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(470, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(321, 30);
            this.label7.TabIndex = 5;
            this.label7.Text = "Permissões";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BackColor = System.Drawing.Color.SteelBlue;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(10, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(455, 30);
            this.label8.TabIndex = 5;
            this.label8.Text = "Usuários";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.BackColor = System.Drawing.Color.SteelBlue;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(10, 196);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(455, 30);
            this.label9.TabIndex = 5;
            this.label9.Text = "Grupos";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSalvarPermissoes
            // 
            this.btnSalvarPermissoes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvarPermissoes.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSalvarPermissoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvarPermissoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvarPermissoes.ForeColor = System.Drawing.Color.White;
            this.btnSalvarPermissoes.Location = new System.Drawing.Point(642, 419);
            this.btnSalvarPermissoes.Name = "btnSalvarPermissoes";
            this.btnSalvarPermissoes.Size = new System.Drawing.Size(148, 23);
            this.btnSalvarPermissoes.TabIndex = 8;
            this.btnSalvarPermissoes.Text = "Salvar Permissões";
            this.btnSalvarPermissoes.UseVisualStyleBackColor = false;
            this.btnSalvarPermissoes.Click += new System.EventHandler(this.btnSalvarPermissoes_Click);
            // 
            // UsuariosDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvPermissoes);
            this.Controls.Add(this.txtGDescricao);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtGNome);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.btnSalvarPermissoes);
            this.Controls.Add(this.btnCriarGrupo);
            this.Controls.Add(this.dgvGrupos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.btnCriarUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboGrupo);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UsuariosDialog";
            this.Text = "Usuários Grupos e Permissões";
            this.Load += new System.EventHandler(this.UsuariosDialog_Load);
            this.Click += new System.EventHandler(this.UsuariosDialog_Click);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrupos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissoes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Button btnCriarUsuario;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboGrupo;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvGrupos;
        private System.Windows.Forms.TextBox txtGDescricao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGNome;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCriarGrupo;
        private System.Windows.Forms.DataGridView dgvPermissoes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSalvarPermissoes;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdGrp;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecursoCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecursoDescricao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn GrupoPermissao;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Criado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alterado;
        private System.Windows.Forms.DataGridViewButtonColumn Editar;
        private System.Windows.Forms.DataGridViewButtonColumn Excluir;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrupoCriado;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrupoAlterado;
        private System.Windows.Forms.DataGridViewButtonColumn EditarG;
        private System.Windows.Forms.DataGridViewButtonColumn ExcluirG;
    }
}