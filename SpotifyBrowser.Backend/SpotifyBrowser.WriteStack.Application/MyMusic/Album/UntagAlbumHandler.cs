using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using SpotifyBrowser.Cqrs.Contracts.WriteStack;
using SpotifyBrowser.Cqrs.Implementation;
using SpotifyBrowser.Domain;
using SpotifyBrowser.WriteStack.Domain.MyAlbums;
using System.Threading;
using System.Threading.Tasks;
using SpotifyBrowser.WriteStack.Domain;

namespace SpotifyBrowser.WriteStack.Application.MyMusic.Album
{
    public class UntagAlbumHandler : CommandHandler<UntagAlbumCommand>
    {
        private readonly ISpotifyReadOnlyRepository<MyAlbum> _myAlbumReadOnlyRepository;
        private readonly IRepository<MyAlbum> _myAlbumRepository;

        public UntagAlbumHandler(
            ICommandDispatcher bus,
            ISpotifyReadOnlyRepository<MyAlbum> myAlbumReadOnlyRepository,
            IRepository<MyAlbum> myAlbumRepository,
            ILogger<UntagAlbumCommand> logger) : base(bus, logger)
        {
            _myAlbumReadOnlyRepository = myAlbumReadOnlyRepository;
            _myAlbumRepository = myAlbumRepository;
        }

        protected override Task<Result> _Handle(UntagAlbumCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            var album =_myAlbumReadOnlyRepository.GetByIdForUser(command.AlbumId, Bus.User.Id);
            album.Untag(command.Tag);
            _myAlbumRepository.Save(album);
            return Task.FromResult(Result.Ok());
        }
    }
}