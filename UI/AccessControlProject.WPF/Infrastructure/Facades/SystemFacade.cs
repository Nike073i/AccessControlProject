using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AccessControlProject.Dto;
using AccessControlProject.Interfaces.Services;
using Microsoft.Extensions.Configuration;

namespace AccessControlProject.WPF.Infrastructure.Facades;

public class SystemFacade : IDisposable
{
    private readonly int _attemptsCount;
    private readonly string _dataFilePath;
    private readonly IDataService _dataService;
    private readonly string _encryptFilePath;

    private readonly IEncryptionService _encryptionService;
    private readonly ISecurityService _securityService;

    private PersonDto? _currentPerson;
    private string _fileKey = string.Empty;
    private int _residueAttempts;

    public SystemFacade(IEncryptionService encryptionService, ISecurityService securityService,
        IDataService dataService, IConfiguration configuration)
    {
        _encryptionService = encryptionService;
        _dataService = dataService;
        _securityService = securityService;
        _encryptFilePath = configuration["Persons:FilePath"];
        _dataFilePath = configuration["Persons:FilePathTmp"];
        _attemptsCount = int.Parse(configuration["Authorization:AttemptsCount"]);
        _residueAttempts = _attemptsCount;
    }

    public void Dispose()
    {
        SaveData();
    }

    public bool Authorization(string login, string password, Action<string, string> badResultAction)
    {
        if (_residueAttempts < 1)
        {
            badResultAction("Все попытки исчерпаны. Завершение работы", "Неверный пароль");
            Application.Current.Shutdown();
            return false;
        }

        try
        {
            var person = _securityService.Authentication(login, password);
            if (person != null)
            {
                _residueAttempts = _attemptsCount;
                _currentPerson = person;
            }
            else
            {
                badResultAction($"Указан неверный пароль. Осталось(ась) {_residueAttempts} попыток(ка)", "Неверный пароль");
                --_residueAttempts;
            }

            return person != null;
        }
        catch (Exception ex)
        {
            badResultAction(ex.Message, "Ошибка авторизации");
            return false;
        }
    }

    public bool IsAdmin()
    {
        return _currentPerson != null && _currentPerson.IsAdmin();
    }

    public void Logout()
    {
        _residueAttempts = _attemptsCount;
        _currentPerson = null;
    }

    public bool ChangePassword(string currentPassword, string newPassword, Action<string, string> badResultAction)
    {
        if (_currentPerson == null) return false;
        try
        {
            _securityService.ChangePassword(_currentPerson.Login, currentPassword, newPassword);
            _currentPerson = _securityService.Authentication(_currentPerson.Login, newPassword);
            return true;
        }
        catch (Exception ex)
        {
            badResultAction(ex.Message, "Ошибка смены пароля");
            return false;
        }
    }

    public async Task<bool> LoadData(string key, Action<string, string> badResultAction)
    {
        if (Encoding.UTF8.GetBytes(key).Length != 8)
        {
            badResultAction("Введен некорректный ключ. Ключ должен быть длиной 64-бита", "Неправильный ключ");
            return false;
        }

        if (!File.Exists(_encryptFilePath))
            _dataService.InitializePersons();
        else
            try
            {
                _encryptionService.DecryptFile(_encryptFilePath, _dataFilePath, key);
                await _dataService.LoadPersonsAsync(_dataFilePath);
            }
            catch (Exception)
            {
                badResultAction("Введена некорректная парольная фраза. Завершение работы.", "Ошибка расшифровки");
                Application.Current.Shutdown();
                return false;
            }
            finally
            {
                if (File.Exists(_dataFilePath))
                    File.Delete(_dataFilePath);
            }

        _fileKey = key;
        return true;
    }

    public void SaveData()
    {
        if (string.IsNullOrEmpty(_fileKey) || _dataService.PersonCount == 0) return;
        try
        {
            _dataService.SavePersonsAsync(_dataFilePath);
            _encryptionService.EncryptFile(_dataFilePath, _encryptFilePath, _fileKey);
            File.Delete(_dataFilePath);
        }
        catch (Exception)
        {
        }
    }
}