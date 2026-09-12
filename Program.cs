using Newtonsoft.Json;
using Sistema.Models;
using Sistema.UI;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema
{
    internal static class Program
    {
        private static string PathRaiz = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly HttpClient _httpClient = new HttpClient();

        private static string APP_KEY_NAME = "d78s56f8876dt";
        private static string BASE_URL_UPDATER = "https://rhuan.uk/updater";

        private static ArquivoConfig config;

        [STAThread]
        static async Task Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            InformacoesSistema i = new InformacoesSistema();
            i.NomeSistema = "Sistema Comercial";
            i.VersaoAtual = "Desenvolvimento";
            i.ClienteAtualizado = true;


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
            string pathConfig = Path.Combine(PathRaiz, "updater", "config.json");
            string CURRENT_APP_VERSION = "";
            if (!File.Exists(pathConfig))
            {
                MessageBox.Show("Aplicação corrompida, contate o administrador.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            else
            {
                string conteudo = File.ReadAllText(pathConfig);
                config = JsonConvert.DeserializeObject<ArquivoConfig>(conteudo);
                CURRENT_APP_VERSION = config.AppVersion;
            }
            #endregion

            #region verifica se tem atualização disponivel e/ou abre a aplicacao
            i.VersaoAtual = config.AppVersion;
            i.ClienteAtualizado = true;

            var versaoServidor = await VerificarVersaoAtual(BASE_URL_UPDATER, APP_KEY_NAME);
            if (versaoServidor != "")
            {
                if (versaoServidor != CURRENT_APP_VERSION)
                {
                    i.ClienteAtualizado = false;
                    if (args.Contains("--updated"))  // veio do atualizador, atualizacao foi negada entao só abre o sistema
                    {
                        AbrirLogin(i);
                    }
                    else
                    {
                        Process.Start(updaterPath);
                        return;
                    }
                }
                else  // nao tem att (abre a aplicacao)
                {
                    AbrirLogin(i);
                }
            }
            else // servidor pode estar inacessivel entao abre a aplicacao
            {
                AbrirLogin(i);
            }

            #endregion
#else
            AbrirLogin(i);
#endif
        }

        public static void AbrirLogin(InformacoesSistema i)
        {
            LoginForm login = new LoginForm(i);
            if (login.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MenuForm(login.info));
            }
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
