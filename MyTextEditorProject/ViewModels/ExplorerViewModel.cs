using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace MyTextEditorProject.ViewModels
{
    internal class ExplorerViewModel
    {

        #region Properties

        public ObservableCollection<string> directories { get; set; } = new ObservableCollection<string>();

        #endregion

        #region Commands

        #endregion

        public ExplorerViewModel()
        {
            foreach (var disk in Directory.GetLogicalDrives())
                directories.Add(disk);
        }
    }
}
