using Microsoft.EntityFrameworkCore;
using SpotifyBrowser.User.WriteStack.Domain.Accounts;
using SpotifyBrowser.User.WriteStack.Domain.Implementation.Models;
using SpotifyBrowser.User.WriteStack.Domain.UserManagement;
using System;
using System.Threading.Tasks;

namespace SpotifyBrowser.User.WriteStack.Domain.Implementation
{
    public class UserProfileRepository
    {
        private readonly SpotifyBrowserAccountsDbContext _context;
        public UserProfileRepository(SpotifyBrowserAccountsDbContext context)
        {
            _context = context;
        }

        public async Task UnregisterAsync(Account account)
        {
            var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(u => u.Id == account.UserId) 
                              ?? throw new ApplicationException(account.UserNotFoundErrorMessage(Account.NotPossibleToUnRegisterUserErrorMessage));

            await UpdateProfileState(userProfile, UserState.Unregistered);
        }

        public async Task RegisterUserProfileAsync(Account account)
        {
            var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(u => u.Email  == account.Email);
            if (userProfile != null)
            {
                userProfile.Email = account.Email;
                userProfile.FirstName = account.FirstName;
                userProfile.LastName = account.LastName;
                await UpdateProfileState(userProfile, UserState.PendingToActivate);
            }
            else
            {
                userProfile = new UserProfile { Id = account.UserId, Email = account.Email, FirstName = account.FirstName, LastName = account.LastName, UserState = (int)UserState.PendingToActivate };
                _context.UserProfiles.Add(userProfile);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateUserAsync(Account account)
        {
            var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(u => u.Id == account.UserId)
                              ?? throw new ApplicationException(account.UserNotFoundErrorMessage(Account.NotPossibleToUpdateUserErrorMessage));

            userProfile.FirstName = account.FirstName;
            userProfile.LastName = account.LastName;
            _context.UserProfiles.Update(userProfile);
            await _context.SaveChangesAsync();
        }

        public async Task ActivateUserAsync(UserManagement.User user)
        {
            var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(u => u.Id == user.UserId)
                              ?? throw new ApplicationException(user.UserNotFoundErrorMessage(UserManagement.User.NotPossibleToActivateUserErrorMessage));

            await UpdateProfileState(userProfile, UserState.Active);
        }
 
        public async Task DeactivateUserAsync(UserManagement.User user)
        {
            var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(u => u.Id == user.UserId)
                              ?? throw new ApplicationException(user.UserNotFoundErrorMessage(UserManagement.User.NotPossibleToDeactivateUserErrorMessage));

            await UpdateProfileState(userProfile, UserState.Deactive);
        }

        public async Task DeleteUserAsync(UserManagement.User user)
        {
            var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(u => u.Id == user.UserId)
                              ?? throw new ApplicationException(user.UserNotFoundErrorMessage(UserManagement.User.NotPossibleToDeleteErrorMessage));

            _context.UserProfiles.Remove(userProfile);
            await _context.SaveChangesAsync();
        }

        private async Task UpdateProfileState(UserProfile userProfile, UserState userState)
        {
            userProfile.UserState = (int)userState;
            _context.UserProfiles.Update(userProfile);
            await _context.SaveChangesAsync();
        }
    }
}
