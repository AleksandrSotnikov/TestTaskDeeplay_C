using MathCore.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTaskDeeplay_C.DAL.Entityes;
using TestTaskDeeplay_C.Interfaces;

namespace TestTaskDeeplay_C.ViewModels
{
    internal class PersonEditorViewModel : ViewModel
    {
        #region Repository
        private readonly IRepository<Departament> _DepartamentRepository;
        private readonly IRepository<Gender> _GenderRepository;
        private readonly IRepository<Position> _PositionRepository;
        #endregion

        #region IEnumerable
        public IEnumerable<Gender> Genders => _GenderRepository.Items.ToList();
        public IEnumerable<Departament> Departaments => _DepartamentRepository.Items.Where(n => n.Id != 1).ToList();
        public IEnumerable<Position> Positions => _PositionRepository.Items.Where(n => n.Id != 1).ToList();
        #endregion

        #region PersonId : int - Идентификатор 

        public int PersonId { get; }

        #endregion

        #region Name : string - Имя
        private string _Name;
        public string Name { get => _Name; set => Set(ref _Name, value); }
        #endregion

        #region SureName : string - Фамилия
        private string _SureName;
        public string SureName { get => _SureName; set => Set(ref _SureName, value); }
        #endregion

        #region Patronymic : string - Отчество
        private string _Patronymic;
        public string Patronymic { get => _Patronymic; set => Set(ref _Patronymic, value); }
        #endregion

        #region DateOfBirth : DateTime - ДатаРождения
        private DateTime _DateOfBirth;
        public DateTime DateOfBirth { get => _DateOfBirth; set => Set(ref _DateOfBirth, value); }
        #endregion

        #region Departament : Departament - Подразделение
        private Departament _Departament;
        public Departament Departament { get => _Departament; set => Set(ref _Departament, value); }
        #endregion

        #region Position : Position - Должность
        private Position _Position;
        public Position Position { get => _Position; set => Set(ref _Position, value); }
        #endregion

        #region Gender : Gender - Пол
        private Gender _Gender;
        public Gender Gender { get => _Gender; set => Set(ref _Gender, value); }
        #endregion

        #region Constructor
        public PersonEditorViewModel(Person person, IRepository<Departament> DepartamentRepository, IRepository<Gender> GenderRepository, IRepository<Position> PositionRepository)
        {
            PersonId = person.Id;
            Name = person.Name;
            SureName = person.SureName;
            Patronymic = person.Patronymic;
            DateOfBirth = (person.DateOfBirth.Year == 1) ? DateTime.Today : person.DateOfBirth;
            Departament = person.Departament;
            Position = person.Position;
            Gender = person.Gender;
            _DepartamentRepository = DepartamentRepository;
            _PositionRepository = PositionRepository;
            _GenderRepository = GenderRepository;
            Departament ??= Departaments.First(n => n.Id == 2);
            Gender ??= Genders.First(n => n.Id == 1);
            Position ??= Positions.First(n => n.Id == 2);
        }
        #endregion
    }
}
