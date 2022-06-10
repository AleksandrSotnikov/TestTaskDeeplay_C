using TestTaskDeeplay_C.DAL.Entityes.Base;

namespace TestTaskDeeplay_C.DAL.Entityes
{
    public class Departament : NamedEntity
    {
        public ICollection<Person> person { get; set; } = new HashSet<Person>();
        public override string ToString() => $"{Name}";
    }
}
