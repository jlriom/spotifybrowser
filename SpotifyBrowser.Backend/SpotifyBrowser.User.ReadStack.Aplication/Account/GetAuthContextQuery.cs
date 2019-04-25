using System.Security.Claims;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using SpotifyBrowser.User.ReadStack.Aplication.Account.Models;

namespace SpotifyBrowser.User.ReadStack.Aplication.Account
{
    public class GetAuthContextQuery: IQuery<AuthContext>
    {
        public ClaimsPrincipal User { get; }

        public GetAuthContextQuery(ClaimsPrincipal user)
        {
            User = user;
        }
    }
}
