using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using SpotifyBrowser.ReadStack.Api.Host.MusicModels;
using SpotifyBrowser.ReadStack.Aplication.MyMusic.Artist;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpotifyBrowser.ReadStack.Api.Host.MyMusic
{
    public class MyArtistController : MyMusicBaseController
    {

        public MyArtistController(IQueryDispatcher queryDispatcher, IMapper mapper) : base(queryDispatcher, mapper)
        {
        }

        [HttpGet("GetMyArtists")]
        public async Task<ActionResult<IEnumerable<Artist>>> GetMyArtists()
        {
            var artists = await QueryDispatcher.Dispatch(new GetMyArtistsQuery());
            return await Task.FromResult(Mapper.Map<List<Artist>>(artists));
        }
    }
}