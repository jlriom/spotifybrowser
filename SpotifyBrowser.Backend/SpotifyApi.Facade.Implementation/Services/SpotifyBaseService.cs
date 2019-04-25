using Microsoft.Extensions.Options;
using SpotifyApi.Facade.Contracts;
using SpotifyApi.Facade.Implementation.Auth;

namespace SpotifyApi.Facade.Implementation.Services
{
    public class SpotifyBaseService
    {
        protected readonly SpotifyWebClient SpotifyWebClient;

        public SpotifyBaseService(ClientCredentialsSettings clientCredentialsSettings)
        {
            SpotifyWebClient = new SpotifyWebClient(clientCredentialsSettings);
        }
    }
}
