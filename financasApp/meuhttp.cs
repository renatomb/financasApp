using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace financasApp
{
    public class meuhttp
    {
        public async Task<Resposta> Post(String caminho, object o)
        {
            try
            {
                var httpc = new HttpClient();
                httpc.BaseAddress = new Uri("http://192.168.82.5:3737/");
                if (MainPage.authToken != null)
                {
                    httpc.DefaultRequestHeaders.Add("token", MainPage.authToken);
                }
                string json = JsonConvert.SerializeObject(o);
                StringContent conteudoPost = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage respostaHttp = null;
                respostaHttp = await httpc.PostAsync(caminho, conteudoPost);
                var strRespostaHttp = await respostaHttp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Resposta>(strRespostaHttp);
                /*if (respostaHttp.IsSuccessStatusCode)
                {
                    
                }
                else
                {
                    return new Resposta { ok = false, resp = strRespostaHttp };
                }*/
            }
            catch (Exception ex)
            {
                return new Resposta { processado = false, mensagem=ex.ToString() };
            }
        }
        public async Task<Resposta> GetHttp(String caminho)
        {
            try
            {
                var httpc = new HttpClient();
                httpc.BaseAddress = new Uri("http://192.168.82.5:3737/");
                if (MainPage.authToken != null)
                {
                    httpc.DefaultRequestHeaders.Add("token", MainPage.authToken);
                }
                var respostaHttp = await httpc.GetAsync(caminho);
                var strRespostaGet = await respostaHttp.Content.ReadAsStringAsync();
                if (respostaHttp.IsSuccessStatusCode)
                {
                    return new Resposta { processado = true, mensagem = strRespostaGet };
                }
                else
                {
                    return new Resposta { processado = false, mensagem = strRespostaGet };
                }
            }
            catch (Exception ex)
            {
                return new Resposta { processado = false, mensagem = ex.ToString() };
            }

        }
    }
}
