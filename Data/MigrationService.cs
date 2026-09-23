using Sistema.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Sistema.Data
{
    public static class MigrationService
    {


        public static List<Migration> Migrations = new List<Migration>()
        {
            new Migration(1, "CRIACAO DO BANCO", CriaBanco.Conteudo())
        };



        public static void RunMigrations()
        {
            Database.CreateSchema();
            int dbVersion = ObterVersaoAtual();

            Migrations = Migrations.OrderBy(m => m.Versao).ToList();

            foreach (Migration m in Migrations)
            {
                if (dbVersion < m.Versao)
                {
                    ExecuteMigration(m);
                    dbVersion = m.Versao;
                }
            }
        }

        public static void ExecuteMigration(Migration m)
        {
            MessageBox.Show($"Executando Migração: {m.NomeMigracao}");
            using (var connection = Database.Connect())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (var command = connection.CreateCommand())
                        {
                            command.Transaction = transaction;
                            command.CommandText = m.CommandText;
                            command.ExecuteNonQuery();
                            command.CommandText = @"INSERT INTO DB_MIGRATIONS (NOME, EXECUTADO, VERSAO_DB) VALUES (@nome, @data, @versao)";
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@nome", m.NomeMigracao);
                            command.Parameters.AddWithValue("@data", DateTime.Now);
                            command.Parameters.AddWithValue("@versao", m.Versao);
                            command.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public static int ObterVersaoAtual()
        {
            string sql = @"CREATE TABLE IF NOT EXISTS DB_MIGRATIONS ( ID INT AUTO_INCREMENT PRIMARY KEY, NOME VARCHAR(255) NOT NULL, EXECUTADO DATETIME NOT NULL, VERSAO_DB INT NOT NULL );";
            using (var command = Database.Connect().CreateCommand())
            {
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }

            using (var command = Database.Connect().CreateCommand())
            {
                command.CommandText = @"SELECT COALESCE(MAX(VERSAO_DB), 0) FROM DB_MIGRATIONS;";
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
    }
}
