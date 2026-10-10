using Sistema.Data;
using Sistema.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.UI
{
    public partial class ProdutosInput : BaseDialog
    {
        Produto _produto = null;

        public ProdutosInput(Produto p)
        {
            if (p != null)
                this._produto = p;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Imagens (*.jpg;*.png)|*.jpg;*.png";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    using (var stream = File.OpenRead(dialog.FileName))
                    using (var imagem = Image.FromStream(stream))
                    {
                        Image imagemAnterior = pictureBox1.Image;
                        pictureBox1.Image = new Bitmap(imagem);
                        imagemAnterior?.Dispose();
                    }
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txtNome.Text.Trim();
                string descricao = txtDescricao.Text.Trim();
                double preco = double.Parse(txtPreco.Text.Trim());
                double pesoKG = double.Parse(txtPeso.Text.Trim());

                if (String.IsNullOrEmpty(nome) || String.IsNullOrEmpty(descricao))
                {
                    MessageBox.Show("Informe todos os campos!", "Informação");
                    return;
                }

                Produto p = new Produto() { IdProduto = this._produto == null ? 0 : this._produto.IdProduto, Nome = nome, Descricao = descricao, Preco = preco, Peso = pesoKG, Imagem = this._produto == null ? "" : this._produto.Imagem, Ativo = true, Criado = DateTime.Now, Alterado = DateTime.Now};
                if (this._produto != null)
                {
                    p.Criado = this._produto.Criado;
                    p.Alterado = DateTime.Now;
                }

                DbResult result = p.Save();
                if (!result.Success)
                    MessageBox.Show(result.ErrorMessage, "Ocorreu um erro ao tentar salvar o produto");
                else
                {
                    long id = result.IdGenerated;
                    long ImagemId = this._produto == null ? id : this._produto.IdProduto;
                    id = ImagemId;
                    if (pictureBox1.Image != null)
                    {
                        string diretorioImagens = Path.Combine(AppContext.BaseDirectory, "uploads", "images");
                        Directory.CreateDirectory(diretorioImagens);
                        string caminho = Path.Combine(diretorioImagens, $"produto_{ImagemId}.jpg");

                        if (File.Exists(caminho))
                            File.Delete(caminho);

                        pictureBox1.Image.Save(caminho, System.Drawing.Imaging.ImageFormat.Jpeg);
                        if (p.Load(id))
                        {
                            p.Imagem = $"produto_{ImagemId}.jpg";
                            p.Save();
                        }
                    }

                    MessageBox.Show("Produto salvo com sucesso", "Informação");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }

        private void ProdutosInput_Load(object sender, EventArgs e)
        {
            if (this._produto != null)
            {
                lblTitulo.Text = "Editar Produto";
                btnSalvar.Text = "Editar";
                txtNome.Text = this._produto.Nome;
                txtDescricao.Text = this._produto.Descricao;
                txtPreco.Text = this._produto.Preco.ToString();
                txtPeso.Text = this._produto.Peso.ToString();

                string caminhoImagem = Path.Combine(AppContext.BaseDirectory, "uploads", "images", this._produto.Imagem);
                if (File.Exists(caminhoImagem))
                {
                    using (var stream = File.OpenRead(caminhoImagem))
                    using (var imagem = Image.FromStream(stream))
                    {
                        pictureBox1.Image = new Bitmap(imagem);
                    }
                }
            }
        }
    }
}
