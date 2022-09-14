using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace AccessControlProject.WPF.ViewModels.WindowViewModels
{
    public class AuthorizationWindowViewModel : ViewModel
    {
        #region Title : string - Название окна

        private string _title = "Авторизация";

        public string Title
        {
            get => _title;
            set => Set(ref _title!, value);
        }

        #endregion

        #region Login : string - Логин пользователя

        /// <summary>Логин пользователя</summary>
        private string _login = "ADMIN";

        /// <summary>Логин пользователя</summary>
        public string Login
        {
            get => _login;
            set => Set(ref _login!, value);
        }

        #endregion

        #region Password : string - Пароль пользователя

        /// <summary>Пароль пользователя</summary>
        private string _password = string.Empty;

        /// <summary>Пароль пользователя</summary>
        public string Password
        {
            get => _password;
            set => Set(ref _password!, value);
        }

        #endregion

        #region Command : LoginCommand - Команда авторизации в системе

        /// <summary>Команда авторизации в системе</summary>
        private ICommand? _loginCommand;

        /// <summary>Команда авторизации в системе</summary>
        public ICommand LoginCommand => _loginCommand
            ??= new LambdaCommand(OnLoginCommandExecuted, CanLoginCommandExecute);

        /// <summary>Проверка возможности выполнения - Команда авторизации в системе</summary>
        private bool CanLoginCommandExecute(object? parameter) => Login.IsNotNullOrEmpty() && Password.IsNotNullOrEmpty();

        /// <summary>Логика выполнения - Команда авторизации в системе</summary>
        private void OnLoginCommandExecuted(object? parameter)
        {
            // Логика авторизации
        }

        #endregion
    }
}
