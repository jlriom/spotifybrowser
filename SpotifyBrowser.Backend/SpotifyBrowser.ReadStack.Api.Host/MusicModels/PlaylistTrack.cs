using System;

namespace SpotifyBrowser.ReadStack.Api.Host.MusicModels
{
    public class PlaylistTrack
    {
        public DateTime AddedAt { get; set; }

        public PublicProfile AddedBy { get; set; }

        public Track Track { get; set; }

        public bool IsLocal { get; set; }
    }
}
