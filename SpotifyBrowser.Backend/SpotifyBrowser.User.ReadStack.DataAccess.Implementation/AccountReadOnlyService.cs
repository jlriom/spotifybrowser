using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using SpotifyBrowser.User.ReadStack.DataAccess.Contracts.Account;
using SpotifyBrowser.User.ReadStack.DataAccess.Contracts.Account.Models;

namespace SpotifyBrowser.User.ReadStack.DataAccess.Implementation
{
    public class AccountReadOnlyService: IAccountReadOnlyService
    {
        private readonly SpotifyBrowserAccountsReadOnlyDbContext _context;

        public AccountReadOnlyService(SpotifyBrowserAccountsReadOnlyDbContext spotifyBrowserAccountsDbContext)
        {
            _context = spotifyBrowserAccountsDbContext;
        }

        public Task<Maybe<AuthContext>> GetAuthContextAsyc(ClaimsPrincipal user)
        {
            var userId = user.Claims.FirstOrDefault( claim  => claim.Type == ClaimTypes.NameIdentifier)?.Value;

            var profile = _context.UserProfiles.Include("UserPermissions").FirstOrDefault(u => u.Id == userId);
            return Task.FromResult(
                profile == null
                    ? Maybe<AuthContext>.None
                    : Maybe<AuthContext>.From(new AuthContext { UserProfile = profile, Claims = user.Claims.Select(c => new SimpleClaim { Type = c.Type, Value = c.Value }).ToList() }));
        }
    }
}
