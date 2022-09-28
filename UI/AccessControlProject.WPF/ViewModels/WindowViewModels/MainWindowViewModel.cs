using System.Windows;
using System.Windows.Input;
using AccessControlProject.WPF.Infrastructure.DialogService;
using AccessControlProject.WPF.Infrastructure.Facades;
using AccessControlProject.WPF.Views.Windows;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;

namespace AccessControlProject.WPF.ViewModels.WindowViewModels;

public class MainWindowViewModel : ViewModel
{
    private readonly IDialogService _dialogService;
    private readonly SystemFacade _systemFacade;
    private readonly UserManagementViewModel _userManagementVm;

    public MainWindowViewModel(SystemFacade systemFacade, IDialogService dialogService,
        UserManagementViewModel userManagementVm)
    {
        _systemFacade = systemFacade;
        _dialogService = dialogService;
        _userManagementVm = userManagementVm;

        AboutCommand = new LambdaCommand(OnAboutCommandExecuted);
        LogoutCommand = new LambdaCommand(OnLogoutCommandExecuted);
        ShowAdminViewCommand = new LambdaCommand(OnShowAdminViewCommandExecuted, CanShowAdminViewCommandExecute);
        ShowChangePasswordWindowCommand = new LambdaCommand(OnShowChangePasswordWindowCommandExecuted);
    }

    public bool IsAdmin => _systemFacade.IsAdmin();

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
    public ICommand AboutCommand { get; }

    /// <summary>Логика выполнения - Команда запроса описания программы</summary>
    private void OnAboutCommandExecuted()
    {
        _dialogService.ShowInformation("Работа студента группы ПИбд-42 - Филиппова Н.А. \n" +
                                       "Вариант - 12. \n" +
                                       "Ограничение пароля - Наличие строчных и прописных букв, а также цифр. \n" +
                                       "Режим шифрования алгоритма DES - CBC (OFB .NET не поддерживает). \n" +
                                       "Алгоритм хеширования - SHA"
            , "Автор - Филиппов Н.А.");
    }

    #endregion

    #region Command LogoutCommand - Команда выхода из аккаунта

    /// <summary>Команда выхода из аккаунта</summary>
    public ICommand LogoutCommand { get; }

    /// <summary>Логика выполнения - Команда выхода из аккаунта</summary>
    private void OnLogoutCommandExecuted(object? p)
    {
        if (p is not Window window) return;
        _systemFacade.Logout();
        new AuthorizationWindow().Show();
        window.Close();
    }

    #endregion

    #region Command ShowAdminViewCommand - Команда вызова админской панели

    /// <summary>Команда вызова админской панели</summary>
    public ICommand ShowAdminViewCommand { get; }

    /// <summary>Проверка возможности выполнения - Команда вызова админской панели</summary>
    private bool CanShowAdminViewCommandExecute(object? parameter)
    {
        return IsAdmin;
    }

    /// <summary>Логика выполнения - Команда вызова админской панели</summary>
    private void OnShowAdminViewCommandExecuted()
    {
        CurrentModel = _userManagementVm;
    }

    #endregion

    #region Command ShowChangePasswordWindowCommand - Команда вызова окна смены пароля

    public ICommand ShowChangePasswordWindowCommand { get; }

    /// <summary>Логика выполнения - Команда вызова окна смены пароля</summary>
    private void OnShowChangePasswordWindowCommandExecuted()
    {
        new ChangePasswordWindow().ShowDialog();
    }

    #endregion
}