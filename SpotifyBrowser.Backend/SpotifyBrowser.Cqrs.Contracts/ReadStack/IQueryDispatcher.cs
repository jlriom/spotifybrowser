using System.Threading;
using System.Threading.Tasks;

namespace SpotifyBrowser.Cqrs.Contracts.ReadStack
{
    public interface IQueryDispatcher: IBus
    {
       Task<TResult> Dispatch<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default(CancellationToken)) where TResult : class ;
    }
}
