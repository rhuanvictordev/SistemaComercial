using Sistema.Data;
using Sistema.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Models
{
    public class Permissao
    {
        public string Recurso { get; set; }
        public long IdGrupo { get; set; }

        public bool Save()
        {
            using (var connection = Database.Connect())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO PERMISSOES (RECURSO, IDGRUPO) VALUES (@recurso, @idGrupo)";
                command.Parameters.AddWithValue("@recurso", this.Recurso);
                command.Parameters.AddWithValue("@idGrupo", this.IdGrupo);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public void DeletePermissoesDoGrupo(string idGrupo)
        {
            using (var connection = Database.Connect())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"DELETE FROM PERMISSOES WHERE IDGRUPO = {idGrupo}";
                command.ExecuteNonQuery();
            }
        }

    }
}
