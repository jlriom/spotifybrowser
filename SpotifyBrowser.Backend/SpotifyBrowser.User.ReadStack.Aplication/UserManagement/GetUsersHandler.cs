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
    public class GetUsersHandler : QueryHandler<GetUsersQuery, Paging<User>>
    {
        private readonly IUserReadOnlyService _userReadOnlyService;
        private readonly IMapper _mapper;

        public GetUsersHandler(IQueryDispatcher bus, IUserReadOnlyService userReadOnlyService, IMapper mapper, ILogger<GetUsersQuery> logger) : base(bus, logger)
        {
            _userReadOnlyService = userReadOnlyService;
            _mapper = mapper;
        }

        protected override async Task<Paging<User>> _Handle(GetUsersQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            var users = await _userReadOnlyService.GetUsersAsync(query.UserState, query.EmailSearchPattern, query.Limit, query.Offset);
            return new Paging<User>(_mapper.Map<IEnumerable<User>>(users.Item1), query.Limit, query.Offset, users.Item2);
       }
    }
}
