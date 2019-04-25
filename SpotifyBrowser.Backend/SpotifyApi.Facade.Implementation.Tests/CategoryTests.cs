using SpotifyApi.Facade.Contracts;
using SpotifyApi.Facade.Implementation.Services;
using Xunit;

namespace SpotifyApi.Facade.Implementation.Tests
{
    public class CategoryTests
    {
        readonly ICategoryService _service  = new CategoryService(new ClientCredentialsSettingsOptions().Value);

        [Fact]
        public void GetCategories()
        {
            Assert.True(_service.GetCategoriesAsync().Result.Categories.Total > 0);
        }

        [Theory]
        [InlineData("classical")]
        public void GetCategory(string categoryId)
        {
            Assert.Equal(categoryId, _service.GetCategoryAsync(categoryId).Result.Id);
        }
    }
}
