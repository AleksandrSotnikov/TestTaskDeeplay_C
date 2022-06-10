using Microsoft.Extensions.DependencyInjection;
using TestTaskDeeplay_C.Service;
using TestTaskDeeplay_C.Service.Interfaces;

namespace TestTaskDeeplay_C.Services
{
    static class ServicesRegistator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddTransient<IUserDialog, UserDialogService>();
    }
}
