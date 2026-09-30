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
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Criado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alterado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Excluir = new System.Windows.Forms.DataGridViewButtonColumn();
            this.IdGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrupoCriado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrupoAlterado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExcluirG = new System.Windows.Forms.DataGridViewButtonColumn();
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
            this.dgvUsuarios.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgvUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Nome,
            this.Email,
            this.Grupo,
            this.Criado,
            this.Alterado,
            this.Excluir});
            this.dgvUsuarios.Location = new System.Drawing.Point(9, 43);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(508, 150);
            this.dgvUsuarios.TabIndex = 0;
            this.dgvUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellClick);
            // 
            // btnCriarUsuario
            // 
            this.btnCriarUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCriarUsuario.Location = new System.Drawing.Point(272, 228);
            this.btnCriarUsuario.Name = "btnCriarUsuario";
            this.btnCriarUsuario.Size = new System.Drawing.Size(75, 23);
            this.btnCriarUsuario.TabIndex = 1;
            this.btnCriarUsuario.Text = "Criar usuário";
            this.btnCriarUsuario.UseVisualStyleBackColor = true;
            this.btnCriarUsuario.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(201, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Grupo";
            // 
            // txtSenha
            // 
            this.txtSenha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSenha.Location = new System.Drawing.Point(50, 252);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(146, 20);
            this.txtSenha.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Senha";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtEmail.Location = new System.Drawing.Point(50, 224);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(146, 20);
            this.txtEmail.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Email";
            // 
            // txtNome
            // 
            this.txtNome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNome.Location = new System.Drawing.Point(50, 200);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(146, 20);
            this.txtNome.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nome";
            // 
            // cboGrupo
            // 
            this.cboGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboGrupo.FormattingEnabled = true;
            this.cboGrupo.Location = new System.Drawing.Point(240, 202);
            this.cboGrupo.Name = "cboGrupo";
            this.cboGrupo.Size = new System.Drawing.Size(108, 21);
            this.cboGrupo.TabIndex = 2;
            // 
            // dgvGrupos
            // 
            this.dgvGrupos.AllowUserToAddRows = false;
            this.dgvGrupos.AllowUserToDeleteRows = false;
            this.dgvGrupos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGrupos.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgvGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrupos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdGrupo,
            this.NomeGrupo,
            this.DescGrupo,
            this.GrupoCriado,
            this.GrupoAlterado,
            this.ExcluirG});
            this.dgvGrupos.Location = new System.Drawing.Point(9, 319);
            this.dgvGrupos.Name = "dgvGrupos";
            this.dgvGrupos.ReadOnly = true;
            this.dgvGrupos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrupos.Size = new System.Drawing.Size(508, 182);
            this.dgvGrupos.TabIndex = 3;
            this.dgvGrupos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrupos_CellClick);
            // 
            // txtGDescricao
            // 
            this.txtGDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtGDescricao.Location = new System.Drawing.Point(201, 510);
            this.txtGDescricao.Name = "txtGDescricao";
            this.txtGDescricao.Size = new System.Drawing.Size(224, 20);
            this.txtGDescricao.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(143, 513);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Descrição";
            // 
            // txtGNome
            // 
            this.txtGNome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtGNome.Location = new System.Drawing.Point(50, 510);
            this.txtGNome.Name = "txtGNome";
            this.txtGNome.Size = new System.Drawing.Size(89, 20);
            this.txtGNome.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 513);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Nome";
            // 
            // btnCriarGrupo
            // 
            this.btnCriarGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCriarGrupo.Location = new System.Drawing.Point(430, 508);
            this.btnCriarGrupo.Name = "btnCriarGrupo";
            this.btnCriarGrupo.Size = new System.Drawing.Size(75, 23);
            this.btnCriarGrupo.TabIndex = 1;
            this.btnCriarGrupo.Text = "Criar grupo";
            this.btnCriarGrupo.UseVisualStyleBackColor = true;
            this.btnCriarGrupo.Click += new System.EventHandler(this.btnCriarGrupo_Click);
            // 
            // dgvPermissoes
            // 
            this.dgvPermissoes.AllowUserToAddRows = false;
            this.dgvPermissoes.AllowUserToDeleteRows = false;
            this.dgvPermissoes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPermissoes.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvPermissoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermissoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdGrp,
            this.RecursoCodigo,
            this.RecursoDescricao,
            this.GrupoPermissao});
            this.dgvPermissoes.Location = new System.Drawing.Point(523, 42);
            this.dgvPermissoes.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPermissoes.Name = "dgvPermissoes";
            this.dgvPermissoes.RowTemplate.Height = 24;
            this.dgvPermissoes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPermissoes.Size = new System.Drawing.Size(398, 459);
            this.dgvPermissoes.TabIndex = 6;
            this.dgvPermissoes.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPermissoes_CellEndEdit);
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
            this.RecursoCodigo.Width = 72;
            // 
            // RecursoDescricao
            // 
            this.RecursoDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RecursoDescricao.HeaderText = "Descrição";
            this.RecursoDescricao.Name = "RecursoDescricao";
            this.RecursoDescricao.Width = 80;
            // 
            // GrupoPermissao
            // 
            this.GrupoPermissao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.GrupoPermissao.HeaderText = "Permitir";
            this.GrupoPermissao.Name = "GrupoPermissao";
            this.GrupoPermissao.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.GrupoPermissao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.GrupoPermissao.Width = 66;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.Color.SteelBlue;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(523, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(398, 30);
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
            this.label8.Size = new System.Drawing.Size(508, 30);
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
            this.label9.Location = new System.Drawing.Point(10, 284);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(508, 30);
            this.label9.TabIndex = 5;
            this.label9.Text = "Grupos";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSalvarPermissoes
            // 
            this.btnSalvarPermissoes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvarPermissoes.Location = new System.Drawing.Point(772, 507);
            this.btnSalvarPermissoes.Name = "btnSalvarPermissoes";
            this.btnSalvarPermissoes.Size = new System.Drawing.Size(148, 23);
            this.btnSalvarPermissoes.TabIndex = 1;
            this.btnSalvarPermissoes.Text = "Salvar Permissões";
            this.btnSalvarPermissoes.UseVisualStyleBackColor = true;
            this.btnSalvarPermissoes.Click += new System.EventHandler(this.btnSalvarPermissoes_Click);
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
            // ExcluirG
            // 
            this.ExcluirG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ExcluirG.HeaderText = "";
            this.ExcluirG.Name = "ExcluirG";
            this.ExcluirG.ReadOnly = true;
            this.ExcluirG.Width = 5;
            // 
            // UsuariosDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(930, 538);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UsuariosDialog";
            this.ShowIcon = false;
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
        private System.Windows.Forms.DataGridViewButtonColumn Excluir;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrupoCriado;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrupoAlterado;
        private System.Windows.Forms.DataGridViewButtonColumn ExcluirG;
    }
}