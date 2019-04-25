using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using SpotifyBrowser.Cqrs.Implementation;
using SpotifyBrowser.ReadStack.Aplication.MyMusic.Services;

namespace SpotifyBrowser.ReadStack.Aplication.MyMusic.Album
{
    public class GetMyAlbumsHandler : QueryHandler<GetMyAlbumsQuery, IEnumerable<Models.Album>>
    {
        private readonly IMyAlbumsReadOnlyService _myAlbumsReadOnlyService;
        private readonly IMapper _mapper;

        public GetMyAlbumsHandler(IQueryDispatcher bus, IMyAlbumsReadOnlyService myAlbumsReadOnlyService, IMapper mapper, ILogger<GetMyAlbumsQuery> logger) : base(bus, logger)
        {
            _myAlbumsReadOnlyService = myAlbumsReadOnlyService;
            _mapper = mapper;
        }

        protected override async Task<IEnumerable<Models.Album>> _Handle(GetMyAlbumsQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            var albums = await _myAlbumsReadOnlyService.GetMyAlbums(Bus.User.Id);
            return _mapper.Map<IEnumerable<Models.Album>>(albums);
        }
    }
}