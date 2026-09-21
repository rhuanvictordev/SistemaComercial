using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Sistema.Services
{
    public abstract class ClientConfigHandler
    {
        private static string PARAMS_PATH = Path.Combine(AppContext.BaseDirectory, "params.json");

        public static ClientConfigValues LerArquivo()
        {
            try
            {
                if (!File.Exists(PARAMS_PATH))
                {
                    ClientConfigValues p = new ClientConfigValues();
                    string json = JsonSerializer.Serialize(p, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(PARAMS_PATH, json);
                    return p;
                }
                else
                {
                    var conteudo = File.ReadAllText(PARAMS_PATH);
                    var parametrosLocais = JsonConvert.DeserializeObject<ClientConfigValues>(conteudo);
                    parametrosLocais.CorrigeDadosNovos();
                    string json = JsonSerializer.Serialize(parametrosLocais, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(PARAMS_PATH, json);
                    return parametrosLocais;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static bool EscreverArquivo(ClientConfigValues config)
        {
            try
            {
                string json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(PARAMS_PATH, json);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

            return false;
        }
    }
}
