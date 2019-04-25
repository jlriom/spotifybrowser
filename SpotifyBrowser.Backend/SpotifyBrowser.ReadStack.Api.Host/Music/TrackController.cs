using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using SpotifyBrowser.ReadStack.Api.Host.MusicModels;
using SpotifyBrowser.ReadStack.Aplication.Music.Track;

namespace SpotifyBrowser.ReadStack.Api.Host.Music
{
    public class TrackController : MusicBaseController
    {
        public TrackController(IQueryDispatcher queryDispatcher, IMapper mapper) : base(queryDispatcher, mapper)
        {
        }

        [HttpGet("GetAlbumTracks")]
        public async Task<ActionResult<Paging<Track>>> GetAlbumTracks(string albumId, int limit = DefaultLimit, int offset = DefaultOffset)
        {
            var tracks = await QueryDispatcher.Dispatch(new GetAlbumTracksQuery(albumId, limit, offset));
            return await Task.FromResult(Mapper.Map<Paging<Track>>(tracks));
        }

        [HttpGet("GetArtistsTopTracks")]
        public async Task<ActionResult<IEnumerable<Track>>> GetArtistsTopTracks(string artistId, string country)
        {
            var tracks = await QueryDispatcher.Dispatch(new GetArtistsTopTracksQuery(artistId, country));
            return await Task.FromResult(Mapper.Map<List<Track>>(tracks));
        }

        [HttpGet("GetTrack")]
        public async Task<ActionResult<Track>> GetTrack(string trackId)
        {
            var track = await QueryDispatcher.Dispatch(new GetTrackQuery(trackId));
            return await Task.FromResult(Mapper.Map<Track>(track));
        }
    }
}