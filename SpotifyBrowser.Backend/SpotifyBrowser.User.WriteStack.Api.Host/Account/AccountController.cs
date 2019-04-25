using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpotifyBrowser.Cqrs.Contracts.WriteStack;
using SpotifyBrowser.User.WriteStack.Application.Account.ChangePassword;
using SpotifyBrowser.User.WriteStack.Application.Account.RegisterUser;
using SpotifyBrowser.User.WriteStack.Application.Account.UnregisterUser;
using SpotifyBrowser.User.WriteStack.Application.Account.UpdateUser;
using System.Threading.Tasks;



namespace SpotifyBrowser.User.WriteStack.Api.Host.Account
{
    public class AccountController : UserBaseController
    {
        public AccountController(ICommandDispatcher commandDispatcher, IMapper mapper)
            : base(commandDispatcher, mapper)
        {
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterUserInfo registerUserInfo)
        {
            return await SendCommand(new RegisterUserCommand(registerUserInfo));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateUserInfo updateUserInfo)
        {
            return await SendCommand(new UpdateUserCommand(updateUserInfo));
        }


        [HttpPost("Unregister")]
        public async Task<IActionResult> UnregisterAsync([FromBody] UnregisterUserInfo unregisterUserInfo)
        {
            return await SendCommand(new UnregisterUserCommand(unregisterUserInfo));
        }
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePasswordAsync([FromBody] ChangePasswordInfo changePasswordInfo)
        {
            return await SendCommand(new ChangePasswordCommand(changePasswordInfo));
        }
    }
}