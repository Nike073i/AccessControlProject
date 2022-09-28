using AccessControlProject.Dto;

namespace AccessControlProject.Interfaces.Services;

public interface IDataService
{
    IEnumerable<PersonDto> Persons { get; }
    public int PersonCount { get; }
    public bool UpdatePerson(PersonDto person);
    PersonDto? AddPerson(PersonDto person);
    public PersonDto? GetPersonByLogin(string login);
    void InitializePersons();
    Task<bool> LoadPersonsAsync(string path);
    Task<bool> SavePersonsAsync(string path);
}