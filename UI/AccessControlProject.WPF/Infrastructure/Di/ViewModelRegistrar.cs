using AccessControlProject.WPF.ViewModels;
using AccessControlProject.WPF.ViewModels.WindowViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace AccessControlProject.WPF.Infrastructure.Di
{
    internal static class ViewModelRegistrar
    {
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<ChangePasswordWindowViewModel>();
            services.AddTransient<AuthorizationWindowViewModel>();
            services.AddTransient<FileDecryptionWindowViewModel>();
            return services;
        }
    }
}
