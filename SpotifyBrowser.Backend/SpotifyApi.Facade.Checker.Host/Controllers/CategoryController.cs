using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpotifyApi.Facade.Contracts;
using SpotifyApi.Facade.Contracts.Models;

namespace SpotifyApi.Facade.Checker.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet("GetCategories")]
        public async Task<ActionResult<CategoryList>> GetCategories()
        {
            return await _service.GetCategoriesAsync();
        }

        [HttpGet("GetCategory")]
        public async Task<ActionResult<Category>> GetCategory(string categoryId)
        {
            return await _service.GetCategoryAsync(categoryId);
        }
    }
}