using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using SpotifyBrowser.ReadStack.Api.Host.MusicModels;
using SpotifyBrowser.ReadStack.Aplication.Music.Search;

namespace SpotifyBrowser.ReadStack.Api.Host.Music
{
    public class SearchController : MusicBaseController
    {
        public SearchController(IQueryDispatcher queryDispatcher, IMapper mapper) : base(queryDispatcher, mapper)
        {
        }


        [HttpGet("SearchArtists")]
        public async Task<ActionResult<Paging<Artist>>> SearchArtists(string q, int limit = DefaultLimit, int offset = DefaultOffset)
        {
            var artists = await QueryDispatcher.Dispatch(new SearchArtistsQuery(q, limit, offset));
            return await Task.FromResult(Mapper.Map<Paging<Artist>>(artists));
        }

        [HttpGet("SearchAlbums")]
        public async Task<ActionResult<Paging<Album>>> SearchAlbums(string q, int limit = DefaultLimit, int offset = DefaultOffset)
        {
            var albums = await QueryDispatcher.Dispatch(new SearchAlbumsQuery(q, limit, offset));
            return await Task.FromResult(Mapper.Map<Paging<Album>>(albums));
        }

        [HttpGet("SearchTracks")]
        public async Task<ActionResult<Paging<Track>>> SearchTracks(string q, int limit = DefaultLimit, int offset = DefaultOffset)
        {
            var tracks = await QueryDispatcher.Dispatch(new SearchTracksQuery(q, limit, offset));
            return await Task.FromResult(Mapper.Map<Paging<Track>>(tracks));
        }
    }
}