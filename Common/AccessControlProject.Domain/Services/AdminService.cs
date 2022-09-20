using AccessControlProject.Domain.Services.Base;
using AccessControlProject.Interfaces;
using AccessControlProject.Interfaces.Services;

namespace AccessControlProject.Domain.Services
{
    public class AdminService : PersonService, IAdminService
    {
        public Task<IEnumerable<IPersonDto>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddUserAsync(string login, string password = "")
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetBlockUserAsync(string login, bool isBlocked)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetPasswordLimitAsync(string login, bool isLimited)
        {
            throw new NotImplementedException();
        }
    }
}
