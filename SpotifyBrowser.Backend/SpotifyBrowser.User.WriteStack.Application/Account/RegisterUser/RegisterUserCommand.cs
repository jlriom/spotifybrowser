using SpotifyBrowser.Cqrs.Implementation;

namespace SpotifyBrowser.User.WriteStack.Application.Account.RegisterUser
{
    public class RegisterUserCommand : Command<RegisterUserInfo>
    {
        public RegisterUserCommand(RegisterUserInfo registerUserInfo): base(registerUserInfo)
        {
        }
    }
}
