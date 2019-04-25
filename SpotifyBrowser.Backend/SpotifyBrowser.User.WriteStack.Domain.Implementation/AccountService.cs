using SpotifyBrowser.User.WriteStack.Domain.Accounts;
using System;
using System.Threading.Tasks;

namespace SpotifyBrowser.User.WriteStack.Domain.Implementation
{
    public class AccountService: IAccountService
    {
        private readonly UserProfileRepository _userProfileRepository;
        private readonly IdentityUserManagerFacade _identityUserManagerFacade;

        public AccountService(UserProfileRepository userProfileRepository, IdentityUserManagerFacade identityUserManagerFacade)
        {
            _userProfileRepository = userProfileRepository;
            _identityUserManagerFacade = identityUserManagerFacade;
        }

        public async Task RegisterUserAsync(string email, string firstName, string lastName, string password, string confirmPassword)
        {
            var account = new Account(email, firstName, lastName, password);

            if (!account.ConfirmPassword(confirmPassword))
                throw new ApplicationException(account.ConfirmedPasswordDoesNotMatchWithPasswordErrorMessage(Account.NotPossibleToRegisterUserErrorMessage));

            await _identityUserManagerFacade.RegisterApplicationUserAsync(account);

            await _userProfileRepository.RegisterUserProfileAsync(account);
        }

        public async Task UnregisterAsync(string performedByUserId, string userId)
        {

            var account = new Account(userId);

            if (!account.IsOperationPeformedByHimself(performedByUserId))
                throw new ApplicationException(account.UserThatPerformsOperationIsNotUserInSessionErrorMessage(Account.NotPossibleToUnRegisterUserErrorMessage));

            await _identityUserManagerFacade.UnregisterAsync(account);

            await _userProfileRepository.UnregisterAsync(account);
        }


        public async Task UpdateAsync(string performedByUserId, string userId, string firstName, string lastName)
        {
            var account = new Account(userId, firstName, lastName);

            if (!account.IsOperationPeformedByHimself(performedByUserId))
                throw new ApplicationException(account.UserThatPerformsOperationIsNotUserInSessionErrorMessage(Account.NotPossibleToUpdateUserErrorMessage));

            await _userProfileRepository.UpdateUserAsync(account);
        }

        public async Task ChangePasswordAsync(string performedByUserId, string userId, string oldPassword, string newPassword, string confirmNewPassword)
        {

            var account = new Account(userId, oldPassword);

            if (!account.IsOperationPeformedByHimself(performedByUserId))
                throw new ApplicationException(account.UserThatPerformsOperationIsNotUserInSessionErrorMessage(Account.NotPossibleToChangePasswordErrorMessage));

            if (!account.ConfirmNewPassword(newPassword, confirmNewPassword))
                throw new ApplicationException(account.ConfirmedPasswordDoesNotMatchWithPasswordErrorMessage(Account.NotPossibleToChangePasswordErrorMessage));

            await _identityUserManagerFacade.ChangePasswordAsync(account, newPassword);
        }
    }
}
