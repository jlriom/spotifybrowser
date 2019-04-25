using System.Collections.Generic;

namespace SpotifyBrowser.WriteStack.Domain.MyArtists
{
    public class MyArtist: MyTaggedItem
    {
        public MyArtist(string id, string userId, IEnumerable<string> tags) : base("Artist", id, userId, tags)
        {
        }
    }
}
