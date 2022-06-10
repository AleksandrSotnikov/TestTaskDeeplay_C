using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestTaskDeeplay_C.DAL.Entityes;
using TestTaskDeeplay_C.Interfaces;

namespace TestTaskDeeplay_C.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private readonly IRepository<Person> _PersonRepo;
        private readonly IRepository<Position> _PositionRepo;
        private readonly IRepository<Departament> _DepartamentRepo;
        
        #region Title: String - Заголовок

        private String _Title = "Главное окно программы";
        public String Title { get => _Title; set => Set(ref _Title, value); }

        #endregion

        #region CurrentModel: ViewModel - Модель представления

        private ViewModel _CurrentModel;
        public ViewModel CurrentModel { get => _CurrentModel; set => Set(ref _CurrentModel, value); }

        #endregion

        #region ICommand: _ShowMainViewCommand - Модель представления

        private ICommand _ShowMainViewCommand;
        public ICommand ShowMainViewCommand => _ShowMainViewCommand
            ??= new LambdaCommand(OnShowMainViewCommandExecuted, CanShowMainViewCommandExecute);

        private bool CanShowMainViewCommandExecute() => true;

        private void OnShowMainViewCommandExecuted() {
            CurrentModel = new MainViewModel(_DepartamentRepo,_PersonRepo,_PositionRepo);
        }

        #endregion

        public MainWindowViewModel(IRepository<Person> person,IRepository<Departament> departament, IRepository<Position> positionRepo)
        {
            _PersonRepo = person;
            _DepartamentRepo = departament;
            _PositionRepo = positionRepo;
        }

    }
}
