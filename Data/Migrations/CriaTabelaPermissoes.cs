using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Data.Migrations
{
    public class CriaTabelaPermissoes
    {
        public static string MigrationNome = "CriaTBPermissoes";

        public static string Conteudo()
        {
            return 

            @"CREATE TABLE PERMISSOES(
            RECURSO VARCHAR(50) NOT NULL,
            DESCRICAO VARCHAR(100) NOT NULL,
            IDGRUPO INT NOT NULL,
            FOREIGN KEY (IDGRUPO) REFERENCES GRUPO_USUARIO (IDGRUPO),
            CONSTRAINT UK_PERMISSAO UNIQUE (RECURSO, IDGRUPO)
            );";
        }
    }
}
