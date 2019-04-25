using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SpotifyApi.Facade.Contracts;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using SpotifyBrowser.Cqrs.Implementation;

namespace SpotifyBrowser.ReadStack.Aplication.Music.Category
{
    public class GetCategoryHandler : QueryHandler<GetCategoryQuery, Models.Category>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public GetCategoryHandler(IQueryDispatcher bus, ICategoryService categoryService, IMapper mapper, ILogger<GetCategoryQuery> logger) : base(bus, logger)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        protected override async Task<Models.Category> _Handle(GetCategoryQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            var category = await _categoryService.GetCategoryAsync(query.CategoryId);
            return _mapper.Map<Models.Category>(category);
        }
    }
}