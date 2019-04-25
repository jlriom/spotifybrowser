using System;
using Newtonsoft.Json;

namespace SpotifyApi.Facade.Contracts.Models
{
    public class SavedAlbum
    {
        [JsonProperty("added_at")]
        public DateTime AddedAt { get; set; }

        [JsonProperty("album")]
        public FullAlbum Album { get; set; }
    }
}