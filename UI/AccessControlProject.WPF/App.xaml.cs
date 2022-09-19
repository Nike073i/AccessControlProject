using AccessControlProject.Domain.Di;
using AccessControlProject.WPF.Infrastructure.Di;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;

namespace AccessControlProject.WPF
{
    public partial class App
    {
        public static bool IsDesignMode { get; private set; } = true;

        protected override async void OnStartup(StartupEventArgs e)
        {
            IsDesignMode = false;

            var host = Host;

            base.OnStartup(e);
            await host.StartAsync();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using var host = Host;
            base.OnExit(e);
            await host.StopAsync();
        }

        private static IHost? _host;

        public static IHost Host => _host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.RegisterDomainService();
            services.RegisterViewModels();
        }

        public static string CurrentDirectory => Environment.CurrentDirectory;
    }
}
