using TestTaskDeeplay_C.DAL.Entityes.Base;

namespace TestTaskDeeplay_C.DAL.Entityes
{
    public abstract class Person : NamedEntity
    {
        public string SureName { get; set; }

        public string Patronymic { get; set; }

        public DateTime DateTime { get; set; }

        public Gender Gender { get; set; }

        public Position Position { get; set; }

        public Departament Departament { get; set; }
    }
}
