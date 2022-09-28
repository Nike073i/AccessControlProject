using AccessControlProject.Dto;

namespace AccessControlProject.Interfaces.Services;

public interface IAdminService
{
    PersonDto? AddPerson(string login, string password = "");
    bool SetBlockPerson(string login, bool isBlocked);
    bool SetPasswordLimit(string login, bool isLimited);
}