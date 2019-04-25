using AutoMapper;
using Microsoft.Extensions.Logging;
using SpotifyApi.Facade.Contracts;
using SpotifyApi.Facade.Contracts.Enums;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using SpotifyBrowser.Cqrs.Implementation;
using SpotifyBrowser.ReadStack.Aplication.MyMusic.Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyBrowser.ReadStack.Aplication.Music.Search
{
    public class SearchArtistsHandler : QueryHandler<SearchArtistsQuery, Paging<Models.Artist>>
    {
        private readonly ISearchService _searchService;
        private readonly IMyArtistsReadOnlyService _myArtistsReadOnlyService;
        private readonly IMapper _mapper;

        public SearchArtistsHandler(IQueryDispatcher bus, ISearchService searchService, IMyArtistsReadOnlyService myArtistsReadOnlyService, IMapper mapper, ILogger<SearchArtistsQuery> logger) : base(bus, logger)
        {
            _searchService = searchService;
            _myArtistsReadOnlyService = myArtistsReadOnlyService;
            _mapper = mapper;
        }

        protected override async Task<Paging<Models.Artist>> _Handle(SearchArtistsQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            var artists = await _searchService.SearchItemsAsync(query.SearchPattern, SearchType.Artist, query.Limit, query.Offset);
            var taggedArtists = _myArtistsReadOnlyService.AddTagsForMyArtistsInList(Bus.User.Id, _mapper.Map<IEnumerable<Models.Artist>>(artists.Artists.Items));
            var artistAux = _mapper.Map<Paging<Models.Artist>>(artists.Artists);
            artistAux.Items = taggedArtists;
            return artistAux;
        }
    }
}