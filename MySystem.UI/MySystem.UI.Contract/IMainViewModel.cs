using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySystem.Service.Domain;

namespace MySystem.UI.Contract
{
    public interface IMainViewModel
    {
        void ShowAccount();
        void ShowNotes();
        void ShowData(int idNote);
        void EditAccount();
        void Browse();
        IViewMain ViewMain { get; set; }
    }
}
