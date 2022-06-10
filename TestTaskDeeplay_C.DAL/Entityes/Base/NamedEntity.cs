using System.ComponentModel.DataAnnotations;

namespace TestTaskDeeplay_C.DAL.Entityes.Base
{
    public abstract class NamedEntity : Entity
    {
        [Required]
        public string Name { get;set; }

        public override string ToString() =>$"{Name}";


    }
}
