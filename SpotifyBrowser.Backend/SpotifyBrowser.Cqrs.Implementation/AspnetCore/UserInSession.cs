using Microsoft.AspNetCore.Http;
using SpotifyBrowser.Cqrs.Contracts;
using System.Security.Claims;

namespace SpotifyBrowser.Cqrs.Implementation.AspnetCore
{
    public class UserInSession : IUser
    {
        public string Id { get; }

        public UserInSession(IHttpContextAccessor httpContextAccessor)
        {
            Id = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
