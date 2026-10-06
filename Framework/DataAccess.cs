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
        public abstract bool Save(); //abstract: apenas declaro a assinatura na classe pai, a implementação virá obrigatoriamente na classe filha


        public abstract bool Load(long id); //abstract: apenas declaro a assinatura na classe pai, a implementação virá obrigatoriamente na classe filha


        public virtual bool Delete(long id) //virtual: passo um comportamento padrão na classe pai mas uma classe filha pode sobrescrever
        {
            // throw new NotImplementedException();
            return false;
        }
    }
}
