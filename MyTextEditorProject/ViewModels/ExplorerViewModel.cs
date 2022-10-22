using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows.Input;
using MyTextEditorProject.Infrastructure.Commands;

namespace MyTextEditorProject.ViewModels
{
    internal class ExplorerViewModel
    {

        #region Properties

        public ObservableCollection<string> Directories { get; set; } = new ObservableCollection<string>();

        public string SelectedDirectory { get; set; }

        #endregion

        #region Commands

        #region OpenDirectory

        public ICommand OpenDirectory { get; }

        protected bool CanOpenDirectoryExecute(object parameter) => true;

        protected void OnOpenDirectoryExecute(object parameter)
        {
            string path = SelectedDirectory;

            Directories.Clear();

            foreach(var directory in Directory.GetDirectories(path))
            {
                Directories.Add(directory);
            }
        }

        #endregion

        #endregion

        public ExplorerViewModel()
        {
            OpenDirectory = new LambdaCommand(OnOpenDirectoryExecute, CanOpenDirectoryExecute);

            foreach (var disk in Directory.GetLogicalDrives())
                Directories.Add(disk);
        }
    }
}
