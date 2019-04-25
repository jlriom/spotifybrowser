using SpotifyBrowser.Cqrs.Implementation;

namespace SpotifyBrowser.User.WriteStack.Application.UserManagement.DeleteUser
{
    public class DeleteUserCommand : Command<DeleteUserUserInfo>
    {
        public DeleteUserCommand(DeleteUserUserInfo deleteUserUserInfo) : base(deleteUserUserInfo)
        {
        }
    }
}
