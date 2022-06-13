using System.Windows;
using TestTaskDeeplay_C.DAL.Entityes;
using TestTaskDeeplay_C.Service.Interfaces;
using TestTaskDeeplay_C.ViewModels;
using TestTaskDeeplay_C.Views.Windows;

namespace TestTaskDeeplay_C.Service
{
    internal class UserDialogService : IUserDialog
    {
        #region Оповещения
        public bool ConfirmError(string Info, string Caption)
        {
            return MessageBox.Show(Info,
               Caption,
               MessageBoxButton.YesNo,
               MessageBoxImage.Error
               ) == MessageBoxResult.Yes;
        }

        public bool ConfirmInformation(string Info, string Caption)
        {
            return MessageBox.Show(Info,
                Caption,
                MessageBoxButton.OK,
                MessageBoxImage.Information
                ) == MessageBoxResult.OK;
        }

        public bool ConfirmWarning(string Info, string Caption)
        {
            return MessageBox.Show(Info,
               Caption,
               MessageBoxButton.YesNo,
               MessageBoxImage.Warning
               ) == MessageBoxResult.Yes;
        }
        #endregion

        #region Edit
        public bool Edit(Person person, TestTaskDeeplay_C.Interfaces.IRepository<Departament> DepartamentRepository, TestTaskDeeplay_C.Interfaces.IRepository<Gender> GenderRepository, TestTaskDeeplay_C.Interfaces.IRepository<Position> PositionRepository)
        {
            var editor = new PersonEditorViewModel(person, DepartamentRepository, GenderRepository, PositionRepository);
            var window = new PersonEditor
            {
                DataContext = editor
            };
            if (window.ShowDialog() != true) return false;
            person.Name = editor.Name ?? "Имя";
            person.SureName = editor.SureName ?? "Фамилия";
            person.Patronymic = editor.Patronymic ?? "Отчество";
            person.Gender = editor.Gender;
            person.DateOfBirth = editor.DateOfBirth;
            person.Departament = editor.Departament;
            person.Position = editor.Position;

            return true;
        }
        #endregion
    }
}
