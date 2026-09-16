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
    public abstract class ArquivoConfiguracaoDoCliente
    {
        public static ParametrosLocais LerArquivo()
        {
            try
            {
                string caminhoParams = Path.Combine(AppContext.BaseDirectory, "params.json");
                if (!File.Exists(caminhoParams))
                {
                    ParametrosLocais p = new ParametrosLocais();
                    string json = JsonSerializer.Serialize(p, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(caminhoParams, json);
                    return p;
                }
                else
                {
                    var conteudo = File.ReadAllText(caminhoParams);
                    var parametrosLocais = JsonConvert.DeserializeObject<ParametrosLocais>(conteudo);
                    parametrosLocais.CorrigeDadosNovos();
                    string json = JsonSerializer.Serialize(parametrosLocais, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(caminhoParams, json);
                    return parametrosLocais;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
