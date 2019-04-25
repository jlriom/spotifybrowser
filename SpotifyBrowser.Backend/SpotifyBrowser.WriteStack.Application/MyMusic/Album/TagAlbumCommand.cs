using SpotifyBrowser.Cqrs.Contracts.WriteStack;

namespace SpotifyBrowser.WriteStack.Application.MyMusic.Album
{
    public class TagAlbumCommand : ICommand
    {
        public string AlbumId { get; }
        public string Tag { get; }

        public TagAlbumCommand(string albumId, string tag)
        {
            AlbumId = albumId;
            Tag = tag;
        }
    }
}
