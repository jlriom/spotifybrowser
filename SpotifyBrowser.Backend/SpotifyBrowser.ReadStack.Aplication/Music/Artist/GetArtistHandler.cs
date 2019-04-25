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
    public class GetArtistHandler : QueryHandler<GetArtistQuery, Models.Artist>
    {
        private readonly IArtistService _artistService;
        private readonly IMyArtistsReadOnlyService _myArtistsReadOnlyService;
        private readonly IMapper _mapper;

        public GetArtistHandler(IQueryDispatcher bus, IArtistService artistService, IMyArtistsReadOnlyService myArtistsReadOnlyService, IMapper mapper, ILogger<GetArtistQuery> logger) : base(bus, logger)
        {
            _artistService = artistService;
            _myArtistsReadOnlyService = myArtistsReadOnlyService;
            _mapper = mapper;
        }

        protected override async Task<Models.Artist> _Handle(GetArtistQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            var artist = await _artistService.GetArtistAsync(query.ArtistId);
            return _myArtistsReadOnlyService.AddTagsForMyArtist(Bus.User.Id, _mapper.Map<Models.Artist>(artist));
        }
    }
}