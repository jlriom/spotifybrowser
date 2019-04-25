using SpotifyBrowser.Cqrs.Contracts.ReadStack;

namespace SpotifyBrowser.ReadStack.Aplication.Music.Category
{
    public class GetCategoryQuery : IQuery<Models.Category>
    {
        public string CategoryId { get; }
        public GetCategoryQuery(string categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
