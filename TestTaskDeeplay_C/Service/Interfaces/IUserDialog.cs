using System;
using TestTaskDeeplay_C.DAL.Entityes;
using TestTaskDeeplay_C.Interfaces;

namespace TestTaskDeeplay_C.Service.Interfaces
{
    internal interface IUserDialog
    {
        bool Edit(Person person, IRepository<Departament> DepartamentRepository, IRepository<Gender> GenderRepository, IRepository<Position> PositionRepository);
        bool ConfirmInformation(String Info, String Caption);
        bool ConfirmWarning(String Info, String Caption);
        bool ConfirmError(String Info, String Caption);
    }
}
