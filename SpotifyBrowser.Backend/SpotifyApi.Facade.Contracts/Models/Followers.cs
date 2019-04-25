using Newtonsoft.Json;

namespace SpotifyApi.Facade.Contracts.Models
{
    public class Followers
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
}