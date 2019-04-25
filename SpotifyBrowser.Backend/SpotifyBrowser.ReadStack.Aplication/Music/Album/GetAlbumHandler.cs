using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SpotifyApi.Facade.Contracts;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using SpotifyBrowser.Cqrs.Implementation;
using SpotifyBrowser.ReadStack.Aplication.MyMusic.Services;

namespace SpotifyBrowser.ReadStack.Aplication.Music.Album
{
    public class GetAlbumHandler : QueryHandler<GetAlbumQuery, Models.Album>
    {
        private readonly IAlbumService _albumService;
        private readonly IMyAlbumsReadOnlyService _myAlbumsReadOnlyService;
        private readonly IMapper _mapper;

        public GetAlbumHandler(IQueryDispatcher bus, IAlbumService albumService, IMyAlbumsReadOnlyService myAlbumsReadOnlyService, IMapper mapper, ILogger<GetAlbumQuery> logger) : base(bus, logger)
        {
            _albumService = albumService;
            _myAlbumsReadOnlyService = myAlbumsReadOnlyService;
            _mapper = mapper;
        }

        protected override async Task<Models.Album> _Handle(GetAlbumQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            var album = await _albumService.GetAlbumAsync(query.Id);
            return _myAlbumsReadOnlyService.AddTagsForMyAlbum(Bus.User.Id, _mapper.Map<Models.Album>(album));
        }
    }
}