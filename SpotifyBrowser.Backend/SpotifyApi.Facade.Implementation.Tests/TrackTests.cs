using SpotifyApi.Facade.Contracts;
using SpotifyApi.Facade.Implementation.Services;
using Xunit;

namespace SpotifyApi.Facade.Implementation.Tests
{
    public class TrackTests
    {
        readonly ITrackService _service  = new TrackService(new ClientCredentialsSettingsOptions().Value);

        [Theory]
        [InlineData("0PwbPMpNoZXsCMFXrOZUvW")]
        public void GetAlbumTracks(string id)
        {
            Assert.True(_service.GetAlbumTracksAsync(id).Result.Total > 0);
        }

        [Theory]
        [InlineData("0Ty63ceoRnnJKVEYP0VQpk", "es")]
        public void GetArtistsTopTracks(string id, string country)
        {
            Assert.True(_service.GetArtistsTopTracksAsync(id, country).Result.Tracks.Count > 0);
        }

        [Theory]
        [InlineData("56sSWpx1jiKiTqJpiPpkHa")]
        public void GetTrack(string id)
        {
            Assert.Equal(id, _service.GetTrackAsync(id).Result.Id);
        }
    }
}
