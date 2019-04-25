using SpotifyBrowser.Cqrs.Implementation;

namespace SpotifyBrowser.User.WriteStack.Application.Account.UnregisterUser
{
    public class UnregisterUserCommand : Command<UnregisterUserInfo>
    {
        public UnregisterUserCommand(UnregisterUserInfo unregisterUserInfo) : base(unregisterUserInfo)
        {
        }
    }
}
