using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using System.Collections.Generic;

namespace SpotifyBrowser.ReadStack.Aplication.Music.Artist
{

    public class GetRelatedArtistsQuery : IQuery<IEnumerable<Models.Artist>>
    {
        public string ArtistId { get; }
        public GetRelatedArtistsQuery(string artistId)
        {
            ArtistId = artistId;
        }
    }
}
