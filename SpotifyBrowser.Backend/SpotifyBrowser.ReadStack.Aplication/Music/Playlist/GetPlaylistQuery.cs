using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using SpotifyBrowser.ReadStack.Aplication.Models;

namespace SpotifyBrowser.ReadStack.Aplication.Music.Playlist
{
    public class GetPlaylistQuery : IQuery<FullPlaylist>
    {
        public string PlaylistId { get; }

        public GetPlaylistQuery(string playlistId) 
        {
            PlaylistId = playlistId;
        }
    }
}
