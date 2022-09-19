using AccessControlProject.Domain.Services;
using AccessControlProject.Domain.Services.Base;
using AccessControlProject.Interfaces.Services;
using AccessControlProject.Interfaces.Services.Base;
using Microsoft.Extensions.DependencyInjection;

namespace AccessControlProject.Domain.Di
{
    public static class ServiceRegistrar
    {
        public static IServiceCollection RegisterDomainService(this IServiceCollection services)
        {
            services.AddTransient<IEncryptionService, FileEncryptionService>();
            services.AddTransient<IAuthService, FileAuthService>();
            services.AddTransient<IAdminService, AdminService>();
            services.AddTransient<IPersonService, PersonService>();
            return services;
        }
    }
}
