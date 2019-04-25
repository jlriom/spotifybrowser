using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpotifyApi.Facade.Contracts;
using SpotifyApi.Facade.Contracts.Models;

namespace SpotifyApi.Facade.Checker.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _service;

        public AlbumController(IAlbumService service)
        {
            _service = service;
        }

        [HttpGet("GetArtistsAlbums")]
        public async Task<ActionResult<Paging<SimpleAlbum>>> GetArtistsAlbums(string artistId)
        {
            return await _service.GetArtistsAlbumsAsync(artistId);
        }

        [HttpGet("GetAlbum")]
        public async Task<ActionResult<FullAlbum>> GetAlbum(string id)
        {
            return await _service.GetAlbumAsync(id);
        }
    }
}