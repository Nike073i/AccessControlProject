using AccessControlProject.WPF.ViewModels.WindowViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AccessControlProject.WPF.ViewModels
{
    public class ViewModelLocator
    {
        private static readonly IServiceProvider ServiceProvider = App.Host.Services;
        public MainWindowViewModel MainWindowVm => ServiceProvider.GetRequiredService<MainWindowViewModel>();
    }
}
