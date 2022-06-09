using MathCore.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskDeeplay_C.ViewModels
{
    internal class MainWIndowViewModel : ViewModel
    {
        #region Title: String - Заголовок

        private String _Title = "Главное окно программы";
        public String Title { get => _Title; set => Set(ref _Title, value); }

        #endregion
        
    }
}
