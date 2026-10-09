using Sistema.Data;
using Sistema.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Models
{
    public class Produto : DataAccess, IDataExchange
    {
        private const int FIELD_IDPRODUTO = 0;
        private const int FIELD_NOME = 1;
        private const int FIELD_DESCRICAO = 2;
        private const int FIELD_PRECO = 3;
        private const int FIELD_PESO = 4;
        private const int FIELD_IMAGEM = 5;
        private const int FIELD_CRIADO = 6;
        private const int FIELD_ALTERADO = 7;
        private const int FIELD_ATIVO = 8;
        private const int FIELD_COUNT = 9;

        public long IdProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco {  get; set; }
        public double Peso { get; set; }
        public string Imagem { get; set; }
        public DateTime Criado { get; set; }
        public DateTime Alterado { get; set; }
        public bool Ativo { get; set; }

        public object[] ExchangeValues
        {
            get 
            {
                object[] values = new object[FIELD_COUNT];
                values[FIELD_IDPRODUTO] = this.IdProduto;
                values[FIELD_NOME] = this.Nome;
                values[FIELD_DESCRICAO] = this.Descricao;
                values[FIELD_PRECO] = this.Preco;
                values[FIELD_PESO] = this.Peso;
                values[FIELD_IMAGEM] = this.Imagem;
                values[FIELD_CRIADO] = this.Criado;
                values[FIELD_ALTERADO] = this.Alterado;
                values[FIELD_ATIVO] = this.Ativo;
                return values;
            }
            set
            {
                object[] values = value;
                this.IdProduto = long.Parse(values[FIELD_IDPRODUTO].ToString());
                this.Nome = values[FIELD_NOME].ToString();
                this.Descricao = values[FIELD_DESCRICAO] == null ? "" : values[FIELD_DESCRICAO].ToString();
                this.Preco = double.Parse(values[FIELD_PRECO].ToString());
                this.Peso = double.Parse(values[FIELD_PESO].ToString());
                this.Criado = Convert.ToDateTime(values[FIELD_CRIADO].ToString());
                this.Alterado = Convert.ToDateTime(values[FIELD_ALTERADO].ToString());
                this.Imagem = values[FIELD_IMAGEM].ToString();
                this.Ativo = values[FIELD_ATIVO].ToString() == "S" ? true : false;
            }
        }

        public DataRecord CreateDataRecord()
        {
            return new DataRecord("PRODUTOS", new DataField[]
            {
                new DataField(FIELD_IDPRODUTO, "IDPRODUTO", true),
                new DataField(FIELD_NOME, "NOME", false),
                new DataField(FIELD_DESCRICAO, "DESCRICAO", false),
                new DataField(FIELD_PRECO, "PRECO", false),
                new DataField(FIELD_PESO, "PESO_KG", false),
                new DataField(FIELD_IMAGEM, "IMAGEM", false),
                new DataField(FIELD_CRIADO, "CRIADO", false),
                new DataField(FIELD_ALTERADO, "ALTERADO", false),
                new DataField(FIELD_ATIVO, "ATIVO", false),
            });
        }

        public override bool Load(long id)
        {
            DataRecord record = CreateDataRecord();
            record.Filters[FIELD_IDPRODUTO] = new DataFilterEqual(id);
            object[] values = Database.Load(record);
            if (values != null)
                this.ExchangeValues = values;
            
            return values != null;   
        }

        public override bool Save()
        {
            DataRecord record = CreateDataRecord();
            return Database.Save(record, this);
        }
    }
}
