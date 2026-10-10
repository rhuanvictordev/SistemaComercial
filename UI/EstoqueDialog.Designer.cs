namespace Sistema.UI
{
    partial class EstoqueDialog
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
            this.label8 = new System.Windows.Forms.Label();
            this.dgvEstoque = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Preco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtdMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdFornecedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Revenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecoRevenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Criado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alterado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstoque)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BackColor = System.Drawing.Color.SteelBlue;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(776, 30);
            this.label8.TabIndex = 7;
            this.label8.Text = "Estoque";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvEstoque
            // 
            this.dgvEstoque.AllowUserToAddRows = false;
            this.dgvEstoque.AllowUserToDeleteRows = false;
            this.dgvEstoque.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEstoque.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgvEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstoque.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Nome,
            this.Descricao,
            this.Preco,
            this.EAN,
            this.QTD,
            this.QtdMin,
            this.IdFornecedor,
            this.Revenda,
            this.PrecoRevenda,
            this.Criado,
            this.Alterado});
            this.dgvEstoque.Location = new System.Drawing.Point(12, 42);
            this.dgvEstoque.Name = "dgvEstoque";
            this.dgvEstoque.Size = new System.Drawing.Size(776, 396);
            this.dgvEstoque.TabIndex = 8;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // Nome
            // 
            this.Nome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.Width = 60;
            // 
            // Descricao
            // 
            this.Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.Width = 80;
            // 
            // Preco
            // 
            this.Preco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Preco.HeaderText = "Preço";
            this.Preco.Name = "Preco";
            this.Preco.Width = 60;
            // 
            // EAN
            // 
            this.EAN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.EAN.HeaderText = "EAN";
            this.EAN.Name = "EAN";
            this.EAN.Width = 54;
            // 
            // QTD
            // 
            this.QTD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.QTD.HeaderText = "Qtd";
            this.QTD.Name = "QTD";
            this.QTD.Width = 49;
            // 
            // QtdMin
            // 
            this.QtdMin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.QtdMin.HeaderText = "Qtd min";
            this.QtdMin.Name = "QtdMin";
            this.QtdMin.Width = 68;
            // 
            // IdFornecedor
            // 
            this.IdFornecedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.IdFornecedor.HeaderText = "Fornecedor";
            this.IdFornecedor.Name = "IdFornecedor";
            this.IdFornecedor.Width = 86;
            // 
            // Revenda
            // 
            this.Revenda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Revenda.HeaderText = "Revender?";
            this.Revenda.Name = "Revenda";
            this.Revenda.Width = 85;
            // 
            // PrecoRevenda
            // 
            this.PrecoRevenda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PrecoRevenda.HeaderText = "Preço Revenda";
            this.PrecoRevenda.Name = "PrecoRevenda";
            this.PrecoRevenda.Width = 98;
            // 
            // Criado
            // 
            this.Criado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Criado.HeaderText = "Criado";
            this.Criado.Name = "Criado";
            this.Criado.Width = 62;
            // 
            // Alterado
            // 
            this.Alterado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Alterado.HeaderText = "Alterado";
            this.Alterado.Name = "Alterado";
            this.Alterado.Width = 71;
            // 
            // EstoqueDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvEstoque);
            this.Controls.Add(this.label8);
            this.Name = "EstoqueDialog";
            this.Text = "Produtos em estoque";
            this.Load += new System.EventHandler(this.EstoqueDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstoque)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvEstoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Preco;
        private System.Windows.Forms.DataGridViewTextBoxColumn EAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTD;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtdMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdFornecedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Revenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecoRevenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Criado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alterado;
    }
}