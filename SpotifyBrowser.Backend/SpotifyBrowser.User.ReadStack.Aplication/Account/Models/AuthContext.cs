using System.Collections.Generic;

namespace SpotifyBrowser.User.ReadStack.Aplication.Account.Models
{
    public class AuthContext
    {
        public List<SimpleClaim> Claims { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
