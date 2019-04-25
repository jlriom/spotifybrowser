using System.Collections.Generic;

namespace SpotifyBrowser.WriteStack.Domain.MyAlbums
{
    public class MyAlbum : MyTaggedItem
    {
        public MyAlbum(string id, string userId, IEnumerable<string> tags): base("Album", id, userId, tags)
        {
        }
    }
}
