using System.Collections.Generic;

namespace SpotifyBrowser.ReadStack.DataAccess.Contracts.Artist
{
    public interface IArtistTagsReadOnlyRepository
    {
        IEnumerable<string> GetTags(string userId);
        IEnumerable<ArtistTag> GetTaggedArtists(string userId, IEnumerable<string> tags = default(IEnumerable<string>));
    }
}
