using SpotifyBrowser.Cqrs.Contracts.WriteStack;

namespace SpotifyBrowser.Cqrs.Implementation
{
    public class Command<T>: ICommand where T: class
    {
        public T Data { get; }

        public Command(T data)
        {
            Data = data;
        }
    }
}
