using System.Collections.Generic;

namespace SpotifyBrowser.User.ReadStack.Api.Host.Account.Model
{
    public class AuthContext
    {
        public List<SimpleClaim> Claims { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
