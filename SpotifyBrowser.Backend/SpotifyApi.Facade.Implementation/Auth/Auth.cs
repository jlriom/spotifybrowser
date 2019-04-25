using System.Net.Http;
using SpotifyApi.Facade.Contracts.Models;

namespace SpotifyApi.Facade.Implementation.Auth
{
    public static class Auth
    {
        private static Token _token;
        private static readonly object Padlock = new object();

        public static void SetAuthToken(HttpClient httpClient, ClientCredentialsSettings clientCredentialsSettings)
        {
            //var clientCredentialsSettings = new ClientCredentialsSettings();

            lock (Padlock)
            {
                if (_token == null || _token != null && (_token.HasError() || _token.IsExpired()))
                {
                    _token = new ClientCredentialsAuth(clientCredentialsSettings.ClientId,
                        clientCredentialsSettings.ClientSecret).GetToken();
                }
            }

            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", _token.TokenType + " " + _token.AccessToken);
        }
    }
}
