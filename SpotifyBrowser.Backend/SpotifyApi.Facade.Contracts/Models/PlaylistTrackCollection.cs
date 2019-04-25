using Newtonsoft.Json;

namespace SpotifyApi.Facade.Contracts.Models
{
    public class PlaylistTrackCollection
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
}