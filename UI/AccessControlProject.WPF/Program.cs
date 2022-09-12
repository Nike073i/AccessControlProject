using Microsoft.Extensions.Hosting;
using System;

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
                .ConfigureServices(App.ConfigureServices);
        }
    }
}
