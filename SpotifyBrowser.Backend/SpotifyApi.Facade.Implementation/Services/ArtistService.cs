using SpotifyApi.Facade.Contracts;
using SpotifyApi.Facade.Contracts.Models;
using SpotifyApi.Facade.Implementation.Auth;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotifyApi.Facade.Implementation.Services
{
    public class ArtistService: SpotifyBaseService, IArtistService
    {
        public ArtistService(ClientCredentialsSettings clientCredentialsSettings) : base(clientCredentialsSettings)
        {
        }

        public Task<FullArtist> GetArtistAsync(string id)
        {
            return SpotifyWebClient.Get<FullArtist>(new SpotifyWebBuilder().GetArtist(id));
        }

        public Task<SeveralArtists> GetRelatedArtistsAsync(string id)
        {
            return SpotifyWebClient.Get<SeveralArtists>(new SpotifyWebBuilder().GetRelatedArtists(id));
        }

        public Task<SeveralArtists> GetSeveralArtistsAsync(IEnumerable<string> ids)
        {
            return SpotifyWebClient.Get<SeveralArtists>(new SpotifyWebBuilder().GetSeveralArtists(ids.ToList()));
        }
    }
}