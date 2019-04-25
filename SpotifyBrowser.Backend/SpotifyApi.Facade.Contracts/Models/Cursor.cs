using Newtonsoft.Json;

namespace SpotifyApi.Facade.Contracts.Models
{
    public class Cursor
    {
        [JsonProperty("after")]
        public string After { get; set; }

        [JsonProperty("before")]
        public string Before { get; set; }
    }
}