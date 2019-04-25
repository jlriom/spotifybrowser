using System.Threading.Tasks;
using SpotifyApi.Facade.Contracts.Enums;
using SpotifyApi.Facade.Contracts.Models;

namespace SpotifyApi.Facade.Contracts
{
    public interface ISearchService
    {
        Task<SearchItem> SearchItemsAsync(string q, SearchType type, int limit = 20, int offset = 0, string market = "");
    }
}