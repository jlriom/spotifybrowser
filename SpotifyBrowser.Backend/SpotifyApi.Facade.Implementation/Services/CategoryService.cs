using SpotifyApi.Facade.Contracts;
using SpotifyApi.Facade.Contracts.Models;
using SpotifyApi.Facade.Implementation.Auth;
using System.Threading.Tasks;

namespace SpotifyApi.Facade.Implementation.Services
{
    public class CategoryService: SpotifyBaseService, ICategoryService
    {
        public CategoryService(ClientCredentialsSettings clientCredentialsSettings) : base(clientCredentialsSettings)
        {
        }

        public Task<CategoryList> GetCategoriesAsync(string country = "", string locale = "", int limit = 20, int offset = 0)
        {
            return SpotifyWebClient.Get<CategoryList>(new SpotifyWebBuilder().GetCategories(country, locale ,limit , offset ));
        }

        public Task<Category> GetCategoryAsync(string categoryId, string country = "", string locale = "")
        {
            return SpotifyWebClient.Get<Category>(new SpotifyWebBuilder().GetCategory(categoryId, country, locale));
        }
    }
}