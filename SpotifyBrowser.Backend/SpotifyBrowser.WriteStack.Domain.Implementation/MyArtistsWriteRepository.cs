using System.Linq;
using SpotifyBrowser.Domain;
using SpotifyBrowser.WriteStack.Domain.Implementation.Entities;
using SpotifyBrowser.WriteStack.Domain.MyArtists;

namespace SpotifyBrowser.WriteStack.Domain.Implementation
{
    public class MyArtistsWriteRepository: ISpotifyReadOnlyRepository<MyArtist>, IRepository<MyArtist>
    {
        private readonly SpotifyBrowserWriteDbContext _db;

        public MyArtistsWriteRepository(SpotifyBrowserWriteDbContext db)
        {
            _db = db;
        }
        public MyArtist GetByIdForUser(string id, string userId)
        {
            var tags = _db.ArtistTags.Where(t => t.ArtistId == id && t.UserId == userId).Select(t => t.Tag).ToList();
            return new MyArtist(id, userId, tags);
        }

        public void Save(MyArtist aggregate)
        {
            var artistTag = _db.ArtistTags.Where(t => t.ArtistId == aggregate.Id && t.UserId == aggregate.UserId).ToList();
            _db.ArtistTags.RemoveRange(artistTag.Where(artist => !aggregate.ContainsTag(artist.Tag)).ToList());
            _db.ArtistTags.AddRange(aggregate.Tags.Where( t => !artistTag.Select( a => a.Tag).Contains(t)).Select( tag => new ArtistTag {  ArtistId = aggregate.Id, UserId = aggregate.UserId, Tag = tag} ));
            _db.SaveChanges();
        }
    }
}
