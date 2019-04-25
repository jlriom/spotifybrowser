using System.Collections.Generic;

namespace SpotifyBrowser.ReadStack.Api.Host.MusicModels
{
    public class Paging<T>
    {
        public string Href { get; set; }
        public IEnumerable<T> Items { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public int Total { get; set; }
    }
}
