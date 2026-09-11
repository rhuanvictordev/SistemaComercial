using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Updater.Model;
using Updater.Service;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Updater
{
    public partial class Atualizador : Form
    {
        private readonly HttpClient _httpClient;
        private Programa _programa;
        private string _raizUpdater = AppDomain.CurrentDomain.BaseDirectory;
        private string novaVersao = "";

        public Atualizador()
        {
            _httpClient = new HttpClient();
            _programa = new Programa("Sistema Comercial", "d78s56f8876dt", "0", "https://rhuan.uk/updater", "Sistema.exe"); // todas as variaveis só precisam ser definidas aqui
            InitializeComponent();
            CarregaVersao();
            notificarUI("Consultando Servidor", "Verificando Atualização");
        }


        public void CarregaVersao()
        {
            try
            {
                string arquivoConfigJson = Path.Combine(_raizUpdater, "config.json");
                if (!File.Exists(arquivoConfigJson))
                {
                    MessageBox.Show("Ocorreeu um erro ao iniciar a aplicação.\nContate o administrador.", $"{_programa.AppName} - Atualizador", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    Application.Exit();
                    return;
                }
                var conteudo = File.ReadAllText(arquivoConfigJson);
                var config = JsonConvert.DeserializeObject<ArquivoConfig>(conteudo);
                if (config != null)
                {
                    _programa.AppVersion = config.AppVersion;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro", ex.Message);
                Application.Exit();
            }
        }


        public void notificarUI(string logMessage, string infoMessage)
        {
            lblLog.Text = !logMessage.Equals(String.Empty) ? $"{logMessage}..." : lblLog.Text;
            lblInfo.Text = !infoMessage.Equals(String.Empty) ? infoMessage : lblInfo.Text;
        }


        private async void Atualizador_Load(object sender, EventArgs e)
        {
            lblNomeSistema.Text = $"{_programa.AppName}   [ Atualizador ]";
            string versaoRecebida = await VerificarVersaoAtual(_programa.BaseApiURL, _programa.AppKeyName);

            if (versaoRecebida == "")
            {
                IniciarAplicacao(true); // finge que ta atualizado porque o servidor de att esta inacessivel
                return;
            }

            if (versaoRecebida != _programa.AppVersion)
            {
                MatarAplicacao();
                novaVersao = versaoRecebida;
                var choice = MessageBox.Show("Atualizar agora?", $"{_programa.AppName} - [Atualização Disponível]", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                //var choice = MessageBox.Show("O sistema será atualizado.", $"{_programa.AppName} - [Atualização Disponível]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (choice == DialogResult.OK)
                {
                    notificarUI("", "Baixando Atualização");
                    progressBar1.Visible = true;
                    await BaixarArquivo();
                    ExtrairArquivo();
                }
                else
                {
                    IniciarAplicacao(true); // finge que ta atualizado porque o cliente negou a atualizacao
                }
            }
            else {
                IniciarAplicacao(true);  // aqui é porque ta atualizado mesmo
            }
        }


        public void MatarAplicacao()
        {
            foreach (Process processo in Process.GetProcessesByName(_programa.ExeName.Replace(".exe","")))
            {
                try
                {
                    processo.Kill();
                    processo.WaitForExit();
                }
                catch (Exception ex){}
                finally
                {
                    processo.Dispose();
                }
            }
        }

        private async Task BaixarArquivo()
        {
            string pastaTemp = Path.Combine(_raizUpdater, "temp");
            Directory.CreateDirectory(pastaTemp);
            string caminhoPacote = Path.Combine(pastaTemp, "package.zip");

            using (HttpResponseMessage response = await _httpClient.GetAsync($"{_programa.BaseApiURL}/Download/{_programa.AppKeyName}", HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();
                var totalBytes = response.Content.Headers.ContentLength;
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    using (var fileStream = new FileStream(caminhoPacote, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        byte[] buffer = new byte[65536];
                        long totalRead = 0;
                        int bytesRead;
                        int lastProgress = 0;

                        while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            await fileStream.WriteAsync(buffer, 0, bytesRead);
                            totalRead += bytesRead;

                            if (totalBytes.HasValue)
                            {
                                int progress = (int)((totalRead * 100) / totalBytes.Value);
                                if (progress != lastProgress)
                                {
                                    notificarUI($"Baixando Arquivos {progress}%", "");
                                    progressBar1.Value = progress;
                                    lastProgress = progress;
                                }
                            }
                        }

                        progressBar1.Value = 100;
                    }
                }
            }

        }


        private void ExtrairArquivo()
        {
            notificarUI("Extraindo", "Instalando...");

            try
            {
                string arquivoZip = Path.Combine(_raizUpdater, "temp", "package.zip");
                if (!File.Exists(arquivoZip))
                {
                    throw new Exception("Arquivo Compactado não encontrado");
                }
                else
                {
                    using (ZipArchive archive = ZipFile.OpenRead(arquivoZip))
                    {
                        foreach (var entry in archive.Entries)
                        {
                            string raizUpdater = Directory.GetParent(AppContext.BaseDirectory).FullName;
                            string raizSistema = Directory.GetParent(raizUpdater).FullName;
                            string destino = Path.Combine(raizSistema, entry.FullName);
                            string pasta = Path.GetDirectoryName(destino);
                            if (!Directory.Exists(pasta))
                                Directory.CreateDirectory(pasta);

                            if (!string.IsNullOrEmpty(entry.Name))
                            {
                                entry.ExtractToFile(destino, true);
                            }
                        }
                    }

                    notificarUI("Extração Completa", "Finalizando");

                    string pastaTemp = Path.Combine(_raizUpdater, "temp");
                    if (Directory.Exists(pastaTemp))
                        Directory.Delete(pastaTemp, true);
                       
                    _programa.AppVersion = novaVersao;
                    bool salvo = CriarArquivoConfig.SalvarConfig(_programa);
                    if (!salvo)
                    {
                        MessageBox.Show("Ocorreu um erro ao escrever a nova versão", "Informação");
                    }
                    IniciarAplicacao(true);  // o programa acabou de ser atualizado, entao esta atualizado sim
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocorreu um erro");
                Application.Exit();
            }
        }


        private void IniciarAplicacao(bool atualizado)
        {
            MatarAplicacao();  // mata caso esteja aberta

            string pastaUpdater = Directory.GetParent(_raizUpdater).FullName;
            string raizSistema = Directory.GetParent(pastaUpdater).FullName;
            string arquivoExecutavel = Path.Combine(raizSistema, _programa.ExeName);

            if (File.Exists(arquivoExecutavel))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = arquivoExecutavel,
                    Arguments = atualizado ? "--updated" : "--update",
                    UseShellExecute = true
                });
            }
            else {
                MessageBox.Show("Ocorreu um erro ao iniciar a aplicação.\nContate o administrador.", $"{_programa.AppName} - Atualizador", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Application.Exit();
        }



        private async Task<string> VerificarVersaoAtual(string baseUrl, string appKeyName)
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

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
