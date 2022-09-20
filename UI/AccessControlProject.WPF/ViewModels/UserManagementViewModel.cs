using AccessControlProject.Interfaces;
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
        private ObservableCollection<IPersonDto>? _persons;

        /// <summary>Список пользователей</summary>
        public ObservableCollection<IPersonDto>? Persons
        {
            get => _persons;
            set => Set(ref _persons, value);
        }

        #endregion

        #region SelectedPerson : IPersonDto - Выбранный пользователь

        /// <summary>Выбранный пользователь</summary>
        private IPersonDto? _selectedPerson;

        /// <summary>Выбранный пользователь</summary>
        public IPersonDto? SelectedPerson
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
            Persons = new ObservableCollection<IPersonDto>(await _adminService.GetUsersAsync());
        }

        #endregion
    }
}
