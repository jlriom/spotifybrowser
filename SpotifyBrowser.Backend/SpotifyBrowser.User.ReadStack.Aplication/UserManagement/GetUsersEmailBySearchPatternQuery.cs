using System.Collections.Generic;
using SpotifyBrowser.Cqrs.Contracts.ReadStack;

namespace SpotifyBrowser.User.ReadStack.Aplication.UserManagement
{
    public class GetUsersEmailBySearchPatternQuery: IQuery<IEnumerable<string>>
    {
        public string EmailSearchPattern { get; }

        public GetUsersEmailBySearchPatternQuery(string emailSearchPattern) 
        {
            EmailSearchPattern = emailSearchPattern;
        }
    }
}
