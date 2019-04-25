using AutoMapper;
using Microsoft.Extensions.Logging;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;
using SpotifyBrowser.Cqrs.Implementation;
using SpotifyBrowser.User.ReadStack.DataAccess.Contracts.Account;
using System.Threading;
using System.Threading.Tasks;

namespace SpotifyBrowser.User.ReadStack.Aplication.Account
{
    public class GetAuthContextHandler: QueryHandler<GetAuthContextQuery, Models.AuthContext>
    {
        private readonly IAccountReadOnlyService _accountService;
        private readonly IMapper _mapper;

        public GetAuthContextHandler(IQueryDispatcher bus, IAccountReadOnlyService accountService, IMapper mapper, ILogger<GetAuthContextQuery> logger) : base(bus, logger)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        protected override async Task<Models.AuthContext> _Handle(GetAuthContextQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            var authContext = await _accountService.GetAuthContextAsyc(query.User);

            if (authContext.HasValue)
                return _mapper.Map<Models.AuthContext>(authContext.Value);
            return null;
        }
    }
}
