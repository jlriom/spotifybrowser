using Microsoft.EntityFrameworkCore;
using SpotifyBrowser.User.ReadStack.DataAccess.Contracts.Account.Models;

namespace SpotifyBrowser.User.ReadStack.DataAccess.Implementation
{
    public class SpotifyBrowserAccountsReadOnlyDbContext : DbContext
    {
        public SpotifyBrowserAccountsReadOnlyDbContext(DbContextOptions<SpotifyBrowserAccountsReadOnlyDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
    }
}
