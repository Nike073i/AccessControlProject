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
    }
}
