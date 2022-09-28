using Newtonsoft.Json;

namespace AccessControlProject.Dto;

public class PersonDto
{
    public PersonDto()
    {
    }

    public PersonDto(string login, string password)
    {
        Login = login;
        Password = password;
    }

    public PersonDto(ref PersonDto other)
    {
        Login = other.Login;
        Password = other.Password;
        IsBlocked = other.IsBlocked;
        IsLimited = other.IsLimited;
    }

    [JsonProperty(Required = Required.Always)]
    public string Login { get; set; }

    [JsonProperty(Required = Required.Always)]
    public string Password { get; set; }

    [JsonProperty(Required = Required.Always)]
    public bool IsBlocked { get; set; }

    [JsonProperty(Required = Required.Always)]
    public bool IsLimited { get; set; }

    public bool IsAdmin()
    {
        return Login.Equals("ADMIN");
    }
}