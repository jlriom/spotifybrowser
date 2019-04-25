using AutoMapper;
using Microsoft.Extensions.Logging;
using SpotifyApi.Facade.Contracts;
using SpotifyBrowser.ReadStack.Aplication.Models;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using SpotifyBrowser.Cqrs.Implementation;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyBrowser.ReadStack.Aplication.Music.Playlist
{
    public class GetCategoryPlaylistsHandler : QueryHandler<GetCategoryPlaylistsQuery, Paging<SimplePlaylist>>
    {
        private readonly IPlaylistService _playlistService;
        private readonly IMapper _mapper;

        public GetCategoryPlaylistsHandler(IQueryDispatcher bus, IPlaylistService playlistService, IMapper mapper, ILogger<GetCategoryPlaylistsQuery> logger) : base(bus, logger)
        {
            _playlistService = playlistService;
            _mapper = mapper;
        }

        protected override async Task<Paging<SimplePlaylist>> _Handle(GetCategoryPlaylistsQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            var playlists = await _playlistService.GetCategoryPlaylistsAsync(query.CategoryId, string.Empty, query.Limit, query.Offset);
            return _mapper.Map<Paging<SimplePlaylist>>(playlists.Playlists);
        }
    }
}
