using System;
using System.Collections.Generic;


namespace SpotifyBrowser.WriteStack.Api.Host.MusicModels
{
    public class Album
    {
        public string AlbumGroup { get; set; }
        public string AlbumType { get; set; }
        public List<Artist> Artists { get; set; }
        public List<string> AvailableMarkets { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public List<Image> Images { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
        public List<string> Tags { get; set; }
    }
}
