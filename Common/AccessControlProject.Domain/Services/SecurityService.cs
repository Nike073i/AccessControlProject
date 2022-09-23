using AccessControlProject.Domain.Dto;
using AccessControlProject.Interfaces;
using AccessControlProject.Interfaces.Services;
using System.Security.Cryptography;
using System.Text;

namespace AccessControlProject.Domain.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IDataService _dataService;

        public SecurityService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public bool ChangePassword(string login, string currentPassword, string newPassword)
        {
            var authPerson = Authentication(login, currentPassword);
            if (authPerson == null) return false;
            var dto = new PersonDto()
            {
                Login = authPerson.Login,
                Password = newPassword,
                IsLimited = authPerson.IsLimited,
                IsBlocked = authPerson.IsBlocked
            };
            _dataService.UpdatePerson(dto);
            return true;
        }

        public IPersonDto? Authentication(string login, string password)
        {
            if (string.IsNullOrEmpty(login) ||
                string.IsNullOrEmpty(password)) return null;

            var foundPerson = _dataService.GetPersonByLogin(login);
            var isCorrectData = foundPerson != null && foundPerson.Password.Equals(GetHashSha256(password));
            return isCorrectData ? foundPerson : null;

        }

        public static string GetHashSha256(string value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.ASCII.GetBytes(value));
            return Convert.ToBase64String(bytes);
        }
    }
}
