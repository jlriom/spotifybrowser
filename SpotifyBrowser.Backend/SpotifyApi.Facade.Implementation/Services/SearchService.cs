using SpotifyApi.Facade.Contracts;
using SpotifyApi.Facade.Contracts.Enums;
using SpotifyApi.Facade.Contracts.Models;
using SpotifyApi.Facade.Implementation.Auth;
using System.Threading.Tasks;

namespace SpotifyApi.Facade.Implementation.Services
{
    public class SearchService: SpotifyBaseService, ISearchService
    {
        public SearchService(ClientCredentialsSettings clientCredentialsSettings) : base(clientCredentialsSettings)
        {
        }

        public Task<SearchItem> SearchItemsAsync(string q, SearchType type, int limit = 20, int offset = 0, string market = "")
        {
            return SpotifyWebClient.Get<SearchItem>(new SpotifyWebBuilder().SearchItems(q, type, limit, offset, market));
        }
    }
}