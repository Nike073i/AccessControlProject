using AccessControlProject.Interfaces.Services.Base;

namespace AccessControlProject.Interfaces.Services
{
    public interface IAdminService : IPersonService
    {
        IEnumerable<IPersonDto> GetUsers();
        bool AddUser(string login, string password = "");
        bool SetBlockUser(string login, bool isBlocked);
        bool SetPasswordLimit(string login, bool isLimited);
    }
}
