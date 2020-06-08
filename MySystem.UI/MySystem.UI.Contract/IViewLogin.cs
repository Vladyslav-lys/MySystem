using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySystem.UI.Contract
{
    public interface IViewLogin
    {
        string Login { get; }
        string Password { get; }
        string ErrorLogin { get; set; }
        string ErrorPassword { get; set; }

        void ShowError(string error);
        void ClearError(string error);
    }
}
