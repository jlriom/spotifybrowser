using MediatR;

namespace SpotifyBrowser.Cqrs.Contracts.ReadStack
{
    public interface IQuery<out TResult>: IRequest<TResult> where TResult : class
    {
    }
}
