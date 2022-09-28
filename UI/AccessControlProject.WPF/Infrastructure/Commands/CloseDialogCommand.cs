using System.Windows;
using MathCore.WPF.Commands;

namespace AccessControlProject.WPF.Infrastructure.Commands;

public class CloseDialogCommand : Command
{
    public bool? DialogResult { get; set; }
    public override bool CanExecute(object? parameter)
    {
        return parameter is Window;
    }

    public override void Execute(object? parameter)
    {
        if (!CanExecute(parameter)) return;
        if (parameter is not Window window) return;
        window.DialogResult = DialogResult;
        window.Close();
    }
}