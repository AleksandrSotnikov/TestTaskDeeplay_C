using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using System;
using System.Windows.Input;
using TestTaskDeeplay_C.DAL.Entityes;
using TestTaskDeeplay_C.Interfaces;
using TestTaskDeeplay_C.Service.Interfaces;

namespace TestTaskDeeplay_C.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Dialog
        private readonly IUserDialog _UserDialog;
        #endregion

        #region Repository
        private readonly IRepository<Person> _PersonRepo;
        private readonly IRepository<Position> _PositionRepo;
        private readonly IRepository<Gender> _GenderRepo;
        private readonly IRepository<Departament> _DepartamentRepo;
        #endregion

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

        private void OnShowMainViewCommandExecuted()
        {
            CurrentModel = new MainViewModel(_DepartamentRepo, _PersonRepo, _PositionRepo, _GenderRepo, _UserDialog);
        }

        #endregion

        #region Constructor
        public MainWindowViewModel(IRepository<Person> person, IRepository<Departament> departament, IRepository<Position> positionRepo, IRepository<Gender> genderRepo, IUserDialog userDialog)
        {
            _UserDialog = userDialog;
            _PersonRepo = person;
            _DepartamentRepo = departament;
            _PositionRepo = positionRepo;
            _GenderRepo = genderRepo;
        }
        #endregion
    }
}
