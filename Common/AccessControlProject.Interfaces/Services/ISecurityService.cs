using AccessControlProject.Dto;

namespace AccessControlProject.Interfaces.Services;

public interface ISecurityService
{
    PersonDto? Authentication(string login, string password);
    bool ChangePassword(string login, string currentPassword, string newPassword);
}