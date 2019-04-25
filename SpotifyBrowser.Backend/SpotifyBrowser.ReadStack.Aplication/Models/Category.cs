using System.Collections.Generic;

namespace SpotifyBrowser.ReadStack.Aplication.Models
{
    public class Category
    {
        public string Href { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Image> Icons { get; set; }
    }
}
