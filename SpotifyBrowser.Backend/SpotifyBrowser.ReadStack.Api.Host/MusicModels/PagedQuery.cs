using SpotifyBrowser.Cqrs.Contracts.ReadStack;

namespace SpotifyBrowser.ReadStack.Api.Host.MusicModels
{
    public abstract class PagedQuery<T>: IQuery<Paging<T>>
        where T: class
    {
        public int Limit { get; }
        public int Offset { get; }

        protected PagedQuery(int limit, int offset)
        {
            Limit = limit;
            Offset = offset;
        }

    }
}
