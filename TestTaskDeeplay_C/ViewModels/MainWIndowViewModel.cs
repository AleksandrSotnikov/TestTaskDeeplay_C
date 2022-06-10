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
        private readonly IRepository<Departament> _DepartamentRepo;
        
        #region Title: String - Заголовок

        private String _Title = "Главное окно программы";
        public String Title { get => _Title; set => Set(ref _Title, value); }

        #endregion

        #region CurrentModel: ViewModel - Модель представления

        private ViewModel _CurrentModel;
        public ViewModel CurrentModel { get => _CurrentModel; set => Set(ref _CurrentModel, value); }

        #endregion

        #region ICommand: _ShowDepartamentViewCommand - Модель представления

        private ICommand _ShowDepartamentViewCommand;
        public ICommand ShowDepartamentViewCommand => _ShowDepartamentViewCommand
            ??= new LambdaCommand(OnShowDepartamentViewCommandExecuted, CanShowDepartamentViewCommandExecute);

        private bool CanShowDepartamentViewCommandExecute() => true;

        private void OnShowDepartamentViewCommandExecuted() {
            CurrentModel = new DepartamentViewModel(_DepartamentRepo);
        }

        #endregion

        #region ICommand: _ShowPersonViewCommand - Модель представления

        private ICommand _ShowPersonViewCommand;
        public ICommand ShowPersonViewCommand => _ShowPersonViewCommand
            ??= new LambdaCommand(OnShowPersonViewCommandExecuted, CanShowPersonViewCommandExecute);

        private bool CanShowPersonViewCommandExecute() => true;

        private void OnShowPersonViewCommandExecuted() {
            CurrentModel = new PersonViewModel(_PersonRepo);
        }

        #endregion
        //public MainWindowViewModel(IRepository<Person> repository)
        //{
        //    _PersonRepo = repository;
        //    var person = _PersonRepo.Items.Take(10).ToArray();
        //}

    }
}
