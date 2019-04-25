using SpotifyApi.Facade.Contracts;
using SpotifyApi.Facade.Implementation.Auth;
using SpotifyApi.Facade.Implementation.Services;
using Xunit;

namespace SpotifyApi.Facade.Implementation.Tests
{
    public class ArtistTests
    {
        readonly IArtistService _service  = new ArtistService(new ClientCredentialsSettingsOptions().Value);

        [Theory]
        [InlineData("0Ty63ceoRnnJKVEYP0VQpk")]
        public void GetArtist(string id)
        {
            Assert.Equal(id,_service.GetArtistAsync(id).Result.Id);
        }

        [Theory]
        [InlineData("0Ty63ceoRnnJKVEYP0VQpk")]
        public void GetRelatedArtists(string id)
        {
            Assert.True(_service.GetRelatedArtistsAsync(id).Result.Artists.Count > 0);
        }
    }
}
