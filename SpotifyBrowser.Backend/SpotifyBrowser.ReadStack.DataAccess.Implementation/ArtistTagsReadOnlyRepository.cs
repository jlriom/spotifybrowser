using SpotifyBrowser.ReadStack.DataAccess.Contracts.Artist;
using System.Collections.Generic;
using System.Linq;

namespace SpotifyBrowser.ReadStack.DataAccess.Implementation
{
    public class ArtistTagsReadOnlyRepository : IArtistTagsReadOnlyRepository
    {
        private readonly SpotifyBrowserReadOnlyDbContext _db;

        public ArtistTagsReadOnlyRepository(SpotifyBrowserReadOnlyDbContext db)
        {
            _db = db;
        }
        public IEnumerable<ArtistTag> GetTaggedArtists(string userId, IEnumerable<string> tags = default(IEnumerable<string>))
        {
            return tags == null 
                ? _db.ArtistTags.Where(a => a.UserId == userId).ToList() 
                : _db.ArtistTags.Where(a => a.UserId == userId && tags.Contains(a.Tag)).ToList();
        }

        public IEnumerable<string> GetTags(string userId)
        {
            return _db.ArtistTags.Where(a => a.UserId == userId).Select(a => a.Tag).Distinct().ToList();
        }
    }
}
