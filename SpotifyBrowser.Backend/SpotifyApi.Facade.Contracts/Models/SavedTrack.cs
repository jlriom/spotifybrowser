using System;
using Newtonsoft.Json;

namespace SpotifyApi.Facade.Contracts.Models
{
    public class SavedTrack
    {
        [JsonProperty("added_at")]
        public DateTime AddedAt { get; set; }

        [JsonProperty("track")]
        public FullTrack Track { get; set; }
    }
}