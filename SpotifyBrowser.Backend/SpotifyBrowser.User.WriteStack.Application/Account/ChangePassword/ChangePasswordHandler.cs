using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using SpotifyBrowser.Cqrs.Contracts.WriteStack;
using SpotifyBrowser.Cqrs.Implementation;
using SpotifyBrowser.User.WriteStack.Domain.Accounts;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyBrowser.User.WriteStack.Application.Account.ChangePassword
{
    public class ChangePasswordHandler : CommandHandler<ChangePasswordCommand>
    {
        private readonly IAccountService _accountService;
        public ChangePasswordHandler(ICommandDispatcher bus, IAccountService accountService, ILogger<ChangePasswordCommand> logger) : base(bus, logger)
        {
            _accountService = accountService;
        }

        protected override async Task<Result> _Handle(ChangePasswordCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            await _accountService.ChangePasswordAsync(Bus.User.Id, command.Data.UserId, command.Data.OldPassword, command.Data.NewPassword, command.Data.ConfirmNewPassword);
            return Result.Ok();
        }
    }
}
