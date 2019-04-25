using Newtonsoft.Json;

namespace SpotifyApi.Facade.Contracts.Models
{
    public class CategoryList : BasicModel
    {
        [JsonProperty("categories")]
        public Paging<Category> Categories { get; set; }
    }
}