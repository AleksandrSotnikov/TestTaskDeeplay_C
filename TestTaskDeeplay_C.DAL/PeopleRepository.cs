using Microsoft.EntityFrameworkCore;
using TestTaskDeeplay_C.DAL.Context;
using TestTaskDeeplay_C.DAL.Entityes;


namespace TestTaskDeeplay_C.DAL
{
    class PeopleRepository : DbRepository<Person>
    {
        public override IQueryable<Person> Items => base.Items.Include(item => item.Position).Include(item => item.Gender).Include(item => item.Departament);
        public PeopleRepository(TestTaskDB db) : base(db)
        {

        }
    }
}
