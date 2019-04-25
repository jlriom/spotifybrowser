using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using System.Collections.Generic;

namespace SpotifyBrowser.ReadStack.Aplication.MyMusic.Artist
{
    public class GetMyArtistsQuery : IQuery<IEnumerable<Models.Artist>>
    {
    }
}
