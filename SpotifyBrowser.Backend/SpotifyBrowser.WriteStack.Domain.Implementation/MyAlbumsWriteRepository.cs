using SpotifyBrowser.Domain;
using SpotifyBrowser.WriteStack.Domain.Implementation.Entities;
using SpotifyBrowser.WriteStack.Domain.MyAlbums;
using System.Linq;

namespace SpotifyBrowser.WriteStack.Domain.Implementation
{
    public class MyAlbumsWriteRepository : ISpotifyReadOnlyRepository<MyAlbum>, IRepository<MyAlbum>
    {
        private readonly SpotifyBrowserWriteDbContext _db;

        public MyAlbumsWriteRepository(SpotifyBrowserWriteDbContext db)
        {
            _db = db;
        }
        public MyAlbum GetByIdForUser(string id, string userId)
        {
            var tags = _db.AlbumTags.Where(t => t.AlbumId == id && t.UserId == userId).Select(t => t.Tag).ToList();
            return new MyAlbum(id, userId, tags);
        }

        public void Save(MyAlbum aggregate)
        {
            var albumTag = _db.AlbumTags.Where(t => t.AlbumId == aggregate.Id && t.UserId == aggregate.UserId).ToList();
            _db.AlbumTags.RemoveRange(albumTag.Where(album => !aggregate.ContainsTag(album.Tag)).ToList());
            _db.AlbumTags.AddRange(aggregate.Tags.Where(t => !albumTag.Select(a => a.Tag).Contains(t)).Select(tag => new AlbumTag { AlbumId = aggregate.Id, UserId = aggregate.UserId, Tag = tag }));
            _db.SaveChanges();
        }
    }
}
