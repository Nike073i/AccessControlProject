using AccessControlProject.Interfaces;

namespace AccessControlProject.Domain.Dto
{
    public class PersonDto : IPersonDto
    {
        public bool IsAdmin { get; }
        public string Login { get; }
        public string Password { get; }
        public bool IsBlocked { get; }

        public PersonDto(string login, string password, bool isBlocked)
        {
            Login = login;
            IsAdmin = login.Equals("ADMIN");
            Password = password;
            IsBlocked = isBlocked;
        }
    }
}
