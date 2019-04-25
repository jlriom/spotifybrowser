using AutoMapper;
using Microsoft.Extensions.Logging;
using SpotifyApi.Facade.Contracts;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using SpotifyBrowser.Cqrs.Implementation;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyBrowser.ReadStack.Aplication.Music.Track
{
    public class GetArtistsTopTracksHandler : QueryHandler<GetArtistsTopTracksQuery, IEnumerable<Models.Track>>
    {
        private readonly ITrackService _trackService;
        private readonly IMapper _mapper;

        public GetArtistsTopTracksHandler(IQueryDispatcher bus, ITrackService trackService, IMapper mapper, ILogger<GetArtistsTopTracksQuery> logger) : base(bus, logger)
        {
            _trackService = trackService;
            _mapper = mapper;
        }

        protected override async Task<IEnumerable<Models.Track>> _Handle(GetArtistsTopTracksQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            var tracks = await _trackService.GetArtistsTopTracksAsync(query.ArtistId, query.Country);
            return _mapper.Map<IEnumerable<Models.Track>>(tracks.Tracks);
        }
    }
}