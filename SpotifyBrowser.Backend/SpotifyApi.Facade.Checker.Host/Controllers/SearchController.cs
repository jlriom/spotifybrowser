using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpotifyApi.Facade.Contracts;
using SpotifyApi.Facade.Contracts.Enums;
using SpotifyApi.Facade.Contracts.Models;

namespace SpotifyApi.Facade.Checker.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _service;

        public SearchController(ISearchService service)
        {
            _service = service;
        }

        [HttpGet("SearchArtists")]
        public async Task<ActionResult<SearchItem>> SearchArtists(string q)        {
            return await _service.SearchItemsAsync(q, SearchType.Artist);
        }

        [HttpGet("SearchAlbums")]
        public async Task<ActionResult<SearchItem>> SearchAlbums(string q)
        {
            return await _service.SearchItemsAsync(q, SearchType.Album);
        }

        [HttpGet]
        [HttpGet("SearchTracks")]
        public async Task<ActionResult<SearchItem>> SearchTracks(string q)
        {
            return await _service.SearchItemsAsync(q, SearchType.Track);
        }
    }
}