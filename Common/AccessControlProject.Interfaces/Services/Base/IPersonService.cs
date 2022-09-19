namespace AccessControlProject.Interfaces.Services.Base
{
    public interface IPersonService
    {
        bool ChangePassword(string login, string currentPassword, string newPassword);
    }
}
