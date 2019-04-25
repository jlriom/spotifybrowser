using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpotifyApi.Facade.Contracts.Models
{
    public class SeveralAudioFeatures : BasicModel
    {
         [JsonProperty("audio_features")]
         public List<AudioFeatures> AudioFeatures { get; set; }
    }
}