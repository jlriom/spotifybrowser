using Microsoft.EntityFrameworkCore;
using SpotifyBrowser.WriteStack.Domain.Implementation.Entities;

namespace SpotifyBrowser.WriteStack.Domain.Implementation
{
    public class SpotifyBrowserWriteDbContext : DbContext
    {
        public SpotifyBrowserWriteDbContext(DbContextOptions<SpotifyBrowserWriteDbContext> options) : base(options)
        {
        }

        public DbSet<AlbumTag> AlbumTags { get; set; }
        public DbSet<ArtistTag> ArtistTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlbumTag>().HasKey(t => new {t.UserId, t.AlbumId, t.Tag});
            modelBuilder.Entity<ArtistTag>().HasKey(t => new { t.UserId, t.ArtistId, t.Tag });
        }
    }
}
