using SpotifyApi.Facade.Contracts;
using SpotifyApi.Facade.Contracts.Enums;
using SpotifyApi.Facade.Implementation.Auth;
using SpotifyApi.Facade.Implementation.Services;
using Xunit;

namespace SpotifyApi.Facade.Implementation.Tests
{
    public class SearchTests
    {
        readonly ISearchService _service  = new SearchService(new ClientCredentialsSettingsOptions().Value);

        [Theory]
        [InlineData("sting")]
        public void SearchArtists(string q)
        {
            Assert.True(_service.SearchItemsAsync(q, SearchType.Artist).Result.Artists.Total > 0);
        }

        [Theory]
        [InlineData("nothing")]
        public void SearchAlbums(string q)
        {
            Assert.True(_service.SearchItemsAsync(q, SearchType.Album).Result.Albums.Total > 0);
        }

        [Theory]
        [InlineData("black")]
        public void SearchTracks(string q)
        {
            Assert.True(_service.SearchItemsAsync(q, SearchType.Track).Result.Tracks.Total > 0);
        }

    }
}
