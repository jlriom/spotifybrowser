using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace SpotifyBrowser.Cqrs.Contracts.WriteStack
{
    public interface ICommandDispatcher: IBus
    {
        Task<Result> Dispatch(ICommand command, CancellationToken cancellationToken = default(CancellationToken));
    }
}
