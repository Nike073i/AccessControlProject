using AccessControlProject.WPF.Infrastructure.DialogService;
using AccessControlProject.WPF.Infrastructure.Facades;
using Microsoft.Extensions.DependencyInjection;

namespace AccessControlProject.WPF.Infrastructure.Di;

public static class UiServiceRegistrar
{
    public static IServiceCollection RegisterUiServices(this IServiceCollection services)
    {
        services.AddTransient<IDialogService, WindowDialogService>();
        services.AddSingleton<SystemFacade>();
        return services;
    }
}