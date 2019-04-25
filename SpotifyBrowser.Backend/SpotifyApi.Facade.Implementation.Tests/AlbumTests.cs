using SpotifyApi.Facade.Contracts;
using SpotifyApi.Facade.Implementation.Services;
using Xunit;

namespace SpotifyApi.Facade.Implementation.Tests
{
    public class AlbumTests
    {
        readonly IAlbumService _service  = new AlbumService(new ClientCredentialsSettingsOptions().Value);

        [Theory]
        [InlineData("0PwbPMpNoZXsCMFXrOZUvW")]
        public void GetAlbum(string id)
        {
            Assert.Equal(id, _service.GetAlbumAsync(id).Result.Id);
        }

        [Theory]
        [InlineData("0Ty63ceoRnnJKVEYP0VQpk")]
        public void GetArtistsAlbums(string id)
        {
            Assert.True(_service.GetArtistsAlbumsAsync(id).Result.Total > 0);
        }
    }
}
