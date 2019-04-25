using System.Collections.Generic;

namespace SpotifyBrowser.ReadStack.Api.Host.MusicModels
{
    public class Category
    {
        public string Href { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Image> Icons { get; set; }
    }
}
