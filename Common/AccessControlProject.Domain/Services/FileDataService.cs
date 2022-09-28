using AccessControlProject.Dto;
using AccessControlProject.Interfaces.Services;
using Newtonsoft.Json;

namespace AccessControlProject.Domain.Services;

public class FileDataService : IDataService
{
    private List<PersonDto> _persons = new();

    public IEnumerable<PersonDto> Persons => _persons.Select(p => new PersonDto(ref p));

    public int PersonCount => _persons.Count;

    public bool UpdatePerson(PersonDto person)
    {
        var indexPerson = _persons.FindIndex(p => p.Login.Equals(person.Login));
        if (indexPerson == -1) return false;
        _persons[indexPerson] = new PersonDto(ref person);

        return true;
    }

    public PersonDto? AddPerson(PersonDto person)
    {
        if (_persons.Exists(p => p.Login.Equals(person.Login))) return null;
        _persons.Add(person);
        return person;
    }

    public PersonDto? GetPersonByLogin(string login)
    {
        var person = _persons.FirstOrDefault(p => p.Login.Equals(login));
        return person != null ? new PersonDto(ref person) : null;
    }

    public async Task<bool> LoadPersonsAsync(string filePath)
    {
        if (string.IsNullOrEmpty(filePath)) throw new ArgumentNullException(nameof(filePath));
        if (!File.Exists(filePath))
            throw new FileNotFoundException("Указанный файл не существует", filePath);
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
        catch (JsonException ex)
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

    public void InitializePersons()
    {
        _persons = new List<PersonDto> { new("ADMIN", "") };
    }
}