using System;
using System.Windows;
using System.Windows.Input;
using AccessControlProject.WPF.Infrastructure.DialogService;
using AccessControlProject.WPF.Infrastructure.Facades;
using AccessControlProject.WPF.Views.Windows;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;

namespace AccessControlProject.WPF.ViewModels.WindowViewModels;

public class AuthorizationWindowViewModel : ViewModel
{
    private readonly IDialogService _dialogService;
    private readonly SystemFacade _systemFacade;

    public AuthorizationWindowViewModel(SystemFacade systemFacade, IDialogService dialogService)
    {
        _systemFacade = systemFacade;
        _dialogService = dialogService;

        LoginCommand = new LambdaCommand(OnLoginCommandExecuted, CanLoginCommandExecute);
    }

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
    public ICommand LoginCommand { get; }

    /// <summary>Проверка возможности выполнения - Команда авторизации в системе</summary>
    private bool CanLoginCommandExecute(object? parameter)
    {
        return Login.IsNotNullOrEmpty();
    }

    /// <summary>Логика выполнения - Команда авторизации в системе</summary>
    private void OnLoginCommandExecuted(object? p)
    {
        if (p is not Window window) return;
        if (!_systemFacade.Authorization(Login, Password, _dialogService.ShowError)) return;
        if (Password.Equals(string.Empty))
        {
            var dlg = new ChangePasswordWindow();
            dlg.ShowDialog();
            if (dlg.DialogResult == false) return;
        }

        new MainWindow().Show();
        window.Close();
    }

    #endregion
}