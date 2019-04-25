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
    public class TagAlbumHandler : CommandHandler<TagAlbumCommand>
    {
        private readonly ISpotifyReadOnlyRepository<MyAlbum> _myAlbumReadOnlyRepository;
        private readonly IRepository<MyAlbum> _myAlbumRepository;

        public TagAlbumHandler(
            ICommandDispatcher bus,
            ISpotifyReadOnlyRepository<MyAlbum> myAlbumReadOnlyRepository,
            IRepository<MyAlbum> myAlbumRepository,
            ILogger<TagAlbumCommand> logger) : base(bus, logger)
        {
            _myAlbumReadOnlyRepository = myAlbumReadOnlyRepository;
            _myAlbumRepository = myAlbumRepository;
        }

        protected override Task<Result> _Handle(TagAlbumCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            var album = _myAlbumReadOnlyRepository.GetByIdForUser(command.AlbumId, Bus.User.Id);
            album.AddTag(command.Tag);
            _myAlbumRepository.Save(album);
            return Task.FromResult(Result.Ok());
        }
    }
}