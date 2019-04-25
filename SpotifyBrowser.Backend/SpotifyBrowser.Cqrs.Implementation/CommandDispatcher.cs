using CSharpFunctionalExtensions;
using MediatR;
using SpotifyBrowser.Cqrs.Contracts.WriteStack;
using System.Threading;
using System.Threading.Tasks;
using SpotifyBrowser.Cqrs.Contracts;

namespace SpotifyBrowser.Cqrs.Implementation
{
    public class CommandDispatcher: Bus, ICommandDispatcher
    {
        public CommandDispatcher(IMediator mediator, IUser user) : base(mediator, user)
        {
        }

        public Task<Result> Dispatch(ICommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Mediator.Send(command, cancellationToken);
        }
    }
}
