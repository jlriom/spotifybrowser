using System.Threading.Tasks;
using SpotifyApi.Facade.Contracts;
using SpotifyApi.Facade.Contracts.Models;
using SpotifyApi.Facade.Implementation.Auth;

namespace SpotifyApi.Facade.Implementation.Services
{
    public class PlaylistService: SpotifyBaseService, IPlaylistService
    {
        public PlaylistService(ClientCredentialsSettings clientCredentialsSettings) : base(clientCredentialsSettings)
        {
        }

        public Task<CategoryPlaylist> GetCategoryPlaylistsAsync(string categoryId, string country = "", int limit = 20, int offset = 0)
        {
            return SpotifyWebClient.Get<CategoryPlaylist>(new SpotifyWebBuilder().GetCategoryPlaylists(categoryId, country, limit, offset));
        }

        public Task<FullPlaylist> GetPlaylistAsync(string userId, string playlistId, string fields = "", string market = "")
        {
            return SpotifyWebClient.Get<FullPlaylist>(new SpotifyWebBuilder().GetPlaylist(userId, playlistId, fields, market));
        }
    }
}
