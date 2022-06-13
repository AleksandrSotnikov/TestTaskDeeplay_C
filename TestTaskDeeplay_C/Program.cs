using Microsoft.Extensions.Hosting;
using System;

namespace TestTaskDeeplay_C
{
    class Program
    {
        #region Запуск приложения
        [STAThread]
        static void Main(String[] args)
        {
            var app = new App();
            app.InitializeComponent();
            app.Run();
        }
        #endregion
        #region Создание хоста
        public static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureServices(App.ConfigureServices);
        #endregion
    }
}
