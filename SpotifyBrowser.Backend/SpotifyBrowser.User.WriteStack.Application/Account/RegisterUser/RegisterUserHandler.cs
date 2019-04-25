using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using SpotifyBrowser.Cqrs.Contracts.WriteStack;
using SpotifyBrowser.Cqrs.Implementation;
using SpotifyBrowser.User.WriteStack.Domain.Accounts;

namespace SpotifyBrowser.User.WriteStack.Application.Account.RegisterUser
{
    public class RegisterUserHandler : CommandHandler<RegisterUserCommand>
    {
        private readonly IAccountService _accountService;
        public RegisterUserHandler(ICommandDispatcher bus, IAccountService accountService, ILogger<RegisterUserCommand> logger) : base(bus, logger)
        {
            _accountService = accountService;
        }

        protected override async Task<Result> _Handle(RegisterUserCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            await _accountService.RegisterUserAsync(command.Data.Email, command.Data.FirstName, command.Data.LastName, command.Data.Password, command.Data.ConfirmPassword);
            return Result.Ok();
        }
    }
}
