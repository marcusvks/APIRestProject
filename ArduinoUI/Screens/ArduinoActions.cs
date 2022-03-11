using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoUI
{
    public partial class ArduinoActions : Form
    {
        static HttpClient client = new HttpClient();

        public ArduinoActions()
        {
            InitializeComponent();
        }

        private async Task CallApiAddAction(string acao, int arduinoId, string nomeAcao)
        {
            Action action = new Action
            {
                NameAction = nomeAcao,
                ArduinoId = arduinoId,
                TypeAction = (int)TypeActions.ligarled
            };

            client = ConfigureApiParameter();

            HttpResponseMessage response = await client.PostAsync("api/Action/AddAction",
                new StringContent(JsonSerializer.Serialize(action), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
                MessageBox.Show($"Ação {acao} cadastrada com sucesso", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show($"Erro ao cadastrar a Ação {acao} StatusCode: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private static HttpClient ConfigureApiParameter()
        {
            string username = "CBEB9701-CE3E-48E6-B7FB-83867D9AED7C";
            string pass = "155115mvks";

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{username}:{pass}")));

            client.BaseAddress = new Uri("http://apirestmarcus.azurewebsites.net");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        private void btnLigarLed_ClickAsync(object sender, EventArgs e)
        {
            int arduinoId = 1;
            string nomeAcao = "Ação para ligar o LED do arduino";

            CallApiAddAction(TypeActions.ligarled.ToString(), arduinoId, nomeAcao);
        }

        public enum TypeActions
        {
            ligarled = 1,
            action2 = 2,

        }
    }
}
