using SpotifyBrowser.Cqrs.Implementation;

namespace SpotifyBrowser.ReadStack.Aplication.Music.Track
{
    public class GetAlbumTracksQuery : PagedQuery<Models.Track>
    {
        public string AlbumId { get; }

        public GetAlbumTracksQuery(string albumId, int limit, int offset) : base(limit, offset)
        {
            AlbumId = albumId;
        }
    }
}
