using TestTaskDeeplay_C.DAL.Entityes.Base;

namespace TestTaskDeeplay_C.DAL.Entityes
{
    public class Person : NamedEntity
    {
        public string SureName { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Position Position { get; set; }   
        public virtual Departament Departament { get; set; } 

         
    }
}
