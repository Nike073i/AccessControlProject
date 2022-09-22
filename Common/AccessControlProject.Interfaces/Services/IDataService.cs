namespace AccessControlProject.Interfaces.Services
{
    public interface IDataService
    {
        IEnumerable<IPersonDto>? Persons { get; }
        Task<bool> LoadPersonsAsync(string path);
        Task<bool> SavePersonsAsync(string path);
    }
}