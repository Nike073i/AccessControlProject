using System;

namespace AccessControlProject.WPF.ViewModels
{
    public class ViewModelLocator
    {
        private static IServiceProvider _serviceProvider = App.Host.Services;
    }
}
