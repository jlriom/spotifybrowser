using AutoMapper;
using Microsoft.Extensions.Logging;
using SpotifyApi.Facade.Contracts;
using SpotifyApi.Facade.Contracts.Enums;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using SpotifyBrowser.Cqrs.Implementation;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyBrowser.ReadStack.Aplication.Music.Search
{
    public class SearchAlbumsHandler : QueryHandler<SearchAlbumsQuery, Paging<Models.Album>>
    {
        private readonly ISearchService _searchService;
        private readonly IMapper _mapper;

        public SearchAlbumsHandler(IQueryDispatcher bus, ISearchService searchService, IMapper mapper, ILogger<SearchAlbumsQuery> logger) : base(bus, logger)
        {
            _searchService = searchService;
            _mapper = mapper;
        }

        protected override async Task<Paging<Models.Album>> _Handle(SearchAlbumsQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            var albums = await _searchService.SearchItemsAsync(query.SearchPattern, SearchType.Album, query.Limit, query.Offset);
            return _mapper.Map<Paging<Models.Album>>(albums.Albums);
        }
    }
}