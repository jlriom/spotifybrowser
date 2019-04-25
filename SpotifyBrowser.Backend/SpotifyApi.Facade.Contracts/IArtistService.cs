using System.Collections.Generic;
using System.Threading.Tasks;
using SpotifyApi.Facade.Contracts.Models;

namespace SpotifyApi.Facade.Contracts
{
    public interface IArtistService
    {
        Task<FullArtist> GetArtistAsync(string id);
        Task<SeveralArtists> GetRelatedArtistsAsync(string id);
        Task<SeveralArtists> GetSeveralArtistsAsync(IEnumerable<string> ids);
    }
}