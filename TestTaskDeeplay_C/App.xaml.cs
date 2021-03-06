using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Windows;
using TestTaskDeeplay_C.Data;
using TestTaskDeeplay_C.Services;
using TestTaskDeeplay_C.ViewModels;

namespace TestTaskDeeplay_C
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Текущее окно
        public static Window ActiveWindow => Application.Current.Windows
               .OfType<Window>()
               .FirstOrDefault(w => w.IsActive);

        public static Window FocusedWindow => Application.Current.Windows
           .OfType<Window>()
           .FirstOrDefault(w => w.IsFocused);

        public static Window CurrentWindow => FocusedWindow ?? ActiveWindow;
        #endregion
        #region Конфигурация
        private static IHost _Host;

        public static IHost Host => _Host
            ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static IServiceProvider Servies => Host.Services;

        internal static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
            .AddDatabase(host.Configuration.GetSection("Database"))
            .AddServices()
            .AddViewModels();
        #endregion
        #region Инициализация БД
        protected override async void OnStartup(StartupEventArgs e)
        {
            var host = Host;

            using (var scope = Servies.CreateScope())
                scope.ServiceProvider.GetRequiredService<DbInitializer>().InitializeAsync().Wait();

            base.OnStartup(e);
            await host.StartAsync();
        }
        #endregion
        #region Отключение от БД
        protected override async void OnExit(ExitEventArgs e)
        {
            using var host = Host;
            base.OnExit(e);
            await host.StopAsync();
        }
        #endregion
    }
}
