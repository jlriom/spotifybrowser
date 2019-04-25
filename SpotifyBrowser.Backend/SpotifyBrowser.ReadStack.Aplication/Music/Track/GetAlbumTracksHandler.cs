using AutoMapper;
using Microsoft.Extensions.Logging;
using SpotifyApi.Facade.Contracts;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using SpotifyBrowser.Cqrs.Implementation;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyBrowser.ReadStack.Aplication.Music.Track
{
    public class GetAlbumTracksHandler : QueryHandler<GetAlbumTracksQuery, Paging<Models.Track>>
    {
        private readonly ITrackService _trackService;
        private readonly IMapper _mapper;

        public GetAlbumTracksHandler(IQueryDispatcher bus, ITrackService trackService, IMapper mapper, ILogger<GetAlbumTracksQuery> logger) : base(bus, logger)
        {
            _trackService = trackService;
            _mapper = mapper;
        }

        protected override async Task<Paging<Models.Track>> _Handle(GetAlbumTracksQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            var tracks = await _trackService.GetAlbumTracksAsync(query.AlbumId,query.Limit, query.Offset);
            return _mapper.Map<Paging<Models.Track>>(tracks);
        }
    }
}