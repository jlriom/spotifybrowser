using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using SpotifyApi.Facade.Contracts.Models;

namespace SpotifyApi.Facade.Implementation.Auth
{
    public class ClientCredentialsAuth
    {

        public string ClientSecret { get; set; }

        public string ClientId { get; set; }

        public ClientCredentialsAuth(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        public Token GetToken()
        {
            string auth = Convert.ToBase64String(Encoding.UTF8.GetBytes(ClientId + ":" + ClientSecret));

            List<KeyValuePair<string, string>> args = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials")
            };

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Basic {auth}");
            HttpContent content = new FormUrlEncodedContent(args);

            HttpResponseMessage resp = client.PostAsync("https://accounts.spotify.com/api/token", content).Result;
            string msg = resp.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<Token>(msg);
        }
    }
}
