
namespace Sistema.Data
{
    public class Migration
    {
        public int Versao { get; set; }
        public string NomeMigracao { get; set; }
        public string CommandText { get; set; }

        public Migration(int versaoMigracao, string nomeMigracao, string conteudoMigracao)
        {
            Versao = versaoMigracao;
            CommandText = conteudoMigracao;
            NomeMigracao = nomeMigracao;
        }
    }
}
