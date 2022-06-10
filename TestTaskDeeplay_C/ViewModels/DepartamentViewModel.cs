using MathCore.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskDeeplay_C.DAL.Entityes;
using TestTaskDeeplay_C.Interfaces;

namespace TestTaskDeeplay_C.ViewModels
{
    class DepartamentViewModel : ViewModel
    {
        private readonly IRepository<Departament> _DepartamentRepository;
        public DepartamentViewModel(IRepository<Departament> DepartamentRepository)
        {
            _DepartamentRepository = DepartamentRepository;
        }
    }
}
