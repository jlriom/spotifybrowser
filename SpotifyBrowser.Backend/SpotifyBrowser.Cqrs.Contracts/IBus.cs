namespace SpotifyBrowser.Cqrs.Contracts
{
    public interface IBus
    {
        IUser User { get; }

        void Publish (IEvent @event);
    }
}
