using Google.Protobuf.WellKnownTypes;
using Sistema.Data;
using Sistema.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Models
{
    public class Fornecedor : DataAccess, IDataExchange
    {
        private const int FIELD_ID = 0;
        private const int FIELD_NOME = 1;
        private const int FIELD_ESTADO = 2;
        private const int FIELD_CIDADE = 3;
        private const int FIELD_BAIRRO = 4;
        private const int FIELD_NUMERO = 5;
        private const int FIELD_CPF_CNPJ = 6;
        private const int FIELD_TELEFONE1 = 7;
        private const int FIELD_TELEFONE2 = 8;
        private const int FIELD_CRIADO = 9;
        private const int FIELD_ALTERADO = 10;
        private const int FIELD_COUNT = 11;

        public long IdFornecedor { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string CpfCnpj { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public DateTime Criado { get; set; }
        public DateTime Alterado { get; set; }
        public object[] ExchangeValues 
        {
            get 
            {
                object[] values = new object[FIELD_COUNT];
                values[FIELD_ID] = this.IdFornecedor;
                values[FIELD_NOME] = this.Nome;
                values[FIELD_ESTADO] = this.Estado;
                values[FIELD_CIDADE] = this.Cidade;
                values[FIELD_BAIRRO] = this.Bairro;
                values[FIELD_NUMERO] = this.Numero;
                values[FIELD_CPF_CNPJ] = this.CpfCnpj;
                values[FIELD_TELEFONE1] = this.Telefone1;
                values[FIELD_TELEFONE2] = this.Telefone2;
                values[FIELD_CRIADO] = this.Criado;
                values[FIELD_ALTERADO] = this.Alterado;
                return values;
            }
            set
            {
                object[] values = value;
                this.IdFornecedor = long.Parse(values[FIELD_ID].ToString());
                this.Nome = values[FIELD_NOME].ToString();
                this.Estado = values[FIELD_ESTADO].ToString();
                this.Cidade = values[FIELD_CIDADE].ToString();
                this.Bairro = values[FIELD_BAIRRO].ToString();
                this.Numero = values[FIELD_NUMERO].ToString();
                this.CpfCnpj = values[FIELD_CPF_CNPJ].ToString();
                this.Telefone1 = values[FIELD_TELEFONE1].ToString();
                this.Telefone2 = values[FIELD_TELEFONE2].ToString();
                this.Criado = Convert.ToDateTime(values[FIELD_CRIADO].ToString());
                this.Alterado = Convert.ToDateTime(values[FIELD_ALTERADO].ToString());
            }
        }

        public DataRecord CreateDataRecord()
        {
            return new DataRecord("FORNECEDORES", new DataField[]
            {
                new DataField(FIELD_ID, "IDFORNECEDOR", true),
                new DataField(FIELD_NOME, "NOME", false),
                new DataField(FIELD_ESTADO, "ESTADO", false),
                new DataField(FIELD_CIDADE, "CIDADE", false),
                new DataField(FIELD_BAIRRO, "BAIRRO", false),
                new DataField(FIELD_NUMERO, "NUMERO", false),
                new DataField(FIELD_CPF_CNPJ, "CPF_CNPJ", false),
                new DataField(FIELD_TELEFONE1, "TELEFONE1", false),
                new DataField(FIELD_TELEFONE2, "TELEFONE2", false),
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
