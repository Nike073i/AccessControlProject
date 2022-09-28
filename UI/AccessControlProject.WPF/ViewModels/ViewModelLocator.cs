using System;
using AccessControlProject.WPF.ViewModels.WindowViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace AccessControlProject.WPF.ViewModels;

public class ViewModelLocator
{
    private static readonly IServiceProvider ServiceProvider = App.Host.Services;
    public MainWindowViewModel MainWindowVm => ServiceProvider.GetRequiredService<MainWindowViewModel>();

    public ChangePasswordWindowViewModel ChangePasswordWindowVm =>
        ServiceProvider.GetRequiredService<ChangePasswordWindowViewModel>();

    public FileDecryptionWindowViewModel FileDecryptionWindowVm =>
        ServiceProvider.GetRequiredService<FileDecryptionWindowViewModel>();

    public AuthorizationWindowViewModel AuthWindowVm =>
        ServiceProvider.GetRequiredService<AuthorizationWindowViewModel>();
}