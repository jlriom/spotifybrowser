using SpotifyBrowser.Cqrs.Implementation;

namespace SpotifyBrowser.ReadStack.Aplication.Music.Search
{
    public class SearchArtistsQuery : PagedQuery<Models.Artist>
    {
        public string SearchPattern { get; }
        public SearchArtistsQuery(string searchPattern, int limit, int offset) : base(limit, offset)
        {
            SearchPattern = searchPattern;
        }
    }
}
