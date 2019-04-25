using System.Threading.Tasks;

namespace SpotifyBrowser.User.WriteStack.Domain.UserManagement
{
    public interface IUserService
    {
        Task ActivateUserAsync(string performedByUserId, string userId);
        Task DeactivateUserAsync(string performedByUserId, string userId);
        Task DeleteUserAsync(string performedByUserId, string userId);
    }
}
