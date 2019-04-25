using CSharpFunctionalExtensions;
using MediatR;

namespace SpotifyBrowser.Cqrs.Contracts.WriteStack
{
    public interface ICommand: IRequest<Result>
    {
    }
}
