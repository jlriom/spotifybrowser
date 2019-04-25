using SpotifyApi.Facade.Contracts;
using SpotifyBrowser.ReadStack.DataAccess.Contracts.Artist;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace SpotifyBrowser.ReadStack.Aplication.MyMusic.Services
{
    public class MyArtistsReadOnlyService: IMyArtistsReadOnlyService
    {

        private readonly IArtistService _artistService;
        private readonly IArtistTagsReadOnlyRepository _artistTagsReadOnlyRepository;
        private readonly IMapper _mapper;

        public MyArtistsReadOnlyService(IArtistService artistService, IMapper mapper, IArtistTagsReadOnlyRepository artistTagsReadOnlyRepository)
        {
            _artistTagsReadOnlyRepository = artistTagsReadOnlyRepository;
            _artistService = artistService;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Models.Artist>> GetMyArtists(string userId)
        {
            var taggedArtists = _artistTagsReadOnlyRepository.GetTaggedArtists(userId).ToArray();
            if (taggedArtists.Length > 0)
            {
                var selectedServeralArtists = await _artistService.GetSeveralArtistsAsync(taggedArtists.Select(s => s.ArtistId).Distinct());
                var selectedArtists = _mapper.Map <List<Models.Artist>>(selectedServeralArtists.Artists);
                selectedArtists.ForEach( artist => artist.Tags = taggedArtists.Where(t => t.ArtistId == artist.Id).Select(t => t.Tag).ToList());
                return selectedArtists;
            }
            return new List<Models.Artist>();
        }

        public Models.Artist AddTagsForMyArtist(string userId, Models.Artist artist)
        {
            var artistTags = _artistTagsReadOnlyRepository.GetTaggedArtists(userId).Where(taggedArtists => taggedArtists.ArtistId == artist.Id);
            var enumerable = artistTags as ArtistTag[] ?? artistTags.ToArray();
            if (enumerable.Any())
            {
                artist.Tags = enumerable.Select(artistTag => artistTag.Tag).ToList();
            }
            return artist;
        }

        public IEnumerable<Models.Artist> AddTagsForMyArtistsInList(string userId, IEnumerable<Models.Artist> artists)
        {
            var taggedArtists = _artistTagsReadOnlyRepository.GetTaggedArtists(userId).ToArray();
            var addTagsForMyArtistsInList = artists as Models.Artist[] ?? artists.ToArray();
            if (taggedArtists.Length > 0)
            {
                foreach (var artist in addTagsForMyArtistsInList)
                {
                    artist.Tags = taggedArtists.Where(t => t.ArtistId == artist.Id).Select(t => t.Tag).ToList();
                }
            }
            return addTagsForMyArtistsInList;
        }
    }
}
