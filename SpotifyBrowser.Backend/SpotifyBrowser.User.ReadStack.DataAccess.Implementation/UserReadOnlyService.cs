using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LinqKit;
using SpotifyBrowser.User.ReadStack.DataAccess.Contracts.Account.Models;
using SpotifyBrowser.User.ReadStack.DataAccess.Contracts.UserManagement;

namespace SpotifyBrowser.User.ReadStack.DataAccess.Implementation
{
    public class UserReadOnlyService: IUserReadOnlyService
    {
        private readonly SpotifyBrowserAccountsReadOnlyDbContext _context;

        public UserReadOnlyService(SpotifyBrowserAccountsReadOnlyDbContext spotifyBrowserAccountsDbContext)
        {
            _context = spotifyBrowserAccountsDbContext;
        }

        public Task<(IEnumerable<Contracts.UserManagement.User>, int)> GetUsersAsync(int? userState, string emailSearchPattern, int limit, int offset)
        {

            Expression<Func<UserProfile, bool>> userStateWhereClause = userProfile => userProfile.UserState == userState.Value;
            Expression<Func<UserProfile, bool>> emailSearchPatternWhereClause = userProfile => userProfile.Email.Contains(emailSearchPattern);

            var whereClause = PredicateBuilder.New<UserProfile>(true);

            if (userState.HasValue)
                whereClause = whereClause.And(userStateWhereClause);

            if (!string.IsNullOrEmpty(emailSearchPattern))
                whereClause = whereClause.And(emailSearchPatternWhereClause);

            var userCount = _context.UserProfiles.Count(whereClause);
            var users = _context.UserProfiles
                .Where(whereClause)
                .OrderBy(userProfile => userProfile.Email)
                .Skip(offset)
                .Take(limit)
                .Select(  profile => new Contracts.UserManagement.User( profile.Id, profile.Email, profile.FirstName, profile.LastName, (UserState) profile.UserState)).ToList();

            (IEnumerable<Contracts.UserManagement.User>, int) data = (users, userCount);
            return Task.FromResult(data);
        }

        public Task<IEnumerable<string>> GetUsersEmailBySearchPatternAsync(string emailSearchPattern)
        {
            IEnumerable<string> usersEmail = _context.UserProfiles
                .Where(userProfile => userProfile.Email.Contains(emailSearchPattern) )
                .OrderBy(userProfile => userProfile.Email)
                .Select(userProfile => userProfile.Email).ToList();

            return Task.FromResult(usersEmail);
        }
    }
}
