using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpotifyApi.Facade.Contracts;
using SpotifyApi.Facade.Contracts.Models;

namespace SpotifyApi.Facade.Checker.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly ITrackService _service;

        public TrackController(ITrackService service)
        {
            _service = service;
        }

        [HttpGet("GetAlbumTracks")]
        public async Task<ActionResult<Paging<SimpleTrack>>> GetAlbumTracks(string albumId)
        {
            return await _service.GetAlbumTracksAsync(albumId);
        }

        [HttpGet("GetTrack")]
        public async Task<ActionResult<FullTrack>> GetTrack(string id)
        {
            return await _service.GetTrackAsync(id);
        }

        [HttpGet("GetArtistsTopTracks")]
        public async Task<ActionResult<SeveralTracks>> GetArtistsTopTracks(string artistId, string country)
        {
            return await _service.GetArtistsTopTracksAsync(artistId, country);
        }
    }
}