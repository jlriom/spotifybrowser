using System.Threading.Tasks;

namespace SpotifyBrowser.User.WriteStack.Domain.Accounts
{
    public interface IAccountService
    {
        Task RegisterUserAsync(string email, string firstName, string lastName, string password, string confirmPassword);
        Task UnregisterAsync(string performedByUserId, string userId);
        Task UpdateAsync(string performedByUserId, string userId, string firstName, string lastName);
        Task ChangePasswordAsync(string performedByUserId, string userId, string oldPassword, string newPassword, string confirmNewPassword);
    }
}
