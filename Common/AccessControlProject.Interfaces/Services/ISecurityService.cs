namespace AccessControlProject.Interfaces.Services
{
    public interface ISecurityService
    {
        IPersonDto? Authentication(string login, string password);
    }
}
