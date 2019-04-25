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
    public class GetPlaylistHandler : QueryHandler<GetPlaylistQuery, FullPlaylist>
    {
        private readonly IPlaylistService _playlistService;
        private readonly IMapper _mapper;

        public GetPlaylistHandler(IQueryDispatcher bus, IPlaylistService playlistService, IMapper mapper, ILogger<GetPlaylistQuery> logger) : base(bus, logger)
        {
            _playlistService = playlistService;
            _mapper = mapper;
        }

        protected override async Task<FullPlaylist> _Handle(GetPlaylistQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            var playlist = await _playlistService.GetPlaylistAsync(string.Empty, query.PlaylistId);
            return _mapper.Map<FullPlaylist>(playlist);
        }
    }
}
