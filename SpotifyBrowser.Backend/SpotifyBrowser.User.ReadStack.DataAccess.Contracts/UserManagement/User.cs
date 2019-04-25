namespace SpotifyBrowser.User.ReadStack.DataAccess.Contracts.UserManagement
{
    public class User
    {
        public User(string id, string email, string firstName, string lastName, UserState userState)
        {
            Id = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            UserState = userState;
        }

        public string Id { get; }
        public string Email { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public UserState UserState { get; }
    }
}
