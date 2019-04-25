using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using SpotifyBrowser.ReadStack.Api.Host.MusicModels;
using SpotifyBrowser.ReadStack.Aplication.Music.Playlist;

namespace SpotifyBrowser.ReadStack.Api.Host.Music
{
    public class PlaylistController : MusicBaseController
    {
        public PlaylistController(IQueryDispatcher queryDispatcher, IMapper mapper) : base(queryDispatcher, mapper)
        {
        }

        [HttpGet("GetCategoryPlaylists")]
        public async Task<ActionResult<Paging<SimplePlaylist>>> GetCategoryPlaylists(string categoryId, int limit = DefaultLimit, int offset = DefaultOffset)
        {
            var playlists = await QueryDispatcher.Dispatch(new GetCategoryPlaylistsQuery(categoryId, limit, offset));
            return await Task.FromResult(Mapper.Map<Paging<SimplePlaylist>>(playlists));
        }

        [HttpGet("GetPlaylist")]
        public async Task<ActionResult<FullPlaylist>> GetPlaylist(string playlistId)
        {
            var playlist = await QueryDispatcher.Dispatch(new GetPlaylistQuery(playlistId));
            return await Task.FromResult(Mapper.Map<FullPlaylist>(playlist));
        }
    }
}