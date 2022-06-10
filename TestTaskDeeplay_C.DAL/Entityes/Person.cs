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

        public override string ToString()
        {
            var Name = base.ToString();
            var Standart = $"ФИО: {SureName} {Name} {Patronymic}\nДата рождения: {DateOfBirth.ToString("dd.MM.yyyy")}\nПол: {Gender.Name}\nДолжность: {Position.Name}";
            var p = Departament.person.FirstOrDefault(n => n.Position.Id == 3) ?? new Person();
            switch (Position.Id)
            {
                case 2:
                    return $"{Standart}";
                case 3:
                    return $"{Standart}\nПодразделение: {Departament.Name}";
                case 4:
                    return $"{Standart}\nРуководитель: {p.SureName} {p.Name} {p.Patronymic}";
                case 5:
                    return $"{Standart}\nРуководитель: {p.SureName} {p.Name} {p.Patronymic}";
                default:
                    return $"{Standart}";
            }
        }
    }
}
