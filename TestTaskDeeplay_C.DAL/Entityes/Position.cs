using TestTaskDeeplay_C.DAL.Entityes.Base;

namespace TestTaskDeeplay_C.DAL.Entityes
{
    public abstract class Position : NamedEntity
    {
        public virtual ICollection<Person> People { get; set; }
    }
}
