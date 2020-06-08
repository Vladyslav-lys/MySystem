using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySystem.Service.Domain;
using System.Windows;

namespace MySystem.UI.Contract
{
    public interface IViewMain
    {
        string LastName { get; set; }
        string FirstName { get; set; }
        string SecondName { get; set; }
        Image Photo { get; set; }
        string ErrorLastName { get; set; }
        string ErrorFirstName { get; set; }
        string ErrorSecondName { get; set; }
        Visibility NotesGridVisibility { get; set; }
        Visibility AccountGridVisibility { get; set; }
        ListView ListNotes { get; set; }
        void ShowError(string error);
        void ShowMsh(string msg);
        void ClearError(string error);
    }
}
