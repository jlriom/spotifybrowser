using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SpotifyBrowser.User.Shared.Identity.Storage
{
    public class SpotifyBrowserIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public SpotifyBrowserIdentityDbContext(DbContextOptions<SpotifyBrowserIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
