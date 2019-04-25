using SpotifyBrowser.Cqrs.Contracts.WriteStack;

namespace SpotifyBrowser.WriteStack.Application.MyMusic.Artist
{
    public class UntagArtistCommand : ICommand
    {
        public string ArtistId { get; }
        public string Tag { get; }

        public UntagArtistCommand(string artistId, string tag)
        {
            ArtistId = artistId;
            Tag = tag;
        }
    }
}
