using MediatR;
using Microsoft.Extensions.Logging;
using SpotifyBrowser.Cqrs.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyBrowser.Cqrs.Implementation
{
    public abstract class EventHandler<TEvent> : INotificationHandler<TEvent> where TEvent: IEvent
    {
        protected readonly IBus Bus;
        protected readonly ILogger<IEvent> Logger;

        protected EventHandler(IBus bus, ILogger<IEvent> logger)
        {
            Bus = bus;
            Logger = logger;
        }

        public Task Handle(TEvent @event, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                using (Logger.BeginScope(typeof(TEvent)))
                {
                    Logger.LogInformation($"Begin: {typeof(TEvent)}");
                    var result = _Handle(@event, cancellationToken);
                    Logger.LogInformation($"End: {typeof(TEvent)}");
                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error in {typeof(TEvent)}: {ex.Message}");
                throw;
            }
        }

        protected abstract Task _Handle(TEvent notification, CancellationToken cancellationToken = default(CancellationToken));
    }
}
