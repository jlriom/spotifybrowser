using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;

namespace SpotifyBrowser.ReadStack.Api.Host.MyMusic
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MyMusicBaseController : ControllerBase
    {

        protected readonly IQueryDispatcher QueryDispatcher;
        protected readonly IMapper Mapper;

        public MyMusicBaseController(IQueryDispatcher queryDispatcher, IMapper mapper)
        {
            QueryDispatcher = queryDispatcher;
            Mapper = mapper;
        }
    }
}