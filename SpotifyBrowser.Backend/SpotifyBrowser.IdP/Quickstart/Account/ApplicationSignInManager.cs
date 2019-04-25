using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SpotifyBrowser.IdP.Models;

namespace SpotifyBrowser.IdP.Quickstart.Account
{
    public class ApplicationSignInManager: SignInManager<ApplicationUser>
    {
        public ApplicationSignInManager(UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<ApplicationUser>> logger, IAuthenticationSchemeProvider schemes) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
        {
        }

        public override Task<bool> CanSignInAsync(ApplicationUser user)
        {
            return !user.EmailConfirmed 
                ? Task.FromResult(false) 
                : base.CanSignInAsync(user);
        }
    }
}
