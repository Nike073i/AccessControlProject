using AccessControlProject.Interfaces.Services.Base;

namespace AccessControlProject.Domain.Services.Base
{
    public class PersonService : IPersonService
    {
        public bool ChangePassword(string login, string currentPassword, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
