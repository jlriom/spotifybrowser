using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;

namespace SpotifyBrowser.User.ReadStack.Api.Host
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserBaseController : ControllerBase
    {
        protected readonly IQueryDispatcher QueryDispatcher;
        protected readonly IMapper Mapper;

        public UserBaseController(IQueryDispatcher queryDispatcher, IMapper mapper)
        {
            QueryDispatcher = queryDispatcher;
            Mapper = mapper;
        }
    }
}
