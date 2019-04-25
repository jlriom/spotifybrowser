using System.Collections.Generic;

namespace SpotifyBrowser.User.ReadStack.DataAccess.Contracts.Account.Models
{
    public class UserProfile
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserState { get; set; }
        public List<UserPermission> UserPermissions { get; set; }
    }
}
