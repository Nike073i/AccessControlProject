using AccessControlProject.Domain.Dto;
using AccessControlProject.Interfaces;
using AccessControlProject.Interfaces.Services;
using Newtonsoft.Json;

namespace AccessControlProject.Domain.Services
{
    public class FileDataService : IDataService
    {
        public IEnumerable<IPersonDto>? Persons { get; private set; }

        public async Task<bool> LoadPersonsAsync(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) return false;
            if (!File.Exists(filePath)) return false;
            try
            {
                var json = await File.ReadAllTextAsync(filePath).ConfigureAwait(false);
                Persons = JsonConvert.DeserializeObject<List<PersonDto>>(json);
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
            if (Persons == null || !Persons.Any()) return false;
            var json = JsonConvert.SerializeObject(Persons);
            await using var tw = new StreamWriter(filePath);
            await tw.WriteLineAsync(json);
            return true;
        }
    }
}