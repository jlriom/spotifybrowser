using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using SpotifyBrowser.Cqrs.Contracts.WriteStack;

namespace SpotifyBrowser.WriteStack.Api.Host.MyMusic
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MyMusicBaseController : ControllerBase
    {

        protected readonly ICommandDispatcher CommandDispatcher;
        protected readonly IMapper Mapper;

        public MyMusicBaseController(ICommandDispatcher commandDispatcher, IMapper mapper)
        {
            CommandDispatcher = commandDispatcher;
            Mapper = mapper;
        }

        protected async Task<ActionResult> SendCommand(ICommand command)
        {
            var result = await CommandDispatcher.Dispatch(command);

            if (!result.IsSuccess)
                return await Task.FromResult(StatusCode(StatusCodes.Status500InternalServerError, result.Error));

            return await Task.FromResult(Ok());
        }

    }
}