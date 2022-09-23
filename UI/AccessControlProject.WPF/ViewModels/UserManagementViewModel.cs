using AccessControlProject.Dto;
using AccessControlProject.Interfaces.Services;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AccessControlProject.WPF.ViewModels
{
    public class UserManagementViewModel : ViewModel
    {
        private readonly IAdminService _adminService;

        public UserManagementViewModel(IAdminService adminService)
        {
            _adminService = adminService;
        }

        #region Persons : ObservableCollection<IPersonDto> - Список пользователей

        /// <summary>Список пользователей</summary>
        private ObservableCollection<PersonDto>? _persons;

        /// <summary>Список пользователей</summary>
        public ObservableCollection<PersonDto>? Persons
        {
            get => _persons;
            set => Set(ref _persons, value);
        }

        #endregion

        #region SelectedPerson : IPersonDto - Выбранный пользователь

        /// <summary>Выбранный пользователь</summary>
        private PersonDto? _selectedPerson;

        /// <summary>Выбранный пользователь</summary>
        public PersonDto? SelectedPerson
        {
            get => _selectedPerson;
            set => Set(ref _selectedPerson, value);
        }

        #endregion

        #region Command LoadPersonsCommand - Команда загрузки данных пользователей

        /// <summary>Команда загрузки данных пользователей</summary>
        private ICommand? _loadPersonsCommand;

        /// <summary>Команда загрузки данных пользователей</summary>
        public ICommand LoadPersonsCommand => _loadPersonsCommand
            ??= new LambdaCommandAsync(OnLoadPersonsCommandExecuted);

        /// <summary>Логика выполнения - Команда загрузки данных пользователей</summary>
        private async Task OnLoadPersonsCommandExecuted()
        {
            //Persons = new ObservableCollection<IPersonDto>(await _adminService.GetPersonsAsync());
        }

        #endregion

        #region Command AddPersonCommand - Команда добавления нового пользователя

        /// <summary>Команда добавления нового пользователя</summary>
        private ICommand? _addPersonCommand;

        /// <summary>Команда добавления нового пользователя</summary>
        public ICommand AddPersonCommand => _addPersonCommand
            ??= new LambdaCommand(OnAddPersonCommandExecuted, CanAddPersonCommandExecute);

        /// <summary>Проверка возможности выполнения - Команда добавления нового пользователя</summary>
        private bool CanAddPersonCommandExecute() => true;

        /// <summary>Логика выполнения - Команда добавления нового пользователя</summary>
        private void OnAddPersonCommandExecuted()
        {

        }

        #endregion

        #region Command BlockPersonCommand - Команда взаимодействия с блокировкой пользователя

        /// <summary>Команда блокировки/разблокировки пользователя</summary>
        private ICommand? _blockPersonCommand;

        /// <summary>Команда блокировки/разблокировки пользователя</summary>
        public ICommand BlockPersonCommand => _blockPersonCommand
            ??= new LambdaCommand(OnBlockPersonCommandExecuted, CanBlockPersonCommandExecute);

        /// <summary>Проверка возможности выполнения - Команда блокировки/разблокировки пользователя</summary>
        private bool CanBlockPersonCommandExecute() => true;

        /// <summary>Логика выполнения - Команда блокировки/разблокировки пользователя</summary>
        private void OnBlockPersonCommandExecuted()
        {

        }

        #endregion

        #region Command RestrictPersonCommand - Команда взаимодействия с ограничением пользователя

        /// <summary>Команда взаимодействия с ограничением пользователя</summary>
        private ICommand? _restrictPersonCommand;

        /// <summary>Команда взаимодействия с ограничением пользователя</summary>
        public ICommand RestrictPersonCommand => _restrictPersonCommand
            ??= new LambdaCommand(OnRestrictPersonCommandExecuted, CanRestrictPersonCommandExecute);

        /// <summary>Проверка возможности выполнения - Команда взаимодействия с ограничением пользователя</summary>
        private bool CanRestrictPersonCommandExecute() => true;

        /// <summary>Логика выполнения - Команда взаимодействия с ограничением пользователя</summary>
        private void OnRestrictPersonCommandExecuted()
        {

        }

        #endregion

        #region Command SetNextPersonCommand - Команда установки следующего из списка пользователя

        /// <summary>Команда установки следующего из списка пользователя</summary>
        private ICommand? _setNextPersonCommand;

        /// <summary>Команда установки следующего из списка пользователя</summary>
        public ICommand SetNextPersonCommand => _setNextPersonCommand
            ??= new LambdaCommand(OnSetNextPersonCommandExecuted, CanSetNextPersonCommandExecute);

        /// <summary>Проверка возможности выполнения - Команда установки следующего из списка пользователя</summary>
        private bool CanSetNextPersonCommandExecute() => true;

        /// <summary>Логика выполнения - Команда установки следующего из списка пользователя</summary>
        private void OnSetNextPersonCommandExecuted()
        {

        }

        #endregion

        #region Command SetPrevPersonCommand - Команда установки предыдущего из списка пользователя

        /// <summary>Команда установки предыдущего пользователя из списка</summary>
        private ICommand? _setPrevPersonCommand;

        /// <summary>Команда установки предыдущего пользователя из списка</summary>
        public ICommand SetPrevPersonCommand => _setPrevPersonCommand
            ??= new LambdaCommand(OnSetPrevPersonCommandExecuted, CanSetPrevPersonCommandExecute);

        /// <summary>Проверка возможности выполнения - Команда установки предыдущего пользователя из списка</summary>
        private bool CanSetPrevPersonCommandExecute() => true;

        /// <summary>Логика выполнения - Команда установки предыдущего пользователя из списка</summary>
        private void OnSetPrevPersonCommandExecuted()
        {

        }

        #endregion
    }
}
