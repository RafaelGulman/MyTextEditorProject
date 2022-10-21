using MyTextEditorProject.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextEditorProject.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        #region Properties

        public string Title { get; set; } = "MyTextEditorProject";

        public string Header { get; set; } = "unnamed";

        public string Text { get; set; } = "Введите ваш текст";
        
        #endregion

        #region Commands

        #endregion

        public MainWindowViewModel()
        {
        }
    }
}
