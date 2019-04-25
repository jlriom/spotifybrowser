namespace SpotifyBrowser.Domain
{
    public interface IRepository<in T> where T: IAggregate
    {
        void Save(T aggregate);
    }
}
