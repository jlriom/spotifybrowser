using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using SpotifyBrowser.Cqrs.Contracts.WriteStack;
using SpotifyBrowser.WriteStack.Api.Host.MyMusicModels;
using SpotifyBrowser.WriteStack.Application.MyMusic.Artist;
using System.Threading.Tasks;

namespace SpotifyBrowser.WriteStack.Api.Host.MyMusic
{
    public class MyArtistController : MyMusicBaseController
    {

        public MyArtistController(ICommandDispatcher commandDispatcher, IMapper mapper) : base(commandDispatcher, mapper)
        {
        }


        [HttpPost("TagArtist")]
        public async Task<ActionResult> TagArtist([FromBody] MyArtistTag artistTag)
        {
            return await SendCommand(new TagArtistCommand(artistTag.ArtistId, artistTag.Tag));
        }

        [HttpPost("UntagArtist")]
        public async Task<ActionResult> UntagArtist([FromBody] MyArtistTag artistTag)
        {
            return await SendCommand(new UntagArtistCommand(artistTag.ArtistId, artistTag.Tag));
        }
    }
}