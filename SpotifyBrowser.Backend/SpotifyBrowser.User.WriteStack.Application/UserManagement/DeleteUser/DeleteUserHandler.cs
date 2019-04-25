using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using SpotifyBrowser.Cqrs.Contracts.WriteStack;
using SpotifyBrowser.Cqrs.Implementation;
using SpotifyBrowser.User.WriteStack.Domain.UserManagement;

namespace SpotifyBrowser.User.WriteStack.Application.UserManagement.DeleteUser
{
    public class DeleteUserHandler : CommandHandler<DeleteUserCommand>
    {
        private readonly IUserService _userService;
        public DeleteUserHandler(ICommandDispatcher bus, IUserService userService, ILogger<DeleteUserCommand> logger) : base(bus, logger)
        {
            _userService = userService;
        }

        protected override async Task<Result> _Handle(DeleteUserCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            await _userService.DeleteUserAsync(Bus.User.Id, command.Data.UserId);
            return Result.Ok();
        }
    }
}
