using System.Collections.Generic;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;

namespace SpotifyBrowser.ReadStack.Aplication.Music.Track
{
    public class GetArtistsTopTracksQuery : IQuery<IEnumerable<Models.Track>>
    {
        public string ArtistId { get; }
        public string Country { get; }

        public GetArtistsTopTracksQuery(string artistId, string country) 
        {
            ArtistId = artistId;
            Country = country;
        }
    }
}
