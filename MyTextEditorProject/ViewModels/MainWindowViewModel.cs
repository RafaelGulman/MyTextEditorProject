using MyTextEditorProject.Infrastructure.Commands;
using MyTextEditorProject.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using System.IO;

namespace MyTextEditorProject.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private string title = "MyTextEditorProject";
        private string header = "unnamed";
        private string text = "Введите ваш текст";

        #region Properties

        public string Title 
        {
            get => title;

            set => Set(ref title, value);
        }

        public string Header
        {
            get => header;

            set => Set(ref header, value);
        }

        public string Text
        {
            get => text;

            set => Set(ref text, value);
        }

        #endregion

        #region Commands

        #region SaveCommand

        public ICommand SaveCommand { get; }

        protected bool CanSaveCommandExecuted(object p) => true;

        protected void OnSaveCommandExecute(object p)
        {
            if(Text == string.Empty || Header == string.Empty)
            {
                MessageBox.Show("Строка или заголовок - пустые.", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (StreamWriter sw = File.CreateText(Directory.GetCurrentDirectory() + $"/{Header}.txt"))
            {
                sw.Write(Text);
            }
        }

        #endregion

        #endregion

        public MainWindowViewModel()
        {
            SaveCommand = new LambdaCommand(OnSaveCommandExecute, CanSaveCommandExecuted);

        }
    }
}
