using Newtonsoft.Json;

namespace AccessControlProject.Dto
{
    public class PersonDto
    {
        [JsonProperty(Required = Required.Always)]
        public string Login { get; set; } = string.Empty;
        [JsonProperty(Required = Required.Always)]
        public string Password { get; set; } = string.Empty;
        [JsonProperty(Required = Required.Always)]
        public bool IsBlocked { get; set; }
        [JsonProperty(Required = Required.Always)]
        public bool IsLimited { get; set; }

        public bool IsAdmin() => Login.Equals("ADMIN");

        public PersonDto(ref PersonDto other)
        {
            Login = other.Login;
            Password = other.Password;
            IsBlocked = other.IsBlocked;
            IsLimited = other.IsLimited;
        }
    }
}
