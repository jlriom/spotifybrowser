using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using SpotifyBrowser.Cqrs.Contracts.WriteStack;
using SpotifyBrowser.Cqrs.Implementation;
using SpotifyBrowser.User.WriteStack.Application.Account.RegisterUser;
using SpotifyBrowser.User.WriteStack.Domain.Accounts;

namespace SpotifyBrowser.User.WriteStack.Application.Account.UnregisterUser
{
    public class UnregisterUserHandler : CommandHandler<UnregisterUserCommand>
    {
        private readonly IAccountService _accountService;
        public UnregisterUserHandler(ICommandDispatcher bus, IAccountService accountService, ILogger<UnregisterUserCommand> logger) : base(bus, logger)
        {
            _accountService = accountService;
        }

        protected override async Task<Result> _Handle(UnregisterUserCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            await _accountService.UnregisterAsync(Bus.User.Id, command.Data.UserId);
            return Result.Ok();
        }
    }
}
