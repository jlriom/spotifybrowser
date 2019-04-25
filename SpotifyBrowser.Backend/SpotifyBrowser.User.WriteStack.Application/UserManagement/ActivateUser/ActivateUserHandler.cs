using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using SpotifyBrowser.Cqrs.Contracts.WriteStack;
using SpotifyBrowser.Cqrs.Implementation;
using System.Threading;
using System.Threading.Tasks;
using SpotifyBrowser.User.WriteStack.Domain.UserManagement;

namespace SpotifyBrowser.User.WriteStack.Application.UserManagement.ActivateUser
{
    public class ActivateUserHandler : CommandHandler<ActivateUserCommand>
    {
        private readonly IUserService _userService;
        public ActivateUserHandler(ICommandDispatcher bus, IUserService userService,  ILogger<ActivateUserCommand> logger) : base(bus, logger)
        {
            _userService = userService;
        }

        protected override async Task<Result> _Handle(ActivateUserCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            await _userService.ActivateUserAsync(Bus.User.Id, command.Data.UserId);
            return Result.Ok();
        }
    }
}
