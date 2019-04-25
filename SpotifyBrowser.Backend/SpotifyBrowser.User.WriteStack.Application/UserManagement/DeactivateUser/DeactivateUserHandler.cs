using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using SpotifyBrowser.Cqrs.Contracts.WriteStack;
using SpotifyBrowser.Cqrs.Implementation;
using SpotifyBrowser.User.WriteStack.Domain.UserManagement;

namespace SpotifyBrowser.User.WriteStack.Application.UserManagement.DeactivateUser
{
    public class DeactivateUserHandler : CommandHandler<DeactivateUserCommand>
    {
        private readonly IUserService _userService;
        public DeactivateUserHandler(ICommandDispatcher bus, IUserService userService, ILogger<DeactivateUserCommand> logger) : base(bus, logger)
        {
            _userService = userService;
        }

        protected override async Task<Result> _Handle(DeactivateUserCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            await _userService.DeactivateUserAsync(Bus.User.Id, command.Data.UserId);
            return Result.Ok();
        }
    }
}
