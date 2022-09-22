using AccessControlProject.Interfaces;
using Newtonsoft.Json;

namespace AccessControlProject.Domain.Dto
{
    public class PersonDto : IPersonDto
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
    }
}
