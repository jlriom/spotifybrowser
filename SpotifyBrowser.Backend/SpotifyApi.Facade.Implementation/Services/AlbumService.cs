using SpotifyApi.Facade.Contracts;
using SpotifyApi.Facade.Contracts.Enums;
using SpotifyApi.Facade.Contracts.Models;
using SpotifyApi.Facade.Implementation.Auth;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotifyApi.Facade.Implementation.Services
{
    public class AlbumService : SpotifyBaseService, IAlbumService
    {
        public AlbumService(ClientCredentialsSettings clientCredentialsSettings) : base(clientCredentialsSettings)
        {
        }

        public Task<FullAlbum> GetAlbumAsync(string id, string market = "")
        {
            return SpotifyWebClient.Get<FullAlbum>(new SpotifyWebBuilder().GetAlbum(id, market));
        }

        public Task<Paging<SimpleAlbum>> GetArtistsAlbumsAsync(string id, AlbumType type = AlbumType.All, int limit = 20, int offset = 0, string market = "")
        {
            return SpotifyWebClient.Get<Paging<SimpleAlbum>>(new SpotifyWebBuilder().GetArtistsAlbums(id, type , limit, offset,  market));
        }
        public Task<SeveralAlbums> GetSeveralAlbumsAsync(IEnumerable<string> ids)
        {
            return SpotifyWebClient.Get<SeveralAlbums>(new SpotifyWebBuilder().GetSeveralAlbums(ids.ToList()));
        }

    }
}