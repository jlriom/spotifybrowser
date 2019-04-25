namespace SpotifyApi.Facade.Implementation.Auth
{
    public class ClientCredentialsSettings
    {
        public string ClientSecret { get; }
        public string ClientId { get; }
        public ClientCredentialsSettings(string clientSecret, string clientId)
        {
            ClientSecret = clientSecret;
            ClientId = clientId;
        }
    }
}
