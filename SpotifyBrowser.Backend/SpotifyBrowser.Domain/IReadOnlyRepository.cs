namespace SpotifyBrowser.Domain
{
    public interface IReadOnlyRepository<out T> where T: IAggregate
    {
    }
}
