using System.Windows.Input;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;

namespace AccessControlProject.WPF.ViewModels.WindowViewModels
{
    public class MainWindowViewModel : ViewModel
    {
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
    }
}
