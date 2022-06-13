using Microsoft.EntityFrameworkCore;
using TestTaskDeeplay_C.DAL.Entityes;


namespace TestTaskDeeplay_C.DAL.Context
{
    public class TestTaskDB : DbContext
    {
        #region Инициализация таблиц БД
        public DbSet<Departament> Departaments { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Person> Persons { get; set; }
        #endregion    
        public TestTaskDB(DbContextOptions<TestTaskDB> options) : base(options) { }
    }
}
