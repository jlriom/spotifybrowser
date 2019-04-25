using Newtonsoft.Json;

namespace SpotifyApi.Facade.Contracts.Models
{
    public class Error
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}