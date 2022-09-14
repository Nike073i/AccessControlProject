using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using System;
using System.Windows.Input;

namespace AccessControlProject.WPF.ViewModels.WindowViewModels
{
    public class ChangePasswordWindowViewModel : ViewModel
    {
        #region Title : string - Название окна

        private string _title = "Смена пароля";

        public string Title
        {
            get => _title;
            set => Set(ref _title!, value);
        }

        #endregion

        #region CurrentPassword : string - Текущий пароль

        /// <summary>Текущий пароль</summary>
        private string _currentPassword = string.Empty;

        /// <summary>Текущий пароль</summary>
        public string CurrentPassword
        {
            get => _currentPassword;
            set => Set(ref _currentPassword!, value);
        }

        #endregion

        #region NewPassword : string - Новый пароль

        /// <summary>Новый пароль</summary>
        private string _newPassword = string.Empty;

        /// <summary>Новый пароль</summary>
        public string NewPassword
        {
            get => _newPassword;
            set => Set(ref _newPassword!, value);
        }

        #endregion

        #region RepeatNewPassword : string - Повтор нового пароля

        /// <summary>Повтор нового пароля</summary>
        private string _repeatNewPassword = string.Empty;

        /// <summary>Повтор нового пароля</summary>
        public string RepeatNewPassword
        {
            get => _repeatNewPassword;
            set => Set(ref _repeatNewPassword!, value);
        }

        #endregion

        #region Command : ChangeCommand - Команда изменения пароля пользователя

        /// <summary>Команда изменения пароля пользователя</summary>
        private ICommand? _changeCommand;

        /// <summary>Команда изменения пароля пользователя</summary>
        public ICommand ChangeCommand => _changeCommand
            ??= new LambdaCommand(OnChangeCommandExecuted, CanChangeCommandExecute);

        /// <summary>Проверка возможности выполнения - Команда изменения пароля пользователя</summary>
        private bool CanChangeCommandExecute(object? parameters) =>
            CurrentPassword.IsNotNullOrEmpty() && NewPassword.IsNotNullOrEmpty() && RepeatNewPassword.IsNotNullOrEmpty();

        /// <summary>Логика выполнения - Команда изменения пароля пользователя</summary>
        private void OnChangeCommandExecuted(object? parameter)
        {
            // Логики смены пароля
        }

        #endregion
    }
}
