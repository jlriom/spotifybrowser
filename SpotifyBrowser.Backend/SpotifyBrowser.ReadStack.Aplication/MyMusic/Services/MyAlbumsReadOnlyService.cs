using AutoMapper;
using SpotifyApi.Facade.Contracts;
using SpotifyBrowser.ReadStack.DataAccess.Contracts.Album;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotifyBrowser.ReadStack.Aplication.MyMusic.Services
{
    public class MyAlbumsReadOnlyService: IMyAlbumsReadOnlyService
    {
        private readonly IAlbumService _albumService;
        private readonly IAlbumTagsReadOnlyRepository _albumTagsReadOnlyRepository;
        private readonly IMapper _mapper;

        public MyAlbumsReadOnlyService(IAlbumService albumService, IMapper mapper, IAlbumTagsReadOnlyRepository albumTagsReadOnlyRepository)
        {
            _albumTagsReadOnlyRepository = albumTagsReadOnlyRepository;
            _albumService = albumService;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Models.Album>> GetMyAlbums(string userId)
        {

            var taggedAlbums = _albumTagsReadOnlyRepository.GetTaggedAlbums(userId).ToArray();
            if (taggedAlbums.Length > 0)
            {
                var selectedServeralAlbums = await _albumService.GetSeveralAlbumsAsync(taggedAlbums.Select(s => s.AlbumId).Distinct());
                var selectedAlbums = _mapper.Map<List<Models.Album>>(selectedServeralAlbums.Albums);
                selectedAlbums.ForEach(album => album.Tags = taggedAlbums.Where(t => t.AlbumId == album.Id).Select(t => t.Tag).ToList());
                return selectedAlbums;
            }
            return new List<Models.Album>();
        }

        public IEnumerable<Models.Album> AddTagsForMyAlbumsInList(string userId, IEnumerable<Models.Album> albums)
        {
            var taggedAlbums = _albumTagsReadOnlyRepository.GetTaggedAlbums(userId).ToArray();
            var addTagsForMyAlbumsInList = albums as Models.Album[] ?? albums.ToArray();
            if (taggedAlbums.Length > 0)
            {
                foreach (var album in addTagsForMyAlbumsInList)
                {
                    album.Tags = taggedAlbums.Where(t => t.AlbumId == album.Id).Select(t => t.Tag).ToList();
                }
            }
            return addTagsForMyAlbumsInList;
        }

        public Models.Album AddTagsForMyAlbum(string userId, Models.Album album)
        {
            var albumTags = _albumTagsReadOnlyRepository.GetTaggedAlbums(userId).Where(taggedAlbum => taggedAlbum.AlbumId == album.Id);
            var enumerable = albumTags as AlbumTag[] ?? albumTags.ToArray();
            if (enumerable.Any())
            {
                album.Tags = enumerable.Select(albumTag => albumTag.Tag).ToList();
            }
            return album;
        }
    }
}
