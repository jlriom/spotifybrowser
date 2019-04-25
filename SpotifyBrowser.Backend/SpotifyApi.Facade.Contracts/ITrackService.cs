using System.Threading.Tasks;
using SpotifyApi.Facade.Contracts.Models;

namespace SpotifyApi.Facade.Contracts
{
    public interface ITrackService
    {
        Task<Paging<SimpleTrack>> GetAlbumTracksAsync(string id, int limit = 20, int offset = 0, string market = "");
        Task<FullTrack> GetTrackAsync(string id, string market = "");
        Task<SeveralTracks> GetArtistsTopTracksAsync(string id, string country);
    }
}