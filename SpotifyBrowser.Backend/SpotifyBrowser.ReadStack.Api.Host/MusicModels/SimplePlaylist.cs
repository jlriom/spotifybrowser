using System.Collections.Generic;

namespace SpotifyBrowser.ReadStack.Api.Host.MusicModels
{
    public class SimplePlaylist
    {
        public bool Collaborative { get; set; }
        public Dictionary<string, string> ExternalUrls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public List<Image> Images { get; set; }
        public string Name { get; set; }
        public PublicProfile Owner { get; set; }
        public bool? Public { get; set; }
        public string SnapshotId { get; set; }
        public PlaylistTrackCollection Tracks { get; set; }
        public string Type { get; set; }

        public string Uri { get; set; }
    }
}
