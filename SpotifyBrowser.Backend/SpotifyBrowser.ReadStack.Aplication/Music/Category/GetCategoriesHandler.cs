using AutoMapper;
using Microsoft.Extensions.Logging;
using SpotifyApi.Facade.Contracts;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using SpotifyBrowser.Cqrs.Implementation;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyBrowser.ReadStack.Aplication.Music.Category
{
    public class GetCategoriesHandler : QueryHandler<GetCategoriesQuery, Paging<Models.Category>>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public GetCategoriesHandler(IQueryDispatcher bus, ICategoryService categoryService, IMapper mapper, ILogger<GetCategoriesQuery> logger) : base(bus, logger)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        protected override async Task<Paging<Models.Category>> _Handle(GetCategoriesQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            var categories = await _categoryService.GetCategoriesAsync(string.Empty, string.Empty, query.Limit, query.Offset);
            return _mapper.Map<Paging<Models.Category>>(categories.Categories);
        }
    }
}