using System;
using SpotifyBrowser.Cqrs.Contracts;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SpotifyBrowser.Cqrs.Implementation
{
    public abstract class QueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
        where TResult : class
    {
        protected readonly IBus Bus;
        protected readonly ILogger<TQuery> Logger;

        protected QueryHandler(IQueryDispatcher bus, ILogger<TQuery> logger)
        {
            Bus = bus;
            Logger = logger;
        }

        public Task<TResult> Handle(TQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                using (Logger.BeginScope(typeof(TQuery)))
                {
                    Logger.LogInformation($"Begin: {typeof(TQuery)}");
                    var result = _Handle(query, cancellationToken);
                    Logger.LogInformation($"End: {typeof(TQuery)}");
                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error in {typeof(TQuery)}: {ex.Message}");
                throw;
            }
        }

        protected abstract Task<TResult> _Handle(TQuery query, CancellationToken cancellationToken = default(CancellationToken));
    }
}