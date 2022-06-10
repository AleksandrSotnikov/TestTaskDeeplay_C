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
    class PersonViewModel : ViewModel
    {
        private readonly IRepository<Person> _PersonRepository;
        public PersonViewModel(IRepository<Person> PersonRepository)
        {
            _PersonRepository = PersonRepository;
        }
    }
}
