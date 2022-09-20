using AccessControlProject.WPF.Infrastructure.DialogService;
using AccessControlProject.WPF.Views.Windows;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace AccessControlProject.WPF.ViewModels.WindowViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private readonly IDialogService _dialogService;
        private readonly UserManagementViewModel _userManagementVm;

        public MainWindowViewModel(IDialogService dialogService, UserManagementViewModel userManagementVm)
        {
            _dialogService = dialogService;
            _userManagementVm = userManagementVm;
        }

        #region Title : string - Название окна

        private string _title = string.Empty;

        public string Title
        {
            get => _title;
            set => Set(ref _title!, value);
        }

        #endregion

        #region CurrentModel : ViewModel - Текущее представление

        private ViewModel? _currentModel;

        public ViewModel? CurrentModel
        {
            get => _currentModel;
            private set => Set(ref _currentModel, value);
        }

        #endregion

        #region IsAdmin : bool - Флаг администратора

        /// <summary>Флаг администратора</summary>
        private bool _isAdmin;

        /// <summary>Флаг администратора</summary>
        public bool IsAdmin
        {
            get => _isAdmin;
            private set => Set(ref _isAdmin, value);
        }

        #endregion

        #region Command AboutCommand - Команда запроса описания программы

        /// <summary>Команда запроса описания программы</summary>
        private ICommand? _aboutCommand;

        /// <summary>Команда запроса описания программы</summary>
        public ICommand AboutCommand => _aboutCommand
            ??= new LambdaCommand(OnAboutCommandExecuted);

        /// <summary>Логика выполнения - Команда запроса описания программы</summary>
        private void OnAboutCommandExecuted()
        {
            // Логика About
        }

        #endregion

        #region Command LogoutCommand - Команда выхода из аккаунта

        /// <summary>Команда выхода из аккаунта</summary>
        private ICommand? _logoutCommand;

        /// <summary>Команда выхода из аккаунта</summary>
        public ICommand LogoutCommand => _logoutCommand
            ??= new LambdaCommand(OnLogoutCommandExecuted, CanLogoutCommandExecute);

        /// <summary>Проверка возможности выполнения - Команда выхода из аккаунта</summary>
        private bool CanLogoutCommandExecute() => true;

        /// <summary>Логика выполнения - Команда выхода из аккаунта</summary>
        private void OnLogoutCommandExecuted()
        {
            // Логика выхода
        }

        #endregion

        #region Command ShowAdminViewCommand - Команда вызова админской панели

        /// <summary>Команда вызова админской панели</summary>
        private ICommand? _showAdminViewCommand;

        /// <summary>Команда вызова админской панели</summary>
        public ICommand ShowAdminViewCommand => _showAdminViewCommand
            ??= new LambdaCommand(OnShowAdminViewCommandExecuted, CanShowAdminViewCommandExecute);

        /// <summary>Проверка возможности выполнения - Команда вызова админской панели</summary>
        private bool CanShowAdminViewCommandExecute() => true;

        /// <summary>Логика выполнения - Команда вызова админской панели</summary>
        private void OnShowAdminViewCommandExecuted()
        {
            CurrentModel = _userManagementVm;
        }

        #endregion

        #region Command ShowChangePasswordWindowCommand - Команда вызова окна смены пароля

        /// <summary>Команда вызова окна смены пароля</summary>
        private ICommand? _showChangePasswordWindowCommand;

        /// <summary>Команда вызова окна смены пароля</summary>
        public ICommand ShowChangePasswordWindowCommand => _showChangePasswordWindowCommand
            ??= new LambdaCommand(OnShowChangePasswordWindowCommandExecuted);

        /// <summary>Логика выполнения - Команда вызова окна смены пароля</summary>
        private void OnShowChangePasswordWindowCommandExecuted()
        {
            var dlg = new ChangePasswordWindow
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            dlg.ShowDialog();
        }

        #endregion
    }
}
