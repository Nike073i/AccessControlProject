using MathCore.WPF.ViewModels;

namespace AccessControlProject.WPF.ViewModels.WindowViewModels
{
    public class AuthorizationWindowViewModel : ViewModel
    {
        #region Title : string - Название окна

        private string _title = "Окно авторизации";

        public string Title
        {
            get => _title;
            set => Set(ref _title!, value);
        }

        #endregion
    }
}
