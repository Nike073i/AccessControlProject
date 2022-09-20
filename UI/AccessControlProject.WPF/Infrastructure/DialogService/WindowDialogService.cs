using System.Windows;

namespace AccessControlProject.WPF.Infrastructure.DialogService
{
    public class WindowDialogService : IDialogService
    {
        public void ShowInformation(string information, string caption)
        {
            MessageBox.Show(information, caption, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ShowWarning(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public void ShowError(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public bool Confirm(string message, string caption, bool exclamation = false)
        {
            return MessageBox.Show(message, caption, MessageBoxButton.YesNo,
                       exclamation ? MessageBoxImage.Exclamation : MessageBoxImage.Question)
                   == MessageBoxResult.Yes;
        }
        
    }
}