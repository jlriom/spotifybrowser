using System.Collections.Generic;
using System.Threading.Tasks;
using SpotifyApi.Facade.Contracts.Enums;
using SpotifyApi.Facade.Contracts.Models;

namespace SpotifyApi.Facade.Contracts
{
    public interface IAlbumService
    {
        Task<Paging<SimpleAlbum>> GetArtistsAlbumsAsync(string id, AlbumType type = AlbumType.All, int limit = 20, int offset = 0, string market = "");
        Task<FullAlbum> GetAlbumAsync(string id, string market = "");
        Task<SeveralAlbums> GetSeveralAlbumsAsync(IEnumerable<string> ids);

    }
}