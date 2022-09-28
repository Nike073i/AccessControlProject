using AccessControlProject.Domain.Services;
using AccessControlProject.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AccessControlProject.Domain.Di;

public static class ServiceRegistrar
{
    public static IServiceCollection RegisterDomainService(this IServiceCollection services)
    {
        services.AddTransient<IEncryptionService, DesEncryptionService>();
        services.AddSingleton<IDataService, FileDataService>();
        services.AddTransient<ISecurityService, SecurityService>();
        services.AddTransient<IAdminService, AdminService>();
        return services;
    }
}