using Microsoft.Extensions.Hosting;
using System;
using Microsoft.Extensions.Configuration;

namespace AccessControlProject.WPF
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            var app = new App();
            app.InitializeComponent();
            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] Args)
        {
            return Host.CreateDefaultBuilder(Args)
                .UseContentRoot(App.CurrentDirectory)
                .ConfigureAppConfiguration((host, cfg) =>
                    cfg.SetBasePath(App.CurrentDirectory)
                        .AddJsonFile("appsettings.json", true, true))
                .ConfigureServices(App.ConfigureServices);
        }
    }
}
