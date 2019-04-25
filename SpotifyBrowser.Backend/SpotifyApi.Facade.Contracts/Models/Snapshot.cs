using Newtonsoft.Json;

namespace SpotifyApi.Facade.Contracts.Models
{
    public class Snapshot : BasicModel
    {
        [JsonProperty("snapshot_id")]
        public string SnapshotId { get; set; }
    }
}