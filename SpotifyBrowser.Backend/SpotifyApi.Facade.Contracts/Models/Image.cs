﻿using Newtonsoft.Json;

namespace SpotifyApi.Facade.Contracts.Models
{
    public class Image
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public int? Width { get; set; }

        [JsonProperty("height")]
        public int? Height { get; set; }
    }
}