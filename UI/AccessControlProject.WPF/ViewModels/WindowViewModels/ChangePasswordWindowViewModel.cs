using System;
using System.Windows;
using System.Windows.Input;
using AccessControlProject.WPF.Infrastructure.DialogService;
using AccessControlProject.WPF.Infrastructure.Facades;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;

namespace AccessControlProject.WPF.ViewModels.WindowViewModels;

public class ChangePasswordWindowViewModel : ViewModel
{
    private readonly IDialogService _dialogService;
    private readonly SystemFacade _systemFacade;

    public ChangePasswordWindowViewModel(IDialogService dialogService, SystemFacade systemFacade)
    {
        _dialogService = dialogService;
        _systemFacade = systemFacade;

        ChangeCommand = new LambdaCommand(OnChangeCommandExecuted, CanChangeCommandExecute);
    }

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
    public ICommand ChangeCommand { get; }

    /// <summary>Проверка возможности выполнения - Команда изменения пароля пользователя</summary>
    private bool CanChangeCommandExecute(object? parameters)
    {
        return NewPassword.IsNotNullOrEmpty() && RepeatNewPassword.IsNotNullOrEmpty();
    }

    /// <summary>Логика выполнения - Команда изменения пароля пользователя</summary>
    private void OnChangeCommandExecuted(object? parameter)
    {
        if (parameter is not Window window) return;
        if (!NewPassword.Equals(RepeatNewPassword))
        {
            _dialogService.ShowWarning("Введенные новые пароли не совпадают", "Неправильный ввод");
            return;
        }

        if (!_systemFacade.ChangePassword(_currentPassword, _newPassword, _dialogService.ShowError)) return;
        window.DialogResult = true;
        window.Close();
    }

    #endregion
}