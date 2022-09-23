using AccessControlProject.Domain.Dto;
using AccessControlProject.Interfaces;
using AccessControlProject.Interfaces.Services;
using Newtonsoft.Json;

namespace AccessControlProject.Domain.Services
{
    public class FileDataService : IDataService
    {
        private List<PersonDto> _persons = new();
        public IEnumerable<IPersonDto> Persons => _persons;

        public bool UpdatePerson(IPersonDto person)
        {
            var indexPerson = _persons.FindIndex(p => p.Login.Equals(person.Login));
            if (indexPerson == -1) return false;
            _persons[indexPerson].Password = person.Password;
            _persons[indexPerson].IsBlocked = person.IsBlocked;
            _persons[indexPerson].IsLimited = person.IsLimited;

            return true;
        }

        public IPersonDto? GetPersonByLogin(string login) => Persons.FirstOrDefault(p => p.Login.Equals(login));

        public async Task<bool> LoadPersonsAsync(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) return false;
            if (!File.Exists(filePath)) return false;
            try
            {
                var json = await File.ReadAllTextAsync(filePath).ConfigureAwait(false);
                var deserialize = JsonConvert.DeserializeObject<List<PersonDto>>(json);
                _persons = deserialize ?? new List<PersonDto>();
            }
            catch (IOException ex)
            {
                throw new Exception("Во время загрузки данных произошла ошибка.", ex.InnerException);
            }
            catch (JsonSerializationException ex)
            {
                throw new Exception("Ошибка сериализации данных", ex.InnerException);
            }

            return true;
        }

        public async Task<bool> SavePersonsAsync(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) return false;
            if (!Persons.Any()) return false;
            var json = JsonConvert.SerializeObject(Persons);
            await using var tw = new StreamWriter(filePath);
            await tw.WriteLineAsync(json);
            return true;
        }
    }
}