using MediatR;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using System.Threading;
using System.Threading.Tasks;
using SpotifyBrowser.Cqrs.Contracts;

namespace SpotifyBrowser.Cqrs.Implementation
{
    public class QueryDispatcher: Bus, IQueryDispatcher
    {
        public QueryDispatcher(IMediator mediator, IUser user) : base(mediator, user)
        {
        }

        public Task<TResult> Dispatch<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default(CancellationToken)) where TResult : class
        {
            return Mediator.Send(query, cancellationToken);
        }
    }
}
