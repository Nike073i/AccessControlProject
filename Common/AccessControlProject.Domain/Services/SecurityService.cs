using System.Security;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using AccessControlProject.Dto;
using AccessControlProject.Interfaces.Services;

namespace AccessControlProject.Domain.Services;

public class SecurityService : ISecurityService
{
    private const string SecurityRegex = @"(?=.*\d)(?=.*([a-z]|[а-я]))(?=.*([A-Z]|[А-Я]))";
    private readonly IDataService _dataService;

    public SecurityService(IDataService dataService)
    {
        _dataService = dataService;
    }

    public bool ChangePassword(string login, string currentPassword, string newPassword)
    {
        var authPerson = Authentication(login, currentPassword);
        if (authPerson == null) throw new AuthenticationException("Аутентификация не пройдена");
        if (authPerson.IsLimited && !Regex.IsMatch(newPassword, SecurityRegex))
            throw new SecurityException("Пароль не соответствует ограничениям");
        var dto = new PersonDto(ref authPerson)
        {
            Password = GetHashSha256(newPassword)
        };
        _dataService.UpdatePerson(dto);
        return true;
    }

    public PersonDto? Authentication(string login, string password)
    {
        if (string.IsNullOrEmpty(login)) throw new ArgumentNullException(nameof(login));

        var foundPerson = _dataService.GetPersonByLogin(login);
        if (foundPerson == null) throw new Exception("Пользователь с указанным логином не обнаружен");
        if (foundPerson.IsBlocked) throw new Exception("Указанный пользователь заблокирован в системе");
        var isCorrectData = foundPerson.Password.Equals(GetHashSha256(password));
        
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