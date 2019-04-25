using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using SpotifyBrowser.Cqrs.Contracts.WriteStack;
using SpotifyBrowser.Cqrs.Implementation;
using SpotifyBrowser.Domain;
using SpotifyBrowser.WriteStack.Domain.MyArtists;
using System.Threading;
using System.Threading.Tasks;
using SpotifyBrowser.WriteStack.Domain;

namespace SpotifyBrowser.WriteStack.Application.MyMusic.Artist
{
    public class TagArtistHandler : CommandHandler<TagArtistCommand>
    {
        private readonly ISpotifyReadOnlyRepository<MyArtist> _myArtistReadOnlyRepository;
        private readonly IRepository<MyArtist> _myArtistRepository;

        public TagArtistHandler(
            ICommandDispatcher bus,
            ISpotifyReadOnlyRepository<MyArtist> myArtistReadOnlyRepository,
            IRepository<MyArtist> myArtistRepository,
            ILogger<TagArtistCommand> logger) : base(bus, logger)
        {
            _myArtistReadOnlyRepository = myArtistReadOnlyRepository;
            _myArtistRepository = myArtistRepository;
        }

        protected override Task<Result> _Handle(TagArtistCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            var artist = _myArtistReadOnlyRepository.GetByIdForUser(command.ArtistId, Bus.User.Id);
            artist.AddTag(command.Tag);
            _myArtistRepository.Save(artist);
            return Task.FromResult(Result.Ok());
        }
    }
}