namespace SpotifyBrowser.User.WriteStack.Domain.UserManagement
{
    public class User: UserBase
    {
        public User(string userId)
        {
            UserId = userId;
        }



        public string UserNotFoundErrorMessage(string operationErrorMessage) => $"{operationErrorMessage}: '{UserId}' not found";
        public string UserCantPerformOperationOverHimselfErrorMessage(string operationErrorMessage) => $"{operationErrorMessage}: Operation can not be performed over himself";
        public string UserExistsJetAsAdminUser(string operationErrorMessage) => $"{operationErrorMessage}: 'User exist as admin user";


        public const string NotPossibleToActivateUserErrorMessage = "It is not possible to activate selected user";
        public const string NotPossibleToDeactivateUserErrorMessage = "It is not possible to deactivate selected user";
        public const string NotPossibleToDeleteErrorMessage = "It is not possible to delete selected user";

    }
}
