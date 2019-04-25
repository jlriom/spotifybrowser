using SpotifyBrowser.Cqrs.Implementation;

namespace SpotifyBrowser.ReadStack.Aplication.Music.Search
{
    public class SearchAlbumsQuery : PagedQuery<Models.Album>
    {
        public string SearchPattern { get; }
        public SearchAlbumsQuery(string searchPattern, int limit, int offset) : base(limit, offset)
        {
            SearchPattern = searchPattern;
        }
    }
}
