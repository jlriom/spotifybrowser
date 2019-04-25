using AutoMapper;
using Microsoft.Extensions.Logging;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using SpotifyBrowser.Cqrs.Implementation;
using SpotifyBrowser.User.ReadStack.DataAccess.Contracts.UserManagement;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyBrowser.User.ReadStack.Aplication.UserManagement
{
    public class GetUsersEmailBySearchPatternHandler : QueryHandler<GetUsersEmailBySearchPatternQuery, IEnumerable<string>>
    {
        private readonly IUserReadOnlyService _userReadOnlyService;
        private readonly IMapper _mapper;

        public GetUsersEmailBySearchPatternHandler(IQueryDispatcher bus, IUserReadOnlyService userReadOnlyService, IMapper mapper, ILogger<GetUsersEmailBySearchPatternQuery> logger) : base(bus, logger)
        {
            _userReadOnlyService = userReadOnlyService;
            _mapper = mapper;
        }

        protected override async Task<IEnumerable<string>> _Handle(GetUsersEmailBySearchPatternQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            var usersEmail = await _userReadOnlyService.GetUsersEmailBySearchPatternAsync(query.EmailSearchPattern);
            return usersEmail;
       }
    }
}
