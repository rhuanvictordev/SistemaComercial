using Newtonsoft.Json;
using Sistema.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaComercial
{
    internal static class Program
    {
        private static string PathRaiz = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly HttpClient _httpClient = new HttpClient();

        private static string APP_KEY_NAME = "d78s56f8876dt";
        private static string BASE_URL_UPDATER = "https://rhuan.uk/updater";

        [STAThread]
        static async Task Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


#if !DEBUG  // se tiver em producao vai verificar o updater se existe na raiz e etc e se ta em dev, pula  ( DEBUG / RELEASE ) do visual studio

            #region verifica se o updater esta na raiz
            string updaterPath = Path.Combine(PathRaiz, "updater", "UPDATER.EXE");
            if (!File.Exists(updaterPath))
            {
                MessageBox.Show("Aplicação corrompida, contate o administrador.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region verifica se tem arquivo config na raiz
            string arqConfig = Path.Combine(PathRaiz, "updater", "config.json");
            string CURRENT_APP_VERSION = "";
            if (!File.Exists(arqConfig))
            {
                MessageBox.Show("Aplicação corrompida, contate o administrador.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            else
            {
                string conteudo = File.ReadAllText(arqConfig);
                ArquivoConfig config = JsonConvert.DeserializeObject<ArquivoConfig>(conteudo);
                CURRENT_APP_VERSION = config.AppVersion;
            }
            #endregion


            #region verifica se temn atualização disponivel
            var versaoServidor = await VerificarVersaoAtual(BASE_URL_UPDATER, APP_KEY_NAME);
            if (versaoServidor != "")
            {
                if (versaoServidor != CURRENT_APP_VERSION)
                {
                    Process.Start(updaterPath);
                    return;
                }
                else
                {
                    if (ClienteEmDia())
                    {
                        Application.Run(new FormBase());
                    }
                    else
                    {
                        MessageBox.Show("Sistema indisponível no momento.\nContate o administrador.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }

            }
            else // servidor pode estar inacessivel entao chama a aplicacao
            {
                Application.Run(new FormBase());
            }

            #endregion
#else
            Application.Run(new FormBase());
#endif
        }

        private static bool ClienteEmDia() // seria pra verificar no banco a ultima data que o cliente esteve online
        {
            return true;
        }


        private async static Task<string> VerificarVersaoAtual(string baseUrl, string appKeyName)
        {
            try
            {
                var obj = new { appKeyName = appKeyName };
                string json = JsonConvert.SerializeObject(obj);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{baseUrl}/CheckVersion", content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
