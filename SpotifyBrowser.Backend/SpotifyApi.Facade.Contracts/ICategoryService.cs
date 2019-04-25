using System.Threading.Tasks;
using SpotifyApi.Facade.Contracts.Models;

namespace SpotifyApi.Facade.Contracts
{
    public interface ICategoryService
    {
        Task<CategoryList> GetCategoriesAsync(string country = "", string locale = "", int limit = 20, int offset = 0);
        Task<Category> GetCategoryAsync(string categoryId, string country = "", string locale = "");
    }
}