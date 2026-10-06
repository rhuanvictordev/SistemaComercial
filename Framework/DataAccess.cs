using MySql.Data.MySqlClient;
using Sistema.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema.Framework
{
    public abstract class DataAccess // abstract porque DataAccess não pode ser instanciada, apenas herdada
    {
        public virtual bool Save()
        {
            // deve implementar o codigo na classe que herdar
            throw new NotImplementedException();
        }


        public virtual bool Load(long id)
        {
            // deve implementar o codigo na classe que herdar
            throw new NotImplementedException();
        }


        public virtual bool Delete(long id)
        {
            // deve implementar o codigo na classe que herdar
            throw new NotImplementedException();
        }

    }
}
