using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpotifyApi.Facade.Contracts.Models
{
    public class SeveralArtists : BasicModel
    {
        [JsonProperty("artists")]
        public List<FullArtist> Artists { get; set; }
    }
}