using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Updater.Model;

namespace Updater.Service
{
    public abstract class CriarArquivoConfig
    {
        public static bool CriarArquivo()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
                if (!File.Exists(path))
                {
                    //var programa = new Programa("nenhum", "nenhum", "nenhum", "nenhum", "nenhum");
                    //string programaJson = JsonSerializer.Serialize(programa, new JsonSerializerOptions { WriteIndented = true });
                    ArquivoConfig arquivo = new ArquivoConfig("1.0");
                    string programaJson = JsonSerializer.Serialize(arquivo, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(path, programaJson);
                }
                return true;
            }
            catch (Exception ex)

            {
                throw new Exception("Erro ao criar o arquivo config.json");
            }
        }

        public static bool SalvarConfig(Programa programa)
        {
            try
            {
                ArquivoConfig arquivo = new ArquivoConfig(programa.AppVersion);
                string arquivoLocal = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
                string json = JsonSerializer.Serialize(arquivo, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(arquivoLocal, json);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar o arquivo config.json");
            }
        }
    }
}
