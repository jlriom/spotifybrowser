using SpotifyApi.Facade.Contracts.Models;
using System.Threading.Tasks;

namespace SpotifyApi.Facade.Contracts
{
    public interface IPlaylistService
    {
        Task<CategoryPlaylist> GetCategoryPlaylistsAsync(string categoryId, string country = "", int limit = 20, int offset = 0);
        Task<FullPlaylist> GetPlaylistAsync(string userId, string playlistId, string fields = "", string market = "");

    }
}
