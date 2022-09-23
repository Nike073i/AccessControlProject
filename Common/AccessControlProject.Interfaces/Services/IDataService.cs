namespace AccessControlProject.Interfaces.Services
{
    public interface IDataService
    {
        IEnumerable<IPersonDto> Persons { get; }
        public bool UpdatePerson(IPersonDto person);
        public IPersonDto? GetPersonByLogin(string login);
        Task<bool> LoadPersonsAsync(string path);
        Task<bool> SavePersonsAsync(string path);
    }
}