namespace SpotifyBrowser.User.WriteStack.Api.Host.Account.Model
{
    public class ChangePasswordInfo
    {
        public string UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
