using SpotifyBrowser.Cqrs.Implementation;

namespace SpotifyBrowser.User.WriteStack.Application.UserManagement.DeactivateUser
{
    public class DeactivateUserCommand : Command<DeactivateUserInfo>
    {
        public DeactivateUserCommand(DeactivateUserInfo deactivateUserUserInfo) : base(deactivateUserUserInfo)
        {
        }
    }
}
