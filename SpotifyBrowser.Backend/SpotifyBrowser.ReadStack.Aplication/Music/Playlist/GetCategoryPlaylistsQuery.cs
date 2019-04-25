using SpotifyBrowser.Cqrs.Implementation;
using SpotifyBrowser.ReadStack.Aplication.Models;

namespace SpotifyBrowser.ReadStack.Aplication.Music.Playlist
{
    public class GetCategoryPlaylistsQuery : PagedQuery<SimplePlaylist>
    {
        public string CategoryId { get; }

        public GetCategoryPlaylistsQuery(string categoryId, int limit, int offset) : base(limit, offset)
        {
            CategoryId = categoryId;
        }
    }
}
