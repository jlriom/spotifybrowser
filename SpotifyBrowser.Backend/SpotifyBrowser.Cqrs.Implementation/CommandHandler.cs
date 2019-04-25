using System;
using CSharpFunctionalExtensions;
using SpotifyBrowser.Cqrs.Contracts.WriteStack;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SpotifyBrowser.Cqrs.Contracts;

namespace SpotifyBrowser.Cqrs.Implementation
{
    public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        protected readonly IBus Bus;
        protected readonly ILogger<TCommand> Logger;

        protected CommandHandler(ICommandDispatcher bus, ILogger<TCommand> logger)
        {
            Bus = bus;
            Logger = logger;
        }

        public Task<Result> Handle(TCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                using (Logger.BeginScope(typeof(TCommand)))
                {
                    Logger.LogInformation($"Begin: {typeof(TCommand)}");
                    var result = _Handle(command, cancellationToken);
                    Logger.LogInformation($"End: {typeof(TCommand)}");
                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error in {typeof(TCommand)}: {ex.Message}");
                throw;
            }
        }

        protected abstract Task<Result> _Handle(TCommand command, CancellationToken cancellationToken = default(CancellationToken));
    }
}
