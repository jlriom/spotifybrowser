using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using System.Collections.Generic;

namespace SpotifyBrowser.ReadStack.Aplication.MyMusic.Album
{
    public class GetMyAlbumsQuery : IQuery<IEnumerable<Models.Album>>
    {
    }
}
