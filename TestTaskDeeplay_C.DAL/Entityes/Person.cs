using TestTaskDeeplay_C.DAL.Entityes.Base;

namespace TestTaskDeeplay_C.DAL.Entityes
{
    public class Person : NamedEntity
    {
        public string SureName { get; set; }

        public string Patronymic { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public Position Position { get; set; }
   
        public Departament Departament { get; set; } 
    }
}
