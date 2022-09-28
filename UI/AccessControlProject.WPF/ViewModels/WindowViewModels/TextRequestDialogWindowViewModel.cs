using MathCore.ViewModels;

namespace AccessControlProject.WPF.ViewModels.WindowViewModels;

public class TextRequestDialogWindowViewModel : ViewModel
{
    #region Title : string - Название окна

    private string _title = "Заголовок";

    public string Title
    {
        get => _title;
        set => Set(ref _title!, value);
    }

    #endregion

    #region Caption : string - Сообщение диалога

    /// <summary>Сообщение диалога</summary>
    private string _caption = "Сообщение";
    
    /// <summary>Сообщение диалога</summary>
    public string Caption
    {
        get => this._caption;
        set => this.Set(ref _caption, value);
    }
    
    #endregion
    
    #region Value : string - Результат диалога
    
    /// <summary>Результат диалога</summary>
    private string _value = "Введите текст";

    /// <summary>Результат диалога</summary>
    public string Value
    {
        get => this._value;
        set => this.Set(ref _value, value);
    }
    
    #endregion
}