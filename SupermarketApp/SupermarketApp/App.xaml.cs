using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

using System.Windows;
using SupermarketApp.StartupHelper;
using System.Configuration;

namespace SupermarketApp
{
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    // Configure database context //
                    string connectionString = ConfigurationManager.ConnectionStrings["SupermarketDbContext"].ConnectionString;
                    services.AddDatabaseServices(connectionString);

                    // Configure services //
                    services.AddBusinessServices();

                    // Configure forms //
                    services.AddSingleton<MainWindow>();
                    //services.AddFormFactory<ChildWindow>(); 
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
            startupForm.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
            base.OnExit(e);
        }
    }

}
