using Sistema.Data;
using Sistema.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Models
{
    public class Permissao : DataAccess, IDataExchange
    {
        private const int FIELD_RECURSO = 0;
        private const int FIELD_DESCRICAO = 1;
        private const int FIELD_IDGRUPO = 2;
        private const int FIELD_COUNT = 3;

        public string Recurso { get; set; }
        public string Descricao { get; set; }
        public long IdGrupo { get; set; }

        public object[] ExchangeValues 
        {
            get
            {
                object[] values = new object[FIELD_COUNT];
                values[FIELD_RECURSO] = this.Recurso;
                values[FIELD_DESCRICAO] = this.Descricao;
                values[FIELD_IDGRUPO] = this.IdGrupo;
                return values;
            }
            set
            {
                object[] values = value;
                this.Recurso = values[FIELD_RECURSO].ToString();
                this.Descricao = values[FIELD_DESCRICAO].ToString();
                this.IdGrupo = long.Parse(values[FIELD_IDGRUPO].ToString());
            }
        }

        public DataRecord CreateDataRecord()
        {
            return new DataRecord("PERMISSOES", new DataField[]
            { 
                new DataField(FIELD_RECURSO, "RECURSO", false),
                new DataField(FIELD_DESCRICAO, "DESCRICAO", false),
                new DataField(FIELD_IDGRUPO, "IDGRUPO", false)
            });
        }

        public void DeletePermissoesDoGrupo(string idGrupo)
        {
            using (var command = Database.Connect().CreateCommand())
            {
                command.CommandText = $"DELETE FROM PERMISSOES WHERE IDGRUPO = {idGrupo}";
                command.ExecuteNonQuery();
            }
        }
    }
}
