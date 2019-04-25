using SpotifyBrowser.Cqrs.Contracts.ReadStack;

namespace SpotifyBrowser.ReadStack.Aplication.Music.Album
{
    public class GetAlbumQuery: IQuery<Models.Album>
    {
        public string Id { get; }
        public GetAlbumQuery(string id)
        {
            Id = id;
        }
    }
}
