using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySystem.UI.Contract
{
    public interface IDataViewModel
    {
        void ShowNotes();
        void AddNotes();
        void EditNotes();
        void Browse();
        void ExitNotes();
        IViewData ViewData { get; set; }
    }
}
