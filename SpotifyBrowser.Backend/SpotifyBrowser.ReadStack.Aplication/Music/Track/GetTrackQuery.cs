using SpotifyBrowser.Cqrs.Contracts.ReadStack;

namespace SpotifyBrowser.ReadStack.Aplication.Music.Track
{
    public class GetTrackQuery : IQuery<Models.Track>
    {
        public string TrackId { get; }
        public GetTrackQuery(string trackId)
        {
            TrackId = trackId;
        }
    }
}
