using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using SpotifyBrowser.ReadStack.Api.Host.MusicModels;
using SpotifyBrowser.ReadStack.Aplication.Music.Album;

namespace SpotifyBrowser.ReadStack.Api.Host.Music
{
    public class AlbumController : MusicBaseController
    {

        public AlbumController(IQueryDispatcher queryDispatcher, IMapper mapper):base(queryDispatcher, mapper)
        {
        }

        [HttpGet("GetAlbum")]
        public async Task<ActionResult<Album>> GetAlbum(string id)
        {
            var album = await QueryDispatcher.Dispatch(new GetAlbumQuery(id));
            return await Task.FromResult(Mapper.Map<Album>(album));
        }

        [HttpGet("GetArtistsAlbums")]
        public async Task<ActionResult<Paging<Album>>> GetArtistsAlbums(string artistId, int limit = DefaultLimit, int offset = DefaultOffset)
        {
            var albums = await QueryDispatcher.Dispatch(new GetArtistsAlbumsQuery(artistId, limit, offset));
            return await Task.FromResult(Mapper.Map<Paging<Album>>(albums));
        }
    }
}