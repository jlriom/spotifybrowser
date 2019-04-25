using SpotifyApi.Facade.Contracts;
using SpotifyApi.Facade.Implementation.Services;
using Xunit;

namespace SpotifyApi.Facade.Implementation.Tests
{
    public class PlaylistTests
    {
        readonly IPlaylistService _service  = new PlaylistService(new ClientCredentialsSettingsOptions().Value);

        [Theory]
        [InlineData("classical")]
        public void GetCategoryPlaylistsAsync(string categoryId)
        {
            Assert.True(_service.GetCategoryPlaylistsAsync(categoryId).Result.Playlists.Total  > 0);
        }

        [Theory]
        [InlineData("37i9dQZF1DX2RxBh64BHjQ")]
        public void GetPlaylistAsync(string playlistId)
        {
            Assert.Equal(playlistId, _service.GetPlaylistAsync(string.Empty, playlistId).Result.Id);
        }
    }
}
