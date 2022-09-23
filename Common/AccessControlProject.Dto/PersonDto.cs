using Newtonsoft.Json;

namespace AccessControlProject.Dto
{
    public class PersonDto
    {
        [JsonProperty(Required = Required.Always)]
        public string Login { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string Password { get; set; }
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

        public override bool Equals(object? obj) => Equals(obj as PersonDto);

        public override int GetHashCode() => Login.GetHashCode();

        public bool Equals(PersonDto? other) => other != null && Login == other.Login;
    }
}
