using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskDeeplay_C.DAL.Context;
using TestTaskDeeplay_C.DAL.Entityes;

namespace TestTaskDeeplay_C.Data
{
    class DbInitializer
    {
        private readonly TestTaskDB _db;
        private readonly ILogger<DbInitializer> _Logger;

        public DbInitializer(TestTaskDB db, ILogger<DbInitializer> Logger)
        {
            _db = db;
            _Logger = Logger;

        }

        public async Task InitializeAsync()
        {

            await _db.Database.EnsureDeletedAsync().ConfigureAwait(false);

            await _db.Database.MigrateAsync().ConfigureAwait(false);

            if (await _db.Persons.AnyAsync()) return;
            await InitializeDepartaments();
            await InitializeGenders();
            await InitializePositions();
            await InitializePeople();
        }

        private List<Departament> _Departaments;
        private async Task InitializeDepartaments()
        {
            _Departaments = new List<Departament>();
            _Departaments.Add(new Departament { Name = "Администрация" });
            _Departaments.Add(new Departament { Name = "Канцелярия" });
            _Departaments.Add(new Departament { Name = "Отдел кадров" });
            _Departaments.Add(new Departament { Name = "Бухгалтерия" });
            _Departaments.Add(new Departament { Name = "Архив" });
            _Departaments.Add(new Departament { Name = "Производство" });
            _Departaments.Add(new Departament { Name = "Столовая" });
            _Departaments.Add(new Departament { Name = "Производство" });
            await _db.Departaments.AddRangeAsync(_Departaments);
            await _db.SaveChangesAsync();
        }

        private List<Gender> _Genders;
        private async Task InitializeGenders()
        {
            _Genders = new List<Gender>();
            _Genders.Add(new Gender { Name = "Мужчина"});
            _Genders.Add(new Gender { Name = "Женщина"});
            await _db.Genders.AddRangeAsync(_Genders);
            await _db.SaveChangesAsync();
        }

        private List<Position> _Positions;
        private async Task InitializePositions()
        {
            _Positions = new List<Position>();
            _Positions.Add(new Position { Name = "Директор" });
            _Positions.Add(new Position { Name = "Руководитель подразделения" });
            _Positions.Add(new Position { Name = "Контролер" });
            _Positions.Add(new Position { Name = "Рабочий" });
            
            await _db.Positions.AddRangeAsync(_Positions);
            await _db.SaveChangesAsync();
        }

        private List<Person> _People;
        private async Task InitializePeople()
        {
            Random random = new Random();
            _People = new List<Person>();
           
            _People.Add(new Person { Name = "Денис",SureName = "Цветков", Patronymic = "Васильевич",DateOfBirth = random.GenRandomDateTime(), Gender = _db.Genders.First(n => n.Name == _Genders[0].Name), Position = _db.Positions.First(n=> n.Name == _Positions[0].Name), Departament = _db.Departaments.First(n => n.Name == _Departaments[0].Name) });

            _People.Add(new Person { Name = "Варвара", SureName = "Маркова", Patronymic = "Евгеньевна", DateOfBirth = random.GenRandomDateTime(), Gender = _db.Genders.First(n=> n.Name == _Genders[1].Name) , Position = _db.Positions.First(n => n.Name == _Positions[1].Name), Departament = _db.Departaments.First(n=> n.Name == _Departaments[0].Name) });
            _People.Add(new Person { Name = "Николай", SureName = "Ананьев", Patronymic = "Максимович", DateOfBirth = random.GenRandomDateTime(), Gender = _db.Genders.First(n => n.Name == _Genders[0].Name), Position = _db.Positions.First(n => n.Name == _Positions[1].Name), Departament = _db.Departaments.First(n=> n.Name == _Departaments[1].Name) });
            _People.Add(new Person { Name = "Илья", SureName = "Комисаров", Patronymic = "Владимирович", DateOfBirth = random.GenRandomDateTime(), Gender =  _db.Genders.First(n => n.Name == _Genders[0].Name), Position = _db.Positions.First(n => n.Name == _Positions[1].Name), Departament = _db.Departaments.First(n=> n.Name == _Departaments[2].Name) });
            _People.Add(new Person { Name = "Василиса", SureName = "Авдеева", Patronymic = "Михайловна", DateOfBirth = random.GenRandomDateTime(), Gender = _db.Genders.First(n => n.Name == _Genders[1].Name), Position = _db.Positions.First(n => n.Name == _Positions[1].Name), Departament = _db.Departaments.First(n=> n.Name == _Departaments[3].Name) });
            _People.Add(new Person { Name = "Захар", SureName = "Мальцев", Patronymic = "Давидович", DateOfBirth = random.GenRandomDateTime(), Gender =  _db.Genders.First(n => n.Name == _Genders[0].Name), Position = _db.Positions.First(n => n.Name == _Positions[1].Name), Departament = _db.Departaments.First(n=> n.Name == _Departaments[4].Name) });
            _People.Add(new Person { Name = "Александр", SureName = "Токарев", Patronymic = "Кириллович", DateOfBirth = random.GenRandomDateTime(), Gender =  _db.Genders.First(n => n.Name == _Genders[0].Name), Position = _db.Positions.First(n => n.Name == _Positions[1].Name), Departament = _db.Departaments.First(n=> n.Name == _Departaments[5].Name) });
            _People.Add(new Person { Name = "Егор", SureName = "Новиков", Patronymic = "Дамирович", DateOfBirth = random.GenRandomDateTime(), Gender =  _db.Genders.First(n => n.Name == _Genders[0].Name), Position = _db.Positions.First(n => n.Name == _Positions[1].Name), Departament = _db.Departaments.First(n=> n.Name == _Departaments[6].Name) });
            _People.Add(new Person { Name = "Ксения", SureName = "Селиванова", Patronymic = "Александровна", DateOfBirth = random.GenRandomDateTime(), Gender = _db.Genders.First(n => n.Name == _Genders[1].Name), Position = _db.Positions.First(n => n.Name == _Positions[1].Name), Departament = _db.Departaments.First(n=> n.Name == _Departaments[7].Name) });

            _People.Add(new Person { Name = "Игорь", SureName = "Кудрешев", Patronymic = "Фёдорович", DateOfBirth = random.GenRandomDateTime(), Gender =  _db.Genders.First(n => n.Name == _Genders[0].Name), Position = _db.Positions.First(n => n.Name == _Positions[2].Name), Departament = _db.Departaments.First(n=> n.Name == _Departaments[0].Name) });
            _People.Add(new Person { Name = "Ярослава", SureName = "Шубина", Patronymic = "Артёмовна", DateOfBirth = random.GenRandomDateTime(), Gender = _db.Genders.First(n => n.Name == _Genders[1].Name), Position = _db.Positions.First(n => n.Name == _Positions[2].Name), Departament = _db.Departaments.First(n=> n.Name == _Departaments[1].Name) });
            _People.Add(new Person { Name = "Дмитрий", SureName = "Воробьев", Patronymic = "Фёдорович", DateOfBirth = random.GenRandomDateTime(), Gender =  _db.Genders.First(n => n.Name == _Genders[0].Name), Position = _db.Positions.First(n => n.Name == _Positions[2].Name), Departament = _db.Departaments.First(n=> n.Name == _Departaments[2].Name) });
            _People.Add(new Person { Name = "Никита", SureName = "Михайлов", Patronymic = "Романович", DateOfBirth = random.GenRandomDateTime(), Gender =  _db.Genders.First(n => n.Name == _Genders[0].Name), Position = _db.Positions.First(n => n.Name == _Positions[2].Name), Departament = _db.Departaments.First(n=> n.Name == _Departaments[3].Name) });
            _People.Add(new Person { Name = "Ульяна", SureName = "Сергеева", Patronymic = "Никитична", DateOfBirth = random.GenRandomDateTime(), Gender = _db.Genders.First(n => n.Name == _Genders[1].Name), Position = _db.Positions.First(n => n.Name == _Positions[2].Name), Departament = _db.Departaments.First(n=> n.Name == _Departaments[4].Name) });
            _People.Add(new Person { Name = "Григорий", SureName = "Попов", Patronymic = "Тимофеевич", DateOfBirth = random.GenRandomDateTime(), Gender =  _db.Genders.First(n => n.Name == _Genders[0].Name), Position = _db.Positions.First(n => n.Name == _Positions[2].Name), Departament = _db.Departaments.First(n=> n.Name == _Departaments[5].Name) });
            _People.Add(new Person { Name = "Илья", SureName = "Попов", Patronymic = "Артемович", DateOfBirth = random.GenRandomDateTime(), Gender =  _db.Genders.First(n => n.Name == _Genders[0].Name), Position = _db.Positions.First(n => n.Name == _Positions[2].Name), Departament = _db.Departaments.First(n=> n.Name == _Departaments[6].Name) });
            _People.Add(new Person { Name = "Василиса", SureName = "Ульяновна", Patronymic = "Александровна", DateOfBirth = random.GenRandomDateTime(), Gender = _db.Genders.First(n => n.Name == _Genders[1].Name), Position = _db.Positions.First(n => n.Name == _Positions[2].Name), Departament = _db.Departaments.First(n=> n.Name == _Departaments[7].Name) });

            _People.Add(new Person { Name = "Павел", SureName = "Демьянов", Patronymic = "Андреевич", DateOfBirth = random.GenRandomDateTime(), Gender =  _db.Genders.First(n => n.Name == _Genders[0].Name), Position = _db.Positions.First(n => n.Name == _Positions[3].Name), Departament = _db.Departaments.First(n=> n.Name == _Departaments[0].Name) });
            _People.Add(new Person { Name = "Илья", SureName = "Петров", Patronymic = "Андреевич", DateOfBirth = random.GenRandomDateTime(), Gender =  _db.Genders.First(n => n.Name == _Genders[0].Name), Position = _db.Positions.First(n => n.Name == _Positions[3].Name), Departament = _db.Departaments.First(n=> n.Name == _Departaments[1].Name) });
            _People.Add(new Person { Name = "Яна", SureName = "Яковлева", Patronymic = "Ярославовна", DateOfBirth = random.GenRandomDateTime(), Gender = _db.Genders.First(n => n.Name == _Genders[1].Name), Position = _db.Positions.First(n => n.Name == _Positions[3].Name), Departament = _db.Departaments.First(n=> n.Name == _Departaments[2].Name) });
            _People.Add(new Person { Name = "Мирослава", SureName = "Шубин", Patronymic = "Святославович", DateOfBirth = random.GenRandomDateTime(), Gender =  _db.Genders.First(n => n.Name == _Genders[0].Name), Position = _db.Positions.First(n => n.Name == _Positions[3].Name), Departament = _db.Departaments.First(n=> n.Name == _Departaments[3].Name) });
            _People.Add(new Person { Name = "Елизавета", SureName = "Черкасова", Patronymic = "Владимировна", DateOfBirth = random.GenRandomDateTime(), Gender = _db.Genders.First(n => n.Name == _Genders[1].Name), Position = _db.Positions.First(n => n.Name == _Positions[3].Name), Departament = _db.Departaments.First(n=> n.Name == _Departaments[4].Name) });
            _People.Add(new Person { Name = "Глеб", SureName = "Никитин", Patronymic = "Кириллович", DateOfBirth = random.GenRandomDateTime(), Gender =  _db.Genders.First(n => n.Name == _Genders[0].Name), Position = _db.Positions.First(n => n.Name == _Positions[3].Name), Departament = _db.Departaments.First(n=> n.Name == _Departaments[5].Name) });
            _People.Add(new Person { Name = "Владимир", SureName = "Григорьев", Patronymic = "Максимович", DateOfBirth = random.GenRandomDateTime(), Gender =  _db.Genders.First(n => n.Name == _Genders[0].Name), Position = _db.Positions.First(n => n.Name == _Positions[3].Name), Departament = _db.Departaments.First(n=> n.Name == _Departaments[6].Name) });
            _People.Add(new Person { Name = "Глеб", SureName = "Дмитриевич", Patronymic = "Алексеев", DateOfBirth = random.GenRandomDateTime(), Gender =  _db.Genders.First(n => n.Name == _Genders[0].Name), Position = _db.Positions.First(n => n.Name == _Positions[3].Name), Departament = _db.Departaments.First(n=> n.Name == _Departaments[7].Name) });

            await _db.Persons.AddRangeAsync(_People);
            await _db.SaveChangesAsync();
        }

    }
}
