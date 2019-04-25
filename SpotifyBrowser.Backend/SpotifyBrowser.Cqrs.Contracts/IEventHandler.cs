using System.Threading;
using System.Threading.Tasks;


namespace SpotifyBrowser.Cqrs.Contracts
{
    public interface IEventHandler
    {
        Task Handle(IEvent @event, CancellationToken cancellationToken = default(CancellationToken));
    }
}
