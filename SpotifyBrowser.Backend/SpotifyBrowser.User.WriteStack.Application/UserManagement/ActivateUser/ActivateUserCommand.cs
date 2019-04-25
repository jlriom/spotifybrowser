using SpotifyBrowser.Cqrs.Implementation;

namespace SpotifyBrowser.User.WriteStack.Application.UserManagement.ActivateUser
{
    public class ActivateUserCommand : Command<ActivateUserUserInfo>
    {
        public ActivateUserCommand(ActivateUserUserInfo activateUserUserInfo) : base(activateUserUserInfo)
        {
        }
    }
}
