using System;
using Newtonsoft.Json;

namespace SpotifyApi.Facade.Contracts.Models
{
    public class PlaylistTrack
    {
        [JsonProperty("added_at")]
        public DateTime AddedAt { get; set; }

        [JsonProperty("added_by")]
        public PublicProfile AddedBy { get; set; }

        [JsonProperty("track")]
        public FullTrack Track { get; set; }

        [JsonProperty("is_local")]
        public Boolean IsLocal { get; set; }
    }
}