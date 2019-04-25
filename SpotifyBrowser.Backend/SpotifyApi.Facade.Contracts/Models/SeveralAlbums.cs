﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpotifyApi.Facade.Contracts.Models
{
    public class SeveralAlbums : BasicModel
    {
        [JsonProperty("albums")]
        public List<FullAlbum> Albums { get; set; }
    }
}