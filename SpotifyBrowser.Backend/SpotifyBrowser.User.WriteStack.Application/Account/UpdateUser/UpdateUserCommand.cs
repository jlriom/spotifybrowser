using SpotifyBrowser.Cqrs.Implementation;

namespace SpotifyBrowser.User.WriteStack.Application.Account.UpdateUser
{
    public class UpdateUserCommand : Command<UpdateUserInfo>
    {
        public UpdateUserCommand(UpdateUserInfo updateUserInfo) : base(updateUserInfo)
        {
        }
    }
}
