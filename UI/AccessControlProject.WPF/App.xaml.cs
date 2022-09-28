using System;
using System.Windows;
using AccessControlProject.Domain.Di;
using AccessControlProject.WPF.Infrastructure.Di;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AccessControlProject.WPF;

public partial class App
{
    private static IHost? _host;
    public static bool IsDesignMode { get; private set; } = true;

    public static IHost Host => _host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

    public static string CurrentDirectory => Environment.CurrentDirectory;

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

    public static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
    {
        services.RegisterDomainService();
        services.RegisterUiServices();
        services.RegisterViewModels();
    }
}