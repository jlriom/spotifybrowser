namespace SpotifyBrowser.User.WriteStack.Domain
{
    public abstract class UserBase
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserState { get; set; }

        public bool IsOperationPeformedByHimself(string performedByUserId)
        {
            return UserId == performedByUserId;
        }
    }
}
