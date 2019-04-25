using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;

namespace SpotifyBrowser.ReadStack.Api.Host.Music
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MusicBaseController : ControllerBase
    {
        protected const int DefaultLimit = 20;
        protected const int DefaultOffset = 0;

        protected readonly IQueryDispatcher QueryDispatcher;
        protected readonly IMapper Mapper;

        public MusicBaseController(IQueryDispatcher queryDispatcher, IMapper mapper)
        {
            QueryDispatcher = queryDispatcher;
            Mapper = mapper;
        }
    }
}