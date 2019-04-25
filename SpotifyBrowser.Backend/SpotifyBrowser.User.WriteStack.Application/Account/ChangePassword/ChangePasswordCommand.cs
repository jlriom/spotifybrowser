using SpotifyBrowser.Cqrs.Implementation;

namespace SpotifyBrowser.User.WriteStack.Application.Account.ChangePassword
{
    public class ChangePasswordCommand : Command<ChangePasswordInfo>
    {
        public ChangePasswordCommand(ChangePasswordInfo changePasswordInfo): base(changePasswordInfo)
        {
        }
    }
}
