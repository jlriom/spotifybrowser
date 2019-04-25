using SpotifyBrowser.Cqrs.Implementation;

namespace SpotifyBrowser.ReadStack.Aplication.Music.Search
{
    public class SearchTracksQuery : PagedQuery<Models.Track>
    {
        public string SearchPattern { get; }
        public SearchTracksQuery(string searchPattern, int limit, int offset) : base(limit, offset)
        {
            SearchPattern = searchPattern;
        }
    }
}
