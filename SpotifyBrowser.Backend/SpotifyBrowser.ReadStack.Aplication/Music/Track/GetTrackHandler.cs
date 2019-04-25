using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SpotifyApi.Facade.Contracts;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using SpotifyBrowser.Cqrs.Implementation;

namespace SpotifyBrowser.ReadStack.Aplication.Music.Track
{
    public class GetTrackHandler : QueryHandler<GetTrackQuery, Models.Track>
    {
        private readonly ITrackService _trackService;
        private readonly IMapper _mapper;

        public GetTrackHandler(IQueryDispatcher bus, ITrackService trackService, IMapper mapper, ILogger<GetTrackQuery> logger) : base(bus, logger)
        {
            _trackService = trackService;
            _mapper = mapper;
        }

        protected override async Task<Models.Track> _Handle(GetTrackQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            var track = await _trackService.GetTrackAsync(query.TrackId);
            return _mapper.Map<Models.Track>(track);
        }
    }
}