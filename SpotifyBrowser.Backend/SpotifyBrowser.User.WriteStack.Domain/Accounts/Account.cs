namespace SpotifyBrowser.User.WriteStack.Domain.Accounts
{
    public class Account: UserBase
    {
        public string Password { get; set; }

        public Account(string userId)
        {
            UserId = userId;
        }

        public Account(string userId, string password)
        {
            UserId = userId;
            Password = password;
        }

        public Account(string userId, string firstName, string lastName)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
        }


        public Account(string email, string firstName, string lastName, string password)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }


        public bool ConfirmPassword(string confirmPassword)
        {
            return Password == confirmPassword;
        }

        public bool ConfirmNewPassword(string newPassword, string confirmPassword)
        {
            return newPassword == confirmPassword;
        }

        public string UserNotFoundErrorMessage(string operationErrorMessage) => $"{operationErrorMessage}: '{UserId}' not found";
        public string UserThatPerformsOperationIsNotUserInSessionErrorMessage(string operationErrorMessage) => $"{operationErrorMessage}: '{UserId}' is not User's id of the user in session";
        public string ConfirmedPasswordDoesNotMatchWithPasswordErrorMessage(string operationErrorMessage) => $"{operationErrorMessage}: Confirmed password does not match with password";
        public string UserExistsJetAsAdminUser(string operationErrorMessage) => $"{operationErrorMessage}: 'User exist as admin user";

        public const string NotPossibleToRegisterUserErrorMessage = "It is not possible to register user";
        public const string NotPossibleToUnRegisterUserErrorMessage = "It is not possible to unregister user";
        public const string NotPossibleToUpdateUserErrorMessage = "It is not possible to update user";
        public const string NotPossibleToChangePasswordErrorMessage = "It is not possible to change user Password";

    }
}
