using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpotifyApi.Facade.Contracts;
using SpotifyApi.Facade.Contracts.Models;

namespace SpotifyApi.Facade.Checker.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _service;

        public ArtistController(IArtistService service)
        {
            _service = service;
        }

        [HttpGet("GetArtist")]
        public async Task<ActionResult<FullArtist>> GetArtist(string artistId)
        {
            return await _service.GetArtistAsync(artistId);
        }

        [HttpGet("GetRelatedArtists")]
        public async Task<ActionResult<SeveralArtists>> GetRelatedArtists(string artistId)
        {
            return await _service.GetRelatedArtistsAsync(artistId);
        }
    }
}