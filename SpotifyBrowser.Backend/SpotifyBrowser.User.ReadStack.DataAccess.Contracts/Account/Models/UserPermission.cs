namespace SpotifyBrowser.User.ReadStack.DataAccess.Contracts.Account.Models
{
    public class UserPermission
    {
        public int Id { get; set; }
        public string UserProfileId { get; set; }
        public string Value { get; set; }
    }
}
