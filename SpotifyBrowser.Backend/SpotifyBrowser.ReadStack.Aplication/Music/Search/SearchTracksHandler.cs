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
    public class SearchTracksHandler : QueryHandler<SearchTracksQuery, Paging<Models.Track>>
    {
        private readonly ISearchService _searchService;
        private readonly IMapper _mapper;

        public SearchTracksHandler(IQueryDispatcher bus, ISearchService searchService, IMapper mapper, ILogger<SearchTracksQuery> logger) : base(bus, logger)
        {
            _searchService = searchService;
            _mapper = mapper;
        }

        protected override async Task<Paging<Models.Track>> _Handle(SearchTracksQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            var tracks = await _searchService.SearchItemsAsync(query.SearchPattern, SearchType.Track, query.Limit, query.Offset);
            return _mapper.Map<Paging<Models.Track>>(tracks.Tracks);
        }
    }
}