using System;
using System.Windows;
using System.Windows.Input;
using AccessControlProject.WPF.Infrastructure.DialogService;
using AccessControlProject.WPF.Infrastructure.Facades;
using AccessControlProject.WPF.Views.Windows;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;

namespace AccessControlProject.WPF.ViewModels.WindowViewModels;

public class FileDecryptionWindowViewModel : ViewModel
{
    private readonly IDialogService _dialogService;
    private readonly SystemFacade _systemFacade;

    public FileDecryptionWindowViewModel(SystemFacade systemFacade, IDialogService dialogService)
    {
        _systemFacade = systemFacade;
        _dialogService = dialogService;

        DecryptCommand = new LambdaCommand(OnDecryptCommandExecuted, CanDecryptCommandExecute);
    }

    #region Title : string - Заголовок окна

    /// <summary>Заголовок окна</summary>
    private string _title = "Расшифровка файла";

    /// <summary>Заголовок окна</summary>
    public string Title
    {
        get => _title;
        set => Set(ref _title!, value);
    }

    #endregion

    #region Caption : string - Описание вводимых данных

    /// <summary>Описание вводимых данных</summary>
    private string _caption = "Введите ключ для расшифровки:";

    /// <summary>Описание вводимых данных</summary>
    public string Caption
    {
        get => _caption;
        set => Set(ref _caption!, value);
    }

    #endregion

    #region Key : string - Ключ расшифровки файла

    /// <summary>Ключ расшифровки файла</summary>
    private string _key = string.Empty;

    /// <summary>Ключ расшифровки файла</summary>
    public string Key
    {
        get => _key;
        set => Set(ref _key!, value);
    }

    #endregion

    #region Command DecryptCommand - Команда расшифровки файла

    /// <summary>Команда расшифровки файла</summary>
    public ICommand DecryptCommand { get; }

    /// <summary>Проверка возможности выполнения - Команда расшифровки файла</summary>
    private bool CanDecryptCommandExecute()
    {
        return Key.IsNotNullOrEmpty();
    }

    /// <summary>Логика выполнения - Команда расшифровки файла</summary>
    private async void OnDecryptCommandExecuted(object? p)
    {
        if (p is not Window window) return;
        var isLoaded = await _systemFacade.LoadData(Key, _dialogService.ShowError);
        if (!isLoaded) return;
        new AuthorizationWindow().Show();
        window.Close();
    }

    #endregion
}