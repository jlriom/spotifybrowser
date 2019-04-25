using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpotifyBrowser.Cqrs.Contracts.WriteStack;
using SpotifyBrowser.User.WriteStack.Application.UserManagement.ActivateUser;
using SpotifyBrowser.User.WriteStack.Application.UserManagement.DeactivateUser;
using SpotifyBrowser.User.WriteStack.Application.UserManagement.DeleteUser;
using System.Threading.Tasks;

namespace SpotifyBrowser.User.WriteStack.Api.Host.Users
{
    [Authorize(Roles = "Admin")]
    public class UserController: UserBaseController
    {
        protected const int DefaultLimit = 20;
        protected const int DefaultOffset = 0;

        public UserController(ICommandDispatcher commandDispatcher, IMapper mapper) : base(commandDispatcher, mapper)
        {
        }

        [HttpPost("ActivateUser")]
        public async Task<IActionResult> ActivateUserAsync([FromBody] Models.ActivateUserInfo activateUserInfo)
        {
            var activateUser = Mapper.Map<ActivateUserUserInfo>(activateUserInfo);
            return await SendCommand(new ActivateUserCommand(activateUser));
        }

        [HttpPost("DeactivateUser")]
        public async Task<IActionResult> DeactivateUserAsync([FromBody] Models.DeactivateUserInfo deactivateUserInfo)
        {
            var deactivateUser = Mapper.Map<DeactivateUserInfo>(deactivateUserInfo);
            return await SendCommand(new DeactivateUserCommand(deactivateUser));
        }

        [HttpPost("DeleteUser")]
        public async Task<IActionResult> DeleteUserAsync([FromBody] Models.DeleteUserInfo deleteUserInfo)
        {
            var deleteUser = Mapper.Map<DeleteUserUserInfo>(deleteUserInfo);
            return await SendCommand(new DeleteUserCommand(deleteUser));
        }
    }
}
