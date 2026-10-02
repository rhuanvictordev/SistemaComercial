using Sistema.Data;
using Sistema.Framework;
using System;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Sistema.Models
{
    public class Usuario : DataAccess, IDataExchange
    {
        private const int FIELD_IDUSUARIO = 0;
        private const int FIELD_NOME = 1;
        private const int FIELD_EMAIL = 2;
        private const int FIELD_SENHA = 3;
        private const int FIELD_IDGRUPO = 4;
        private const int FIELD_CRIADO = 5;
        private const int FIELD_ALTERADO = 6;
        private const int FIELD_COUNT = 7;

        public long IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public long IdGrupo { get; set; }
        public DateTime Criado { get; set; }
        public DateTime Alterado { get; set; }


        public object[] ExchangeValues
        {
            get
            {
                object[] values = new object[FIELD_COUNT];
                values[FIELD_IDUSUARIO] = this.IdUsuario;
                values[FIELD_NOME] = this.Nome;
                values[FIELD_EMAIL] = this.Email;
                values[FIELD_SENHA] = this.Senha;
                values[FIELD_IDGRUPO] = this.IdGrupo;
                values[FIELD_CRIADO] = this.Criado;
                values[FIELD_ALTERADO] = this.Alterado;
                return values;
            }
            set
            {
                object[] values = value;
                this.IdUsuario = long.Parse(values[FIELD_IDUSUARIO].ToString());
                this.Nome = values[FIELD_NOME].ToString();
                this.Email = values[FIELD_EMAIL].ToString();
                this.Senha = values[FIELD_SENHA].ToString();
                this.IdGrupo = long.Parse(values[FIELD_IDGRUPO].ToString());
                this.Criado = DateTime.Parse(values[FIELD_CRIADO].ToString());
                this.Alterado = DateTime.Parse(values[FIELD_ALTERADO].ToString());
            }
        }

        public DataRecord CreateDataRecord()
        {
            return new DataRecord("USUARIOS", new DataField[]
            {
                new DataField(FIELD_IDUSUARIO, "IDUSUARIO", true),
                new DataField(FIELD_NOME, "NOME", false),
                new DataField(FIELD_EMAIL, "EMAIL", false),
                new DataField(FIELD_SENHA, "SENHA", false),
                new DataField(FIELD_IDGRUPO, "IDGRUPO", false),
                new DataField(FIELD_CRIADO, "CRIADO", false),
                new DataField(FIELD_ALTERADO, "ALTERADO", false)
            });
        }

        public bool Load(long id)
        { 
            DataRecord record = CreateDataRecord();
            record.Filters[FIELD_IDUSUARIO] = new DataFilter(FIELD_IDUSUARIO, "IDUSUARIO", id);
            record.Filters[FIELD_NOME] = new DataFilter(FIELD_NOME, "NOME", "SUPORTE");
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

        public bool Delete(string id)
        {
            using (var command = Database.Connect().CreateCommand())
            {
                command.CommandText = "DELETE FROM USUARIOS WHERE IDUSUARIO = @id";
                command.Parameters.AddWithValue("@id", id);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool Login(string email, string senha)
        {
            using (var command = Database.Connect().CreateCommand())
            {
                command.CommandText = "SELECT IDUSUARIO, NOME, EMAIL, SENHA, IDGRUPO, CRIADO, ALTERADO FROM USUARIOS WHERE EMAIL = @email AND SENHA = @senha";
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@senha", senha);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        this.IdUsuario = long.Parse(reader[0].ToString());
                        this.Nome = reader[1].ToString();
                        this.Email = reader[2].ToString();
                        this.Senha = reader[3].ToString();
                        this.IdGrupo = long.Parse(reader[4].ToString());
                        this.Criado = DateTime.Parse(reader[5].ToString());
                        this.Alterado = DateTime.Parse(reader[6].ToString());
                        return true;
                    }
                    return false;
                }
            }
        }
    }
}
