namespace AccessControlProject.WPF.Infrastructure.DialogService
{
    public interface IDialogService
    {
        void ShowInformation(string information, string caption);

        void ShowWarning(string message, string caption);

        void ShowError(string message, string caption);

        bool Confirm(string message, string caption, bool exclamation = false);
    }
}
