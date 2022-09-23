using AccessControlProject.Dto;

namespace AccessControlProject.Interfaces.Services
{
    public interface IDataService
    {
        IEnumerable<PersonDto> Persons { get; }
        public bool UpdatePerson(PersonDto person);
        public PersonDto? GetPersonByLogin(string login);
        Task<bool> LoadPersonsAsync(string path);
        Task<bool> SavePersonsAsync(string path);
    }
}