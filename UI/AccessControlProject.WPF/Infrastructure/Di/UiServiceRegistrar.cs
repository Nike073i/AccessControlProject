using AccessControlProject.WPF.Infrastructure.DialogService;
using Microsoft.Extensions.DependencyInjection;

namespace AccessControlProject.WPF.Infrastructure.Di
{
    public static class UiServiceRegistrar
    {
        public static IServiceCollection RegisterUiServices(this IServiceCollection services)
        {
            services.AddTransient<IDialogService, WindowDialogService>();
            return services;
        }
    }
}
