using System.Collections.Generic;

namespace SpotifyBrowser.WriteStack.Api.Host.MusicModels
{
    public class Artist
    {
        public string Href { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<Image> Images { get; set; }
        public string Uri { get; set; }
        public List<string> Tags { get; set; }
    }
}
