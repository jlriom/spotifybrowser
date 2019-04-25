using SpotifyBrowser.Domain;

namespace SpotifyBrowser.WriteStack.Domain
{
    public interface ISpotifyReadOnlyRepository<out T>: IReadOnlyRepository<T> where T: IAggregate
    {
        T GetByIdForUser(string id, string userId);
    }
}
