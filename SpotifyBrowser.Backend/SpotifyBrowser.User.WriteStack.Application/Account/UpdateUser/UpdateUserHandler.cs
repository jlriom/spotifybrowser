using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using SpotifyBrowser.Cqrs.Contracts.WriteStack;
using SpotifyBrowser.Cqrs.Implementation;
using SpotifyBrowser.User.WriteStack.Domain.Accounts;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyBrowser.User.WriteStack.Application.Account.UpdateUser
{
    public class UpdateUserHandler : CommandHandler<UpdateUserCommand>
    {
        private readonly IAccountService _accountService;
        public UpdateUserHandler(ICommandDispatcher bus, IAccountService accountService, ILogger<UpdateUserCommand> logger) : base(bus, logger)
        {
            _accountService = accountService;
        }

        protected override async Task<Result> _Handle(UpdateUserCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            await _accountService.UpdateAsync(Bus.User.Id, command.Data.UserId, command.Data.FirstName, command.Data.LastName);
            return Result.Ok();
        }
    }
}
