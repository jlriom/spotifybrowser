using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using SpotifyBrowser.User.ReadStack.Aplication.UserManagement;
using System.Threading.Tasks;

namespace SpotifyBrowser.User.ReadStack.Api.Host.Users
{
    [Authorize(Roles = "Admin")]
    public class UserController: UserBaseController
    {
        protected const int DefaultLimit = 20;
        protected const int DefaultOffset = 0;

        public UserController(IQueryDispatcher queryDispatcher, IMapper mapper) : base(queryDispatcher, mapper)
        {
        }

        [HttpGet("GetUsers")]
        public async Task<Models.Paging<Models.User>> GetUsersAsync([FromQuery] int userState = -1, string emailSearchPattern = "", int limit = DefaultLimit, int offset = DefaultOffset)
        {
            var users = await QueryDispatcher.Dispatch(new GetUsersQuery(userState, emailSearchPattern, limit, offset ));
            return await Task.FromResult(Mapper.Map<Models.Paging<Models.User>>(users));
        }

        [HttpGet("GetUsersEmailBySearchPattern")]
        public async Task<IEnumerable<string>> GetUsersEmailBySearchPatternAsync([FromQuery] string emailSearchPattern = "")
        {
            var usersEmail = await QueryDispatcher.Dispatch(new GetUsersEmailBySearchPatternQuery(emailSearchPattern));
            return await Task.FromResult(usersEmail);
        }

    }
}
