using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpotifyBrowser.ReadStack.Aplication.MyMusic.Services
{
    public interface IMyArtistsReadOnlyService
    {
        Task<IEnumerable<Models.Artist>> GetMyArtists(string userId);
        IEnumerable<Models.Artist> AddTagsForMyArtistsInList(string userId, IEnumerable<Models.Artist> artists);
        Models.Artist AddTagsForMyArtist(string userId, Models.Artist artist);
    }
}
