using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using SpotifyBrowser.Cqrs.Implementation;
using SpotifyBrowser.ReadStack.Aplication.MyMusic.Services;

namespace SpotifyBrowser.ReadStack.Aplication.MyMusic.Artist
{
    public class GetMyArtistsHandler : QueryHandler<GetMyArtistsQuery, IEnumerable<Models.Artist>>
    {
        private readonly IMyArtistsReadOnlyService _myArtistsReadOnlyService;
        private readonly IMapper _mapper;

        public GetMyArtistsHandler(IQueryDispatcher bus, IMyArtistsReadOnlyService myArtistsReadOnlyService, IMapper mapper, ILogger<GetMyArtistsQuery> logger) : base(bus, logger)
        {
            _myArtistsReadOnlyService = myArtistsReadOnlyService;
            _mapper = mapper;
        }

        protected override async Task<IEnumerable<Models.Artist>> _Handle(GetMyArtistsQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            var artists = await _myArtistsReadOnlyService.GetMyArtists(Bus.User.Id);
            return _mapper.Map<IEnumerable<Models.Artist>>(artists);
        }
    }
}