using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using SpotifyBrowser.ReadStack.Api.Host.MusicModels;
using SpotifyBrowser.ReadStack.Aplication.Music.Category;

namespace SpotifyBrowser.ReadStack.Api.Host.Music
{
    public class CategoryController : MusicBaseController
    {
        public CategoryController(IQueryDispatcher queryDispatcher, IMapper mapper) : base(queryDispatcher, mapper)
        {
        }

        [HttpGet("GetCategories")]
        public async Task<ActionResult<Paging<Category>>> GetCategories(int limit = DefaultLimit, int offset = DefaultOffset)
        {
            var categories = await QueryDispatcher.Dispatch(new GetCategoriesQuery(limit, offset));
            return await Task.FromResult(Mapper.Map<Paging<Category>>(categories));
        }

        [HttpGet("GetCategory")]
        public async Task<ActionResult<Category>> GetCategory(string categoryId)
        {
            var category = await QueryDispatcher.Dispatch(new GetCategoryQuery(categoryId));
            return await Task.FromResult(Mapper.Map<Category>(category));
        }
    }
}