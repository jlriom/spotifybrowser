using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpotifyBrowser.Cqrs.Contracts.WriteStack;
using SpotifyBrowser.WriteStack.Api.Host.MyMusicModels;
using SpotifyBrowser.WriteStack.Application.MyMusic.Album;
using System.Threading.Tasks;

namespace SpotifyBrowser.WriteStack.Api.Host.MyMusic
{
    public class MyAlbumController : MyMusicBaseController
    {

        public MyAlbumController(ICommandDispatcher commandDispatcher, IMapper mapper) : base(commandDispatcher, mapper)
        {
        }

        [HttpPost("TagAlbum")]
        public async Task<ActionResult> TagAlbum([FromBody] MyAlbumTag myAlbumTag)
        {
            return await SendCommand(new TagAlbumCommand(myAlbumTag.AlbumId, myAlbumTag.Tag));
        }

        [HttpPost("UntagAlbum")]
        public async Task<ActionResult> UntagAlbum([FromBody]  MyAlbumTag myAlbumTag)
        {
            return await SendCommand(new UntagAlbumCommand(myAlbumTag.AlbumId, myAlbumTag.Tag));
        }
    }
}