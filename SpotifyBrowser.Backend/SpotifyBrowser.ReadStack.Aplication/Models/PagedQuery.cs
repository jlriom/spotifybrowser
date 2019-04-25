using SpotifyBrowser.Cqrs.Contracts.ReadStack;

namespace SpotifyBrowser.ReadStack.Aplication.Models
{
    public abstract class PagedQuery2<T>: IQuery<Paging2<T>>
        where T: class
    {
        public int Limit { get; }
        public int Offset { get; }

        protected PagedQuery2(int limit, int offset)
        {
            Limit = limit;
            Offset = offset;
        }

    }
}
