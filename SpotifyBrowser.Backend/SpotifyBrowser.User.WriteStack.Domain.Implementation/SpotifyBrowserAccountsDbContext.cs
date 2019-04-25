using Microsoft.EntityFrameworkCore;
using SpotifyBrowser.User.WriteStack.Domain.Implementation.Models;

namespace SpotifyBrowser.User.WriteStack.Domain.Implementation
{
    public class SpotifyBrowserAccountsDbContext : DbContext
    {
        public SpotifyBrowserAccountsDbContext(DbContextOptions<SpotifyBrowserAccountsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }

    }
}
