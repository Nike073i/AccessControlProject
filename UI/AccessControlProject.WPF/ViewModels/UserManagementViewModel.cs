using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using AccessControlProject.Dto;
using AccessControlProject.Interfaces.Services;
using AccessControlProject.WPF.Infrastructure.DialogService;
using AccessControlProject.WPF.ViewModels.WindowViewModels;
using AccessControlProject.WPF.Views.Windows;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;

namespace AccessControlProject.WPF.ViewModels;

public class UserManagementViewModel : ViewModel
{
    private readonly IAdminService _adminService;
    private readonly IDataService _dataService;
    private readonly IDialogService _dialogService;

    public UserManagementViewModel(IAdminService adminService, IDataService dataService, IDialogService dialogService)
    {
        _adminService = adminService;
        _dataService = dataService;
        _dialogService = dialogService;

        AddPersonCommand = new LambdaCommand(OnAddPersonCommandExecuted);
        BlockPersonCommand = new LambdaCommand(OnBlockPersonCommandExecuted);
        RestrictPersonCommand = new LambdaCommand(OnRestrictPersonCommandExecuted);
        SetNextPersonCommand = new LambdaCommand(OnSetNextPersonCommandExecuted, CanSetNextPersonCommandExecute);
        SetPrevPersonCommand = new LambdaCommand(OnSetPrevPersonCommandExecuted, CanSetPrevPersonCommandExecute);
        LoadCommand = new LambdaCommand(OnLoadCommandExecuted);
    }
    
    #region SelectedIndex : Index - Индекс выбранного пользователя

    /// <summary>Индекс выбранного пользователя</summary>
    private int _selectedIndex;

    /// <summary>Индекс выбранного пользователя</summary>
    public int SelectedIndex
    {
        get => _selectedIndex;
        set => Set(ref _selectedIndex, value);
    }

    #endregion
    
    #region SelectedPerson : PersonDto - Выбранный пользователь

    /// <summary>Выбранный пользователь</summary>
    private PersonDto? _selectedPerson;

    /// <summary>Выбранный пользователь</summary>
    public PersonDto? SelectedPerson
    {
        get => _selectedPerson;
        set => Set(ref _selectedPerson, value);
    }

    #endregion

    #region Persons : ObservableCollection<PersonDto> - Список пользователей

    /// <summary>Список пользователей</summary>
    private List<PersonDto> _persons = new();

    /// <summary>Список пользователей</summary>
    public List<PersonDto> Persons
    {
        get => _persons;
        private set => Set(ref _persons!, value);
    }

    #endregion

    #region Command AddPersonCommand - Команда добавления нового пользователя

    /// <summary>Команда добавления нового пользователя</summary>
    public ICommand AddPersonCommand { get; }

    /// <summary>Логика выполнения - Команда добавления нового пользователя</summary>
    private void OnAddPersonCommandExecuted()
    {
        var vm = new TextRequestDialogWindowViewModel
        {
            Caption = "Введите имя пользователя",
            Value = "New user",
            Title = "Создание пользователя"
        };
        var dlg = new TextRequestDialogWindow
        {
            DataContext = vm
        };
        if (!dlg.ShowDialog() == true || string.IsNullOrEmpty(vm.Value)) return;
        if (_adminService.AddPerson(vm.Value) == null)
        {
            _dialogService.ShowWarning("Пользователь с таким логином уже существует", "Ошибка создания пользователя");
            return;
        }
        LoadCommand.Execute(null);
    }

    #endregion

    #region Command BlockPersonCommand - Команда взаимодействия с блокировкой пользователя

    /// <summary>Команда блокировки/разблокировки пользователя</summary>
    public ICommand BlockPersonCommand { get; }

    /// <summary>Логика выполнения - Команда блокировки/разблокировки пользователя</summary>
    private void OnBlockPersonCommandExecuted(object? parameter)
    {
        if (parameter is not PersonDto person) return;
        _adminService.SetBlockPerson(person.Login, !person.IsBlocked);
        LoadCommand.Execute(null);
    }

    #endregion

    #region Command RestrictPersonCommand - Команда взаимодействия с ограничением пользователя

    /// <summary>Команда взаимодействия с ограничением пользователя</summary>
    public ICommand RestrictPersonCommand { get; }

    /// <summary>Логика выполнения - Команда взаимодействия с ограничением пользователя</summary>
    private void OnRestrictPersonCommandExecuted(object? parameter)
    {
        if (parameter is not PersonDto person) return;
        _adminService.SetPasswordLimit(person.Login, !person.IsLimited);
        LoadCommand.Execute(null);
    }

    #endregion

    #region Command SetNextPersonCommand - Команда установки следующего из списка пользователя

    /// <summary>Команда установки следующего из списка пользователя</summary>
    public ICommand SetNextPersonCommand { get; }
    /// <summary>Проверка возможности выполнения - Команда установки следующего из списка пользователя</summary>
    private bool CanSetNextPersonCommandExecute()
    {
        return Persons.Any();
    }

    /// <summary>Логика выполнения - Команда установки следующего из списка пользователя</summary>
    private void OnSetNextPersonCommandExecuted()
    {
        SelectedIndex = (SelectedIndex + 1) % Persons.Count;
    }

    #endregion

    #region Command SetPrevPersonCommand - Команда установки предыдущего из списка пользователя

    /// <summary>Команда установки предыдущего пользователя из списка</summary>
    public ICommand SetPrevPersonCommand { get; }

    /// <summary>Проверка возможности выполнения - Команда установки предыдущего пользователя из списка</summary>
    private bool CanSetPrevPersonCommandExecute()
    {
        return Persons.Any();
    }

    /// <summary>Логика выполнения - Команда установки предыдущего пользователя из списка</summary>
    private void OnSetPrevPersonCommandExecuted()
    {
        SelectedIndex = (SelectedIndex + 1) >= Persons.Count ? 0 : SelectedIndex + 1;
    }

    #endregion
    
    #region Command LoadCommandCommand - Команда загрузки данных

    /// <summary>Команда загрузки данных</summary>
    public ICommand LoadCommand { get; }

    /// <summary>Логика выполнения - Команда загрузки данных</summary>
    private void OnLoadCommandExecuted()
    {
        Persons = _dataService.Persons.Where(p => !p.IsAdmin()).ToList();
    }

    #endregion
}