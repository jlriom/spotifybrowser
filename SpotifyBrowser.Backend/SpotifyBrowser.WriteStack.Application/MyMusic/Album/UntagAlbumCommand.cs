using SpotifyBrowser.Cqrs.Contracts.WriteStack;

namespace SpotifyBrowser.WriteStack.Application.MyMusic.Album
{
    public class UntagAlbumCommand : ICommand
    {
        public string AlbumId { get; }
        public string Tag { get; }

        public UntagAlbumCommand(string albumId, string tag)
        {
            AlbumId = albumId;
            Tag = tag;
        }
    }
}
