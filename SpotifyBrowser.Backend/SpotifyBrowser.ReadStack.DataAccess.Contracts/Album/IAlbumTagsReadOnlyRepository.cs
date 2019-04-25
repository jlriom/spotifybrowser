using System.Collections.Generic;

namespace SpotifyBrowser.ReadStack.DataAccess.Contracts.Album
{
    public interface IAlbumTagsReadOnlyRepository
    {
        IEnumerable<string> GetTags(string userId);
        IEnumerable<AlbumTag> GetTaggedAlbums(string userId, IEnumerable<string> tags = default(IEnumerable<string>));
    }
}
