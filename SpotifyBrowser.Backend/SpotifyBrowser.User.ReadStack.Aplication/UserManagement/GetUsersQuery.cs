using SpotifyBrowser.Cqrs.Implementation;

namespace SpotifyBrowser.User.ReadStack.Aplication.UserManagement
{
    public class GetUsersQuery: PagedQuery<User>
    {
        public int? UserState { get; }
        public string EmailSearchPattern { get; }

        public GetUsersQuery(int? userState, string emailSearchPattern, int limit, int offset) : base(limit, offset)
        {
            UserState = userState.HasValue && userState.Value == -1 ? null : userState;
            EmailSearchPattern = emailSearchPattern;
        }
    }
}
