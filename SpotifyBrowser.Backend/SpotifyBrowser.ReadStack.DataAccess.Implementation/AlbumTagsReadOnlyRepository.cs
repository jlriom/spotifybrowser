using SpotifyBrowser.ReadStack.DataAccess.Contracts;
using System.Collections.Generic;
using System.Linq;
using SpotifyBrowser.ReadStack.DataAccess.Contracts.Album;

namespace SpotifyBrowser.ReadStack.DataAccess.Implementation
{
    public class AlbumTagsReadOnlyRepository : IAlbumTagsReadOnlyRepository
    {
        private readonly SpotifyBrowserReadOnlyDbContext _db;

        public AlbumTagsReadOnlyRepository(SpotifyBrowserReadOnlyDbContext db)
        {
            _db = db;
        }
        public IEnumerable<AlbumTag> GetTaggedAlbums(string userId, IEnumerable<string> tags = default(IEnumerable<string>))
        {
            return tags == null
                ? _db.AlbumTags.Where(a => a.UserId == userId).ToList()
                : _db.AlbumTags.Where(a => a.UserId == userId && tags.Contains(a.Tag)).ToList();
        }

        public IEnumerable<string> GetTags(string userId)
        {
            return _db.AlbumTags.Where(a => a.UserId == userId).Select(a => a.Tag).Distinct().ToList();
        }
    }
}
