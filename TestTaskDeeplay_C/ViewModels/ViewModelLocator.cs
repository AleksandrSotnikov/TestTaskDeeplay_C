using Microsoft.Extensions.DependencyInjection;

namespace TestTaskDeeplay_C.ViewModels
{
    class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.Servies.GetRequiredService<MainWindowViewModel>();
    }
}
