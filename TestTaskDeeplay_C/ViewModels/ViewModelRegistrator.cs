using Microsoft.Extensions.DependencyInjection;

namespace TestTaskDeeplay_C.ViewModels
{
    static class ViewModelRegistrator
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>();
    }
}
