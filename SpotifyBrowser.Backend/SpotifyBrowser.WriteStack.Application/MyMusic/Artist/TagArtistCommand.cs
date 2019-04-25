using System;
using SpotifyBrowser.Cqrs.Contracts.WriteStack;

namespace SpotifyBrowser.WriteStack.Application.MyMusic.Artist
{
    public class TagArtistCommand : ICommand
    {
        public string ArtistId { get; }
        public string Tag { get; }

        public TagArtistCommand(string artistId, string tag)
        {
            ArtistId = artistId;
            Tag = tag;
        }
    }
}
