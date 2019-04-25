using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SpotifyApi.Facade.Contracts;
using SpotifyApi.Facade.Contracts.Enums;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using SpotifyBrowser.Cqrs.Implementation;
using SpotifyBrowser.ReadStack.Aplication.Models;

namespace SpotifyBrowser.ReadStack.Aplication.Music.Album
{
    public class GetArtistsAlbumsHandler : QueryHandler<GetArtistsAlbumsQuery, Paging<Models.Album>>
    {
        private readonly IAlbumService _albumService;
        private readonly IMapper _mapper;

        public GetArtistsAlbumsHandler(IQueryDispatcher bus, IAlbumService albumService, IMapper mapper, ILogger<GetArtistsAlbumsQuery> logger) : base(bus, logger)
        {
            _albumService = albumService;
            _mapper = mapper;
        }

        protected override async Task<Paging<Models.Album>> _Handle(GetArtistsAlbumsQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            var albums = await _albumService.GetArtistsAlbumsAsync(query.ArtistId, AlbumType.All, query.Limit, query.Offset);
            return _mapper.Map<Paging<Models.Album>>(albums);
        }
    }
}