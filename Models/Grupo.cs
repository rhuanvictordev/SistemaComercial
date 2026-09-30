using Sistema.Data;
using Sistema.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Models
{
    public class Grupo : DataAccess, IDataExchange
    {
        private const int FIELD_IDGRUPO = 0;
        private const int FIELD_NOME = 1;
        private const int FIELD_DESCRICAO = 2;
        private const int FIELD_CRIADO = 3;
        private const int FIELD_ALTERADO = 4;
        private const int FIELD_COUNT = 5;

        public long IdGrupo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime Criado { get; set; }
        public DateTime Alterado { get; set; }
        public List<string> PermissoesCodes { get; set; }

        public Grupo()
        {
            PermissoesCodes = new List<string>();
        }

        public object[] ExchangeValues 
        {
            get 
            {
                object[] values = new object[FIELD_COUNT];
                values[FIELD_IDGRUPO] = IdGrupo;
                values[FIELD_NOME] = Nome;
                values[FIELD_DESCRICAO] = Descricao;
                values[FIELD_CRIADO] = Criado;
                values[FIELD_ALTERADO] = Alterado;
                return values;
            }
            set 
            {
                object[] values = value;
                this.IdGrupo = long.Parse(values[FIELD_IDGRUPO].ToString());
                this.Nome = (string)values[FIELD_NOME];
                this.Descricao = (string)values[FIELD_DESCRICAO];
                this.Criado = Convert.ToDateTime(values[FIELD_CRIADO]);
                this.Alterado = Convert.ToDateTime(values[FIELD_ALTERADO]);
            } 
        }

        public bool Load(long id)
        {
            DataRecord record = CreateDataRecord();
            object[] values = Database.Load(record, id);
            this.ExchangeValues = values;
            return values != null;
        }

        public override bool Save()
        {
            DataRecord record = CreateDataRecord();
            return Database.Save(record, this);
        }


        public bool Delete()
        {
            using (var command = Database.Connect().CreateCommand())
            {
                command.CommandText = "DELETE FROM GRUPO_USUARIO WHERE IDGRUPO = @id";
                command.Parameters.AddWithValue("@id", this.IdGrupo);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public List<string> ObterPermissoes()
        { 
            List<string> result = new List<string>();

            using (var command = Database.Connect().CreateCommand())
            {
                command.CommandText = $"SELECT RECURSO FROM PERMISSOES WHERE IDGRUPO = {this.IdGrupo}";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader[0].ToString());
                    }
                }
            }

            return result;
        }

        public DataRecord CreateDataRecord()
        {
            return new DataRecord("GRUPO_USUARIO", new DataField[]
            {
                new DataField(FIELD_IDGRUPO, "IDGRUPO", true),
                new DataField(FIELD_NOME, "NOME", false),
                new DataField(FIELD_DESCRICAO, "DESCRICAO", false),
                new DataField(FIELD_CRIADO, "CRIADO", false),
                new DataField(FIELD_ALTERADO, "ALTERADO", false)
            });
        }
    }
}
