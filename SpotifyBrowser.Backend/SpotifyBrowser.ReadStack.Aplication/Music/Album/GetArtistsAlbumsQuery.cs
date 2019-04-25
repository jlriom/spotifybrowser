using SpotifyBrowser.Cqrs.Implementation;

namespace SpotifyBrowser.ReadStack.Aplication.Music.Album
{
    public class GetArtistsAlbumsQuery : PagedQuery<Models.Album>
    {
        public string ArtistId { get; }

        public GetArtistsAlbumsQuery(string artistId, int limit, int offset): base(limit, offset)
        {
            ArtistId = artistId;
        }
    }
}
