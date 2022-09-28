using AccessControlProject.Dto;
using AccessControlProject.Interfaces.Services;

namespace AccessControlProject.Domain.Services;

public class AdminService : IAdminService
{
    private readonly IDataService _dataService;

    public AdminService(IDataService dataService)
    {
        _dataService = dataService;
    }

    public PersonDto? AddPerson(string login, string password = "")
    {
        return _dataService.AddPerson(new PersonDto(login, password));
    }

    public bool SetBlockPerson(string login, bool isBlocked)
    {
        var foundPerson = _dataService.GetPersonByLogin(login);
        if (foundPerson == null) return false;
        foundPerson.IsBlocked = isBlocked;
        return _dataService.UpdatePerson(foundPerson);
    }

    public bool SetPasswordLimit(string login, bool isLimited)
    {
        var foundPerson = _dataService.GetPersonByLogin(login);
        if (foundPerson == null) return false;
        foundPerson.IsLimited = isLimited;
        return _dataService.UpdatePerson(foundPerson);
    }
}