using TestTaskDeeplay_C.Interfaces;

namespace TestTaskDeeplay_C.DAL.Entityes.Base
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
