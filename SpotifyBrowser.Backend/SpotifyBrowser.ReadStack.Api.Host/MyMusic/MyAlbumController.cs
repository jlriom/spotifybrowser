using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using SpotifyBrowser.ReadStack.Api.Host.MusicModels;
using SpotifyBrowser.ReadStack.Aplication.MyMusic.Album;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpotifyBrowser.ReadStack.Api.Host.MyMusic
{
    public class MyAlbumController : MyMusicBaseController
    {

        public MyAlbumController(IQueryDispatcher queryDispatcher, IMapper mapper) : base(queryDispatcher, mapper)
        {
        }

        [HttpGet("GetMyAlbums")]
        public async Task<ActionResult<IEnumerable<Album>>> GetMyAlbums()
        {
            var albums = await QueryDispatcher.Dispatch(new GetMyAlbumsQuery());
            return await Task.FromResult(Mapper.Map<List<Album>>(albums));
        }
    }
}