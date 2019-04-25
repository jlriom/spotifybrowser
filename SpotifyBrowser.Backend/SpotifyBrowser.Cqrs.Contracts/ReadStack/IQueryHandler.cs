using MediatR;

namespace SpotifyBrowser.Cqrs.Contracts.ReadStack
{
    public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
        where TResult: class
    {
    }
}
