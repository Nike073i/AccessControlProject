using AccessControlProject.Interfaces.Services.Base;

namespace AccessControlProject.Interfaces.Services
{
    public interface IAdminService : IPersonService
    {
        Task<IEnumerable<IPersonDto>> GetUsersAsync();
        Task<bool> AddUserAsync(string login, string password = "");
        Task<bool> SetBlockUserAsync(string login, bool isBlocked);
        Task<bool> SetPasswordLimitAsync(string login, bool isLimited);
    }
}
