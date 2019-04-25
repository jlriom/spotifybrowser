using SpotifyBrowser.User.WriteStack.Domain.UserManagement;
using System;
using System.Threading.Tasks;

namespace SpotifyBrowser.User.WriteStack.Domain.Implementation
{
    public class UserService: IUserService
    {
        private readonly UserProfileRepository _userProfileRepository;
        private readonly IdentityUserManagerFacade _identityUserManagerFacade;

        public UserService(UserProfileRepository userProfileRepository, IdentityUserManagerFacade identityUserManagerFacade)
        {
            _userProfileRepository = userProfileRepository;
            _identityUserManagerFacade = identityUserManagerFacade;
        }
        public async Task ActivateUserAsync(string performedByUserId, string userId)
        {
            var user = new UserManagement.User(userId);

            if (user.IsOperationPeformedByHimself(performedByUserId))
                throw new ApplicationException(user.UserCantPerformOperationOverHimselfErrorMessage(UserManagement.User.NotPossibleToActivateUserErrorMessage));

            await _identityUserManagerFacade.ActivateUserAsync(user);
            await _userProfileRepository.ActivateUserAsync(user);
        }

        public async Task DeactivateUserAsync(string performedByUserId, string userId)
        {
            var user = new UserManagement.User(userId);

            if (user.IsOperationPeformedByHimself(performedByUserId))
                throw new ApplicationException(user.UserCantPerformOperationOverHimselfErrorMessage(UserManagement.User.NotPossibleToDeactivateUserErrorMessage));

            await _identityUserManagerFacade.DeactivateUserAsync(user);
            await _userProfileRepository.DeactivateUserAsync(user);
        }

        public async Task DeleteUserAsync(string performedByUserId, string userId)
        {
            var user = new UserManagement.User(userId);

            if (user.IsOperationPeformedByHimself(performedByUserId))
                throw new ApplicationException(user.UserCantPerformOperationOverHimselfErrorMessage(UserManagement.User.NotPossibleToDeleteErrorMessage));

            await _identityUserManagerFacade.DeleteUserAsync(user);
            await _userProfileRepository.DeleteUserAsync(user);
        }
    }
}
