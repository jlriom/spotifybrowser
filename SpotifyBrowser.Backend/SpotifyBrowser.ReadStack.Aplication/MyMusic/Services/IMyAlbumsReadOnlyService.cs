using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpotifyBrowser.ReadStack.Aplication.MyMusic.Services
{
    public interface IMyAlbumsReadOnlyService
    {
        Task<IEnumerable<Models.Album>> GetMyAlbums(string userId);
        IEnumerable<Models.Album> AddTagsForMyAlbumsInList(string userId, IEnumerable<Models.Album> albums);
        Models.Album AddTagsForMyAlbum(string userId, Models.Album album);
    }
}
