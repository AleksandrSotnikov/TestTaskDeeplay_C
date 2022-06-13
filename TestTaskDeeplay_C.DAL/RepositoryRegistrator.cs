using Microsoft.Extensions.DependencyInjection;
using TestTaskDeeplay_C.DAL.Entityes;
using TestTaskDeeplay_C.Interfaces;

namespace TestTaskDeeplay_C.DAL
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoryesInDB(this IServiceCollection services) => services
            .AddTransient<IRepository<Departament>, DbRepository<Departament>>()
            .AddTransient<IRepository<Gender>, DbRepository<Gender>>()
            .AddTransient<IRepository<Position>, DbRepository<Position>>()
            .AddTransient<IRepository<Person>, PeopleRepository>();
    }
}
