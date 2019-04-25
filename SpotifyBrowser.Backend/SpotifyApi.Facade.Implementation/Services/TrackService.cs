using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SpotifyApi.Facade.Contracts;
using SpotifyApi.Facade.Contracts.Models;
using SpotifyApi.Facade.Implementation.Auth;

namespace SpotifyApi.Facade.Implementation.Services
{
    public class TrackService : SpotifyBaseService, ITrackService
    {
        public TrackService(ClientCredentialsSettings clientCredentialsSettings) : base(clientCredentialsSettings)
        {
        }

        public Task<Paging<SimpleTrack>> GetAlbumTracksAsync(string id, int limit = 20, int offset = 0, string market = "")
        {
            return SpotifyWebClient.Get<Paging<SimpleTrack>>(new SpotifyWebBuilder().GetAlbumTracks(id, limit, offset, market));
        }

        public Task<FullTrack> GetTrackAsync(string id, string market = "")
        {
            return SpotifyWebClient.Get<FullTrack>(new SpotifyWebBuilder().GetTrack(id, market));
        }

        public Task<SeveralTracks> GetArtistsTopTracksAsync(string id, string country)
        {
            return SpotifyWebClient.Get<SeveralTracks>(new SpotifyWebBuilder().GetArtistsTopTracks(id, country));
        }
    }
}