using AccessControlProject.Domain.Services.Base;
using AccessControlProject.Interfaces;
using AccessControlProject.Interfaces.Services;

namespace AccessControlProject.Domain.Services
{
    public class AdminService : PersonService, IAdminService
    {
        public IEnumerable<IPersonDto> GetUsers()
        {
            throw new NotImplementedException();
        }

        public bool AddUser(string login, string password = "")
        {
            throw new NotImplementedException();
        }

        public bool SetBlockUser(string login, bool isBlocked)
        {
            throw new NotImplementedException();
        }

        public bool SetPasswordLimit(string login, bool isLimited)
        {
            throw new NotImplementedException();
        }
    }
}
