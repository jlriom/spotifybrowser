using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SpotifyBrowser.User.Shared.Identity.Storage;
using SpotifyBrowser.User.WriteStack.Domain.Accounts;

namespace SpotifyBrowser.User.WriteStack.Domain.Implementation
{
    public class IdentityUserManagerFacade
    {
        private const string AdminRoleName = "Admin";
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityUserManagerFacade(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task RegisterApplicationUserAsync(Account account)
        {
            var applicationUser = await _userManager.FindByEmailAsync(account.Email);
            if (applicationUser == null)
            {
                applicationUser = new ApplicationUser
                {
                    UserName = account.Email,
                    Email = account.Email,
                    EmailConfirmed = false
                };

                var createResult = await _userManager.CreateAsync(applicationUser, account.Password);
                account.UserId = applicationUser.Id;

                ThrowExceptionIfIdentifyError(createResult, Account.NotPossibleToRegisterUserErrorMessage);
            }
            else
            {
                var userRoles = await _userManager.GetRolesAsync(applicationUser);
                if (userRoles.Contains(AdminRoleName))
                    throw new ApplicationException(account.UserExistsJetAsAdminUser(Account.NotPossibleToRegisterUserErrorMessage));

                await _userManager.RemovePasswordAsync(applicationUser);
                var passwordResult = await _userManager.AddPasswordAsync(applicationUser, account.Password);

                ThrowExceptionIfIdentifyError(passwordResult, Account.NotPossibleToRegisterUserErrorMessage);

                applicationUser.EmailConfirmed = false;

                var updateResult = await _userManager.UpdateAsync(applicationUser);

                ThrowExceptionIfIdentifyError(updateResult, Account.NotPossibleToRegisterUserErrorMessage);
            }
        }

        public async Task ChangePasswordAsync(Account account, string newPassword)
        {
            var applicationUser = await _userManager.FindByIdAsync(account.UserId) 
                                  ?? throw new ApplicationException(account.UserNotFoundErrorMessage(Account.NotPossibleToChangePasswordErrorMessage));

            var passwordResult = await _userManager.ChangePasswordAsync(applicationUser, account.Password, newPassword);

            ThrowExceptionIfIdentifyError(passwordResult, Account.NotPossibleToChangePasswordErrorMessage);
        }

        public async Task UnregisterAsync(Account account)
        {
            var userRoles = await _userManager.GetRolesAsync(new ApplicationUser { Id = account.UserId});
            if (userRoles.Contains(AdminRoleName))
                throw new ApplicationException(account.UserExistsJetAsAdminUser(Account.NotPossibleToUnRegisterUserErrorMessage));

            var updateResult = await SetEmailConfirmationAsync(account.UserId, false, account.UserNotFoundErrorMessage(Account.NotPossibleToUnRegisterUserErrorMessage));

            ThrowExceptionIfIdentifyError(updateResult, Account.NotPossibleToUnRegisterUserErrorMessage);
        }

        public async Task ActivateUserAsync(UserManagement.User user)
        {
            var userRoles = await _userManager.GetRolesAsync(new ApplicationUser { Id = user.UserId });
            if (userRoles.Contains(AdminRoleName))
                throw new ApplicationException(user.UserExistsJetAsAdminUser(UserManagement.User.NotPossibleToActivateUserErrorMessage));

            var updateResult = await SetEmailConfirmationAsync(user.UserId, true, user.UserNotFoundErrorMessage(UserManagement.User.NotPossibleToActivateUserErrorMessage));

            ThrowExceptionIfIdentifyError(updateResult, UserManagement.User.NotPossibleToActivateUserErrorMessage);
        }

        public async Task DeactivateUserAsync(UserManagement.User user)
        {
            var userRoles = await _userManager.GetRolesAsync(new ApplicationUser { Id = user.UserId });
            if (userRoles.Contains(AdminRoleName))
                throw new ApplicationException(user.UserExistsJetAsAdminUser(UserManagement.User.NotPossibleToDeactivateUserErrorMessage));

            var updateResult = await SetEmailConfirmationAsync(user.UserId, false, user.UserNotFoundErrorMessage(UserManagement.User.NotPossibleToDeactivateUserErrorMessage));

            ThrowExceptionIfIdentifyError(updateResult, UserManagement.User.NotPossibleToDeactivateUserErrorMessage);
        }

        public async Task DeleteUserAsync(UserManagement.User user)
        {
            var applicationUser = await _userManager.FindByIdAsync(user.UserId) 
                                  ?? throw new ApplicationException(user.UserNotFoundErrorMessage(UserManagement.User.NotPossibleToDeleteErrorMessage));

            var userRoles = await _userManager.GetRolesAsync(applicationUser);
            if (userRoles.Contains(AdminRoleName))
                throw new ApplicationException(user.UserExistsJetAsAdminUser(UserManagement.User.NotPossibleToDeleteErrorMessage));

            await _userManager.DeleteAsync(applicationUser);
        }


        private async Task<IdentityResult> SetEmailConfirmationAsync(string userId, bool emailConfirmed, string errorMessage)
        {
            var applicationUser = await _userManager.FindByIdAsync(userId) ?? throw new ApplicationException(errorMessage);

            applicationUser.EmailConfirmed = emailConfirmed;

            return await _userManager.UpdateAsync(applicationUser);
        }

        private void ThrowExceptionIfIdentifyError(IdentityResult identityResult, string errorMessage)
        {
            if (identityResult.Succeeded) return;

            var errors = identityResult.Errors.Select(error => new ApplicationException(error.Description));

            throw new ApplicationException($"{errorMessage}", new AggregateException(errors));
        }
    }
}
