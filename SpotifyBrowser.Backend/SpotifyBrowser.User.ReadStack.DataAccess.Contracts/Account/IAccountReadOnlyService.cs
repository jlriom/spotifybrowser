using System.Security.Claims;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using SpotifyBrowser.User.ReadStack.DataAccess.Contracts.Account.Models;

namespace SpotifyBrowser.User.ReadStack.DataAccess.Contracts.Account
{
    public interface IAccountReadOnlyService
    {
        Task<Maybe<AuthContext>> GetAuthContextAsyc(ClaimsPrincipal user);
    }
}
