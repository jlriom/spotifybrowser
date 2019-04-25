using System.Collections.Generic;

namespace SpotifyBrowser.User.WriteStack.Domain.Implementation.Models
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
