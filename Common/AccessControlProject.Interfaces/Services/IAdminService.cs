using AccessControlProject.Interfaces.Services.Base;

namespace AccessControlProject.Interfaces.Services
{
    public interface IAdminService : IPersonService
    {
        Task<bool> AddPersonAsync(string login, string password = "");
        Task<bool> SetBlockPersonAsync(string login, bool isBlocked);
        Task<bool> SetPasswordLimitAsync(string login, bool isLimited);
    }
}
