using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using SpotifyBrowser.User.ReadStack.Api.Host.Account.Model;
using SpotifyBrowser.User.ReadStack.Aplication.Account;
using System.Threading.Tasks;



namespace SpotifyBrowser.User.ReadStack.Api.Host.Account
{
    public class AccountController : UserBaseController
    {
        public AccountController(IQueryDispatcher queryDispatcher, IMapper mapper)
            : base(queryDispatcher, mapper)
        {
        }

        [HttpGet("AuthContext")]
        public async Task<ActionResult<AuthContext>> GetAuthContext()
        {
            var authContext = await QueryDispatcher.Dispatch(new GetAuthContextQuery(User));
            return await Task.FromResult(Mapper.Map<AuthContext>(authContext));
        }
    }
}