using System.Collections.Generic;
using SpotifyApi.Facade.Contracts.Models;

namespace SpotifyBrowser.ReadStack.Aplication.Models
{
    public class FullPlaylist
    {
        public bool Collaborative { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string> ExternalUrls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public List<Image> Images { get; set; }
        public string Name { get; set; }
        public PublicProfile Owner { get; set; }
        public bool Public { get; set; }
        public string SnapshotId { get; set; }
        public Paging<PlaylistTrack> Tracks { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }
}
