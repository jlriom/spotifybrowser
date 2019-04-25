using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SpotifyApi.Facade.Contracts;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using SpotifyBrowser.Cqrs.Implementation;
using SpotifyBrowser.ReadStack.Aplication.MyMusic.Services;

namespace SpotifyBrowser.ReadStack.Aplication.Music.Artist
{
    public class GetRelatedArtistsHandler: QueryHandler<GetRelatedArtistsQuery, IEnumerable<Models.Artist>>
    {
        private readonly IArtistService _artistService;
        private readonly IMyArtistsReadOnlyService _myArtistsReadOnlyService;
        private readonly IMapper _mapper;

        public GetRelatedArtistsHandler(IQueryDispatcher bus, IArtistService artistService, IMyArtistsReadOnlyService myArtistsReadOnlyService, IMapper mapper, ILogger<GetRelatedArtistsQuery> logger) : base(bus, logger)
        {
            _artistService = artistService;
            _myArtistsReadOnlyService = myArtistsReadOnlyService;
            _mapper = mapper;
        }

        protected override async Task<IEnumerable<Models.Artist>> _Handle(GetRelatedArtistsQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            var artists = await _artistService.GetRelatedArtistsAsync(query.ArtistId);
            return _myArtistsReadOnlyService.AddTagsForMyArtistsInList(Bus.User.Id, _mapper.Map<IEnumerable<Models.Artist>>(artists.Artists));
        }
    }
}