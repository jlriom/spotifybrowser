using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpotifyApi.Facade.Contracts.Models;
using SpotifyApi.Facade.Implementation.Auth;

namespace SpotifyApi.Facade.Implementation
{
    public class SpotifyWebClient
    {
        private readonly ClientCredentialsSettings _clientCredentialsSettings;

        public SpotifyWebClient(ClientCredentialsSettings clientCredentialsSettings)
        {
            _clientCredentialsSettings = clientCredentialsSettings;
        }
        public async Task<T> Get<T>(string uri) where T : BasicModel
        {
            using (var client = new HttpClient())
            {
                Auth.Auth.SetAuthToken(client, _clientCredentialsSettings);
                var resp = client.GetAsync(uri).Result;
                var msg = await resp.Content.ReadAsStringAsync();
                if (!resp.IsSuccessStatusCode)
                    throw new ApplicationException(
                        $"Http error => code: {resp.StatusCode}, Reason: {resp.ReasonPhrase} \n Message: { msg }");
                return JsonConvert.DeserializeObject<T>(msg);
            }
        }
    }
}
