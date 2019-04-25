using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpotifyApi.Facade.Contracts;
using SpotifyApi.Facade.Contracts.Models;

namespace SpotifyApi.Facade.Checker.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistService _service;

        public PlaylistController(IPlaylistService service)
        {
            _service = service;
        }

        [HttpGet("GetCategoryPlaylists")]
        public async Task<ActionResult<CategoryPlaylist>> GetCategoryPlaylists(string categoryId, string country = "", int limit = 20, int offset = 0)
        {
            return await _service.GetCategoryPlaylistsAsync(categoryId, country, limit, offset);
        }


        [HttpGet("GetPlaylist")]
        public async Task<ActionResult<FullPlaylist>> GetPlaylist(string playlistId, string userId = "", string fields = "", string market = "")
        {
            return await _service.GetPlaylistAsync(userId, playlistId, fields, market);
        }
    }
}