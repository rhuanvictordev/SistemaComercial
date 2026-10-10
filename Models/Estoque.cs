using Sistema.Data;
using Sistema.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Models
{
    public class Estoque : DataAccess, IDataExchange
    {
        private const int FIELD_ID = 0;
        private const int FIELD_NOME = 1;
        private const int FIELD_DESCRICAO = 2;
        private const int FIELD_PRECO = 3;
        private const int FIELD_EAN = 4;
        private const int FIELD_QTD = 5;
        private const int FIELD_QTD_MIN = 6;
        private const int FIELD_IDFORNECEDOR = 7;
        private const int FIELD_REVENDA = 8;
        private const int FIELD_PRECO_REVENDA = 9;
        private const int FIELD_CRIADO = 10;
        private const int FIELD_ALTERADO = 11;
        private const int FIELD_COUNT = 12;

        public long IdEstoque { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Preco { get; set; }
        public string EAN { get; set; }
        public double Qtd { get; set; }
        public double QtdMin { get; set; }
        public long IdFornecedor { get; set; }
        public bool Revenda { get; set; }
        public double PrecoRevenda { get; set; }
        public DateTime Criado  { get; set; }
        public DateTime Alterado { get; set; }


        public object[] ExchangeValues 
        { 
            get 
            {
                object[] values = new object[FIELD_COUNT];
                values[FIELD_ID] = IdEstoque;
                values[FIELD_NOME] = Nome;
                values[FIELD_DESCRICAO] = Descricao;
                values[FIELD_PRECO] = Preco;
                values[FIELD_EAN] = EAN;
                values[FIELD_QTD] = Qtd;
                values[FIELD_QTD_MIN] = QtdMin;
                values[FIELD_IDFORNECEDOR] = IdFornecedor;
                values[FIELD_REVENDA] = Revenda;
                values[FIELD_PRECO_REVENDA] = PrecoRevenda;
                values[FIELD_CRIADO] = Criado;
                values[FIELD_ALTERADO] = Alterado;
                return values;
            }
            set
            {
                object[] values = value;
                this.IdEstoque = long.Parse(values[FIELD_ID].ToString());
                this.Nome = values[FIELD_NOME].ToString();
                this.Descricao = values[FIELD_DESCRICAO].ToString();
                this.Preco = values[FIELD_PRECO].ToString();
                this.EAN = values[FIELD_EAN].ToString();
                this.Qtd = double.Parse(values[FIELD_QTD].ToString());
                this.QtdMin = double.Parse(values[FIELD_QTD].ToString());
                this.IdFornecedor = long.Parse(values[FIELD_IDFORNECEDOR].ToString());
                this.Revenda = values[FIELD_REVENDA].ToString() == "S" ? true : false;
                this.PrecoRevenda = double.Parse(values[FIELD_PRECO_REVENDA].ToString());
                this.Criado = Convert.ToDateTime(values[FIELD_CRIADO].ToString());
                this.Alterado = Convert.ToDateTime(values[FIELD_ALTERADO].ToString());
            }
        }

        public DataRecord CreateDataRecord()
        {
            return new DataRecord("ESTOQUE", new DataField[]
            {
                new DataField(FIELD_ID, "IDESTOQUE", true),
                new DataField(FIELD_NOME, "NOME", false),
                new DataField(FIELD_DESCRICAO, "DESCRICAO", false),
                new DataField(FIELD_PRECO, "PRECO", false),
                new DataField(FIELD_EAN, "EAN", false),
                new DataField(FIELD_QTD, "QTD", false),
                new DataField(FIELD_QTD_MIN, "QTD_MIN", false),
                new DataField(FIELD_IDFORNECEDOR, "IDFORNECEDOR", false),
                new DataField(FIELD_REVENDA, "REVENDA", false),
                new DataField(FIELD_PRECO_REVENDA, "PRECO_REVENDA", false),
                new DataField(FIELD_CRIADO, "CRIADO", false),
                new DataField(FIELD_ALTERADO, "ALTERADO", false)
            });
        }

        public override bool Load(long id)
        {
            DataRecord record = CreateDataRecord();
            record.Filters[FIELD_ID] = new DataFilterEqual(id);
            object[] values = Database.Load(record);
            if (values != null)
                this.ExchangeValues = values;

            return values != null;
        }

        public override DbResult Save()
        {
            return Database.Save(CreateDataRecord(), this);
        }
    }
}
