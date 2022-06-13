using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using TestTaskDeeplay_C.DAL.Entityes;
using TestTaskDeeplay_C.Interfaces;
using TestTaskDeeplay_C.Service.Interfaces;

namespace TestTaskDeeplay_C.ViewModels
{
    class MainViewModel : ViewModel
    {
        #region Repository
        private readonly IRepository<Departament> _DepartamentRepository;
        private readonly IRepository<Person> _PersonRepository;
        private readonly IRepository<Position> _PositionRepository;
        private readonly IRepository<Gender> _GenderRepo;
        #endregion

        #region Services
        private readonly IUserDialog _UserDialog;

        #endregion

        #region CollectionViewSource
        private CollectionViewSource _DepartamentsViewSource;
        private CollectionViewSource _PersonViewSource;
        private CollectionViewSource _PositionViewSource;
        #endregion

        #region ObservableCollection
        private ObservableCollection<String> DepartamentChecked = new ObservableCollection<String>();
        private ObservableCollection<String> PositionChecked = new ObservableCollection<String>();
        #region Persons : ObservableCollection<Person> - Коллекция 

        private ObservableCollection<Person> _Persons;

        public ObservableCollection<Person> Persons
        {
            get => _Persons;
            set
            {
                if (Set(ref _Persons, value))
                {
                    _PersonViewSource = new CollectionViewSource
                    {
                        Source = value,
                        SortDescriptions =
                        {
                            new SortDescription(nameof(Person.Name), ListSortDirection.Ascending)
                        }
                    };

                    _PersonViewSource.Filter += OnPersonFilter;
                    _PersonViewSource.View.Refresh();

                    OnPropertyChanged(nameof(PersonView));
                }
            }
        }

        #endregion
        #endregion

        #region ICollectionView
        public ICollectionView DepartamentsView => _DepartamentsViewSource.View;
        public ICollectionView PersonView => _PersonViewSource?.View;
        public ICollectionView PositionView => _PositionViewSource.View;
        #endregion

        #region Command AddNewPerson
        private ICommand _AddNewPerson;

        public ICommand AddNewPersonCommand => _AddNewPerson
            ??= new LambdaCommand<Person>(OnAddNewPersonCommandExecuted, CanAddNewPersonCommandExecute);
        private bool CanAddNewPersonCommandExecute(Person p) => true;
        private void OnAddNewPersonCommandExecuted(Person p)
        {
            var person = new Person();
            if (!_UserDialog.Edit(person, _DepartamentRepository, _GenderRepo, _PositionRepository)) return;
            _PersonRepository.Add(person);
            _Persons.Add(person);
            SelectedPerson = person;
            _UserDialog.ConfirmInformation($"Сотрудник {person.SureName} {person.Name} {person.Patronymic} успешно добавлен.",
                "Добавление сотрудника");
        }
        #endregion

        #region Command UpPerson
        private ICommand _UpPerson;

        public ICommand UpPersonCommand => _UpPerson
            ??= new LambdaCommand<Person>(OnUpPersonCommandExecuted, CanUpPersonCommandExecute);
        private bool CanUpPersonCommandExecute(Person p) => p != null || SelectedPerson != null;
        private void OnUpPersonCommandExecuted(Person p)
        {
            var person = p ?? SelectedPerson;
            if (!_UserDialog.ConfirmWarning($"Вы уверены что хотите повысить сотрудника {person.SureName} {person.Name} {person.Patronymic} ?",
                "Повышение сотрудника"))
                return;
            if (person.Position.Id > 2)
            {
                person.Position = _PositionRepository.Items.ToList().First(n => n.Id == person.Position.Id - 1);
                _PersonRepository.Update(person);
                _PersonViewSource.View.Refresh();
                SelectedPerson = person;
                _UserDialog.ConfirmInformation($"Сотрудник {person.SureName} {person.Name} {person.Patronymic} успешно обновлен.",
                    "Обновление сотрудника");
            }
            else
            {
                _UserDialog.ConfirmInformation($"Дальше повышать нельзя",
                    "Обновление сотрудника");
            }
        }
        #endregion

        #region Command UEditPerson
        private ICommand _EditPerson;

        public ICommand EditPersonCommand => _EditPerson
            ??= new LambdaCommand<Person>(OnEditPersonCommandExecuted, CanEditPersonCommandExecute);
        private bool CanEditPersonCommandExecute(Person p) => p != null || SelectedPerson != null;
        private void OnEditPersonCommandExecuted(Person p)
        {
            var person = p ?? SelectedPerson;
            if (!_UserDialog.Edit(person, _DepartamentRepository, _GenderRepo, _PositionRepository)) return;
            _PersonRepository.Update(person);
            _PersonViewSource.View.Refresh();
            SelectedPerson = person;
            _UserDialog.ConfirmInformation($"Сотрудник {person.SureName} {person.Name} {person.Patronymic} успешно обновлен.",
                "Обновление сотрудника");
        }
        #endregion

        #region Command RemovePerson
        private ICommand _RemovePerson;

        public ICommand RemovePersonCommand => _RemovePerson
            ??= new LambdaCommand<Person>(OnRemovePersonCommandExecuted, CanRemovePersonCommandExecute);
        private bool CanRemovePersonCommandExecute(Person p) => p != null || SelectedPerson != null;
        private void OnRemovePersonCommandExecuted(Person p)
        {
            var person = p ?? SelectedPerson;
            if (!_UserDialog.ConfirmWarning($"Вы уверены что хотите удалить сотрудника {person.SureName} {person.Name} {person.Patronymic} ?",
                "Удаление сотрудника"))
                return;
            _PersonRepository.Remove(person.Id);
            _Persons.Remove(person);
            SelectedPerson = null;

        }
        #endregion

        #region OnPersonFilter : Void - Фильтрация
        private void OnPersonFilter(object Sender, FilterEventArgs E)
        {
            if (E.Item is not Person person) return;
            if (!string.IsNullOrEmpty(PersonFilter))
            {
                if (!person.Name.Contains(PersonFilter) && !person.SureName.Contains(PersonFilter) && !person.Patronymic.Contains(PersonFilter))
                    E.Accepted = false;
            }
            if (SelectedPosition.IsNotNull() && !person.Position.Name.Contains(SelectedPosition!.Name) && SelectedPosition.Name != "Все")
                E.Accepted = false;
            if (SelectedDepartament.IsNotNull() && !person.Departament.Name.Contains(SelectedDepartament!.Name) && SelectedDepartament.Name != "Все")
                E.Accepted = false;
        }
        #endregion

        #region Command LoadDataCommand - Команда загрузки данных из репозитория
        private ICommand _LoadDataCommand;

        public ICommand LoadDataCommand => _LoadDataCommand
            ??= new LambdaCommandAsync(OnLoadDataCommandExecuted, CanLoadDataCommandExecute);

        private bool CanLoadDataCommandExecute() => true;

        private async Task OnLoadDataCommandExecuted()
        {
            Persons = new ObservableCollection<Person>(await _PersonRepository.Items.ToArrayAsync());
        }
        #endregion

        #region PersonFilter : string - Искомое слово  
        private string _PersonFilter;
        public string PersonFilter
        {
            get => _PersonFilter;
            set
            {
                if (Set(ref _PersonFilter, value))
                    _PersonViewSource.View.Refresh();
            }
        }
        #endregion

        #region SelectedDepartament : Departament - Выбранный Департамент

        private Departament _SelectedDepartament;

        public Departament SelectedDepartament { get => _SelectedDepartament; set => Set(ref _SelectedDepartament, value); }

        #endregion

        #region SelectedPerson : Person - Выбранный человек

        private Person _SelectedPerson;

        public Person SelectedPerson { get => _SelectedPerson; set => Set(ref _SelectedPerson, value); }

        #endregion

        #region Command CheckedDepartamentCommand : Departament - Фильтр
        private ICommand _CheckedDepartamentCommand;
        public ICommand CheckedDepartamentCommand => _CheckedDepartamentCommand
            ??= new LambdaCommand<Departament>(OnCheckedDepartamentCommandExecuted, CanCheckedDepartamentCommandExecute);
        private bool CanCheckedDepartamentCommandExecute(Departament p) => true;
        private void OnCheckedDepartamentCommandExecuted(Departament p)
        {
            DepartamentChecked.Clear();
            DepartamentChecked.Add(SelectedDepartament.ToString());
            _PersonViewSource.View.Refresh();
        }
        #endregion

        #region SelectedPosition : Position - Выбранная должность

        private Position _SelectedPosition;

        public Position SelectedPosition { get => _SelectedPosition; set => Set(ref _SelectedPosition, value); }

        #endregion

        #region Command CheckedPositionCommand : Position - Фильтр
        private ICommand _CheckedPositionCommand;
        public ICommand CheckedPositionCommand => _CheckedPositionCommand
            ??= new LambdaCommand<Position>(OnCheckedPositionCommandExecuted, CanCheckedPositionCommandExecute);
        private bool CanCheckedPositionCommandExecute(Position p) => true;
        private void OnCheckedPositionCommandExecuted(Position p)
        {
            PositionChecked.Clear();
            PositionChecked.Add(SelectedPosition.ToString());
            _PersonViewSource.View.Refresh();
        }
        #endregion

        #region Constructor
        public MainViewModel(IRepository<Departament> DepartamentRepository, IRepository<Person> PersonRepository, IRepository<Position> PositionRepository, IRepository<Gender> GenderRepository, IUserDialog UserDialog)
        {
            _DepartamentRepository = DepartamentRepository;
            _PersonRepository = PersonRepository;
            _PositionRepository = PositionRepository;
            _UserDialog = UserDialog;
            _GenderRepo = GenderRepository;
            _DepartamentsViewSource = new CollectionViewSource
            {
                Source = _DepartamentRepository.Items.ToList(),
            };
            _PositionViewSource = new CollectionViewSource
            {
                Source = _PositionRepository.Items.ToList(),
            };

            //_PersonViewSource = new CollectionViewSource
            //{
            //    Source = _PersonRepository.Items.ToList(),
            //    SortDescriptions =
            //    {
            //        new SortDescription(nameof(Person.Position.Name),ListSortDirection.Ascending)
            //    }
            //};
            //_PersonViewSource.Filter += OnPersonFilter;
        }
        #endregion
    }
}
