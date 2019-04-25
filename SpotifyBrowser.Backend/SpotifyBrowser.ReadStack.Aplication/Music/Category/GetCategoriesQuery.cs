using SpotifyBrowser.Cqrs.Implementation;

namespace SpotifyBrowser.ReadStack.Aplication.Music.Category
{
    public class GetCategoriesQuery : PagedQuery<Models.Category>
    {
        public GetCategoriesQuery(int limit, int offset) : base(limit, offset)
        {
        }
    }
}
