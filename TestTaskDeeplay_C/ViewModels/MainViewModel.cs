using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using TestTaskDeeplay_C.DAL.Entityes;
using TestTaskDeeplay_C.Interfaces;

namespace TestTaskDeeplay_C.ViewModels
{
    class MainViewModel : ViewModel
    {
        private readonly IRepository<Departament> _DepartamentRepository;
        private readonly IRepository<Person> _PersonRepository;
        private readonly IRepository<Position> _PositionRepository;

        private CollectionViewSource _DepartamentsViewSource;
        private CollectionViewSource _PersonViewSource;
        private CollectionViewSource _PositionViewSource;

        private ObservableCollection<String> DepartamentChecked = new ObservableCollection<String>();
        private ObservableCollection<String> PositionChecked = new ObservableCollection<String>();

        public ICollectionView DepartamentsView => _DepartamentsViewSource.View;
        public ICollectionView PersonView=> _PersonViewSource.View;
        public ICollectionView PositionView => _PositionViewSource.View;
        //public IEnumerable<Departament> Departaments => _DepartamentRepository.Items;    


        #region SelectedDepartament : Departament - Выбранный Департамент

        private Departament _SelectedDepartament;

        public Departament SelectedDepartament { get => _SelectedDepartament; set => Set(ref _SelectedDepartament, value); }

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
        }
        #endregion

        public MainViewModel(IRepository<Departament> DepartamentRepository, IRepository<Person> PersonRepository, IRepository<Position> PositionRepository)
        {
            _DepartamentRepository = DepartamentRepository;
            _PersonRepository = PersonRepository;
            _PositionRepository = PositionRepository;

            _DepartamentsViewSource = new CollectionViewSource
            {
                Source = _DepartamentRepository.Items.ToList(),
                SortDescriptions =
                {
                    new SortDescription(nameof(Departament.Name),ListSortDirection.Ascending)
                }
            };

            _PositionViewSource = new CollectionViewSource
            {
                Source = _PositionRepository.Items.ToList(),
                SortDescriptions =
                {
                    new SortDescription(nameof(Position.Name),ListSortDirection.Ascending)
                }
            };
        }
    }
}
