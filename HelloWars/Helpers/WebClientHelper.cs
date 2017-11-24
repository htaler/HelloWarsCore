using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HelloWars.ArenaServer.Helpers
{
    public static class WebClientHelper
    {
        public static async Task<TResponse> PostDataAsync<TParam, TResponse>(string url, TParam parameter)
        {
            var webClient = CreateWebClient();
            var content = new StringContent(JsonHelper.Serialize(parameter), Encoding.UTF8, "application/json");
            var response = await webClient.PostAsync(new Uri(url), content);

            var responseContent = response.Content.ReadAsStringAsync();
            return JsonHelper.Deserialize<TResponse>(responseContent.Result);
        }
        
        public static async Task<TResponse> GetDataAsync<TResponse>(string url)
        {
            var webClient = CreateWebClient();
            var downloadedString = await webClient.GetStringAsync(url);
            return JsonHelper.Deserialize<TResponse>(downloadedString);
        }

        private static HttpClient CreateWebClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public static TResponse GetData<TResponse>(string url)
        {
            var webClient = CreateWebClient();
            var downloadedString = webClient.GetStringAsync(url);
            return JsonHelper.Deserialize<TResponse>(downloadedString.Result);
        }
    }
}