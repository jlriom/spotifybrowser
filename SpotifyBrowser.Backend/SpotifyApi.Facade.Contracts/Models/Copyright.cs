using Newtonsoft.Json;

namespace SpotifyApi.Facade.Contracts.Models
{
    public class Copyright
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}