using Microsoft.EntityFrameworkCore;
using SpotifyBrowser.ReadStack.DataAccess.Contracts.Album;
using SpotifyBrowser.ReadStack.DataAccess.Contracts.Artist;

namespace SpotifyBrowser.ReadStack.DataAccess.Implementation
{
    public class SpotifyBrowserReadOnlyDbContext : DbContext
    {
        public SpotifyBrowserReadOnlyDbContext(DbContextOptions<SpotifyBrowserReadOnlyDbContext> options) : base(options)
        {
        }

        public DbSet<AlbumTag> AlbumTags { get; set; }
        public DbSet<ArtistTag> ArtistTags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlbumTag>().HasKey(t => new { t.UserId, t.AlbumId, t.Tag });
            modelBuilder.Entity<ArtistTag>().HasKey(t => new { t.UserId, t.ArtistId, t.Tag });
        }
    }
}
