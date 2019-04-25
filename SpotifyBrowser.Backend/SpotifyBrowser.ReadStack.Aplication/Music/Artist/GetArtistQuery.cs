using SpotifyBrowser.Cqrs.Contracts.ReadStack;

namespace SpotifyBrowser.ReadStack.Aplication.Music.Artist
{
    public class GetArtistQuery : IQuery<Models.Artist>
    {
        public string ArtistId { get; }
        public GetArtistQuery(string artistId)
        {
            ArtistId = artistId;
        }
    }
}
