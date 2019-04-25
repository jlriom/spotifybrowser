﻿using System.Collections.Generic;

namespace SpotifyBrowser.ReadStack.Aplication.Models
{
    public class Artist
    {
        public string Href { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<Image> Images { get; set; }
        public string Uri { get; set; }
        public Dictionary<string, string> ExternalUrls { get; set; }
        public List<string> Tags { get; set; }
    }
}
