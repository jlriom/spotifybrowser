using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpotifyApi.Facade.Contracts.Models
{
    public class SeveralTracks : BasicModel
    {
        [JsonProperty("tracks")]
        public List<FullTrack> Tracks { get; set; }
    }
}