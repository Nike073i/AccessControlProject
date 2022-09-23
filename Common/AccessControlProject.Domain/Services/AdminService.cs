using AccessControlProject.Domain.Services.Base;
using AccessControlProject.Interfaces.Services;

namespace AccessControlProject.Domain.Services
{
    public class AdminService : PersonService, IAdminService
    {
        public Task<bool> AddPersonAsync(string login, string password = "")
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetBlockPersonAsync(string login, bool isBlocked)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetPasswordLimitAsync(string login, bool isLimited)
        {
            throw new NotImplementedException();
        }
    }
}
