using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using SpotifyBrowser.ReadStack.Api.Host.MusicModels;
using SpotifyBrowser.ReadStack.Aplication.Music.Artist;

namespace SpotifyBrowser.ReadStack.Api.Host.Music
{
    public class ArtistController : MusicBaseController
    {
        public ArtistController(IQueryDispatcher queryDispatcher, IMapper mapper):base(queryDispatcher, mapper)
        {
        }

        [HttpGet("GetArtist")]
        public async Task<ActionResult<Artist>> GetArtist(string artistId)
        {
            var artist = await QueryDispatcher.Dispatch(new GetArtistQuery(artistId));
            return await Task.FromResult(Mapper.Map<Artist>(artist));
        }

        [HttpGet("GetRelatedArtists")]
        public async Task<ActionResult<IEnumerable<Artist>>> GetRelatedArtists(string artistId)
        {
            var artists = await QueryDispatcher.Dispatch(new GetRelatedArtistsQuery(artistId));
            return await Task.FromResult(Mapper.Map<List<Artist>>(artists));
        }
    }
}