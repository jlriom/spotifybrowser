using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpotifyBrowser.User.ReadStack.DataAccess.Contracts.UserManagement
{
    public interface IUserReadOnlyService
    {
        Task<(IEnumerable<User>, int)> GetUsersAsync(int? userState, string emailSearchPattern, int limit, int offset);
        Task<IEnumerable<string>> GetUsersEmailBySearchPatternAsync(string emailSearchPattern);
    }
}
