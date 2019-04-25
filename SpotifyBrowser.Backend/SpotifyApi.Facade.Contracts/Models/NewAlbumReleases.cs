using Newtonsoft.Json;

namespace SpotifyApi.Facade.Contracts.Models
{
    public class NewAlbumReleases : BasicModel
    {
        [JsonProperty("albums")]
        public Paging<SimpleAlbum> Albums { get; set; }
    }
}