using CSharpFunctionalExtensions;
using MediatR;

namespace SpotifyBrowser.Cqrs.Contracts.WriteStack
{
    public interface ICommandHandler<in TCommand>: IRequestHandler<TCommand, Result>
        where TCommand : ICommand
    {
    }
}
