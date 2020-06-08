using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySystem.UI.Contract
{
    public interface ILoginViewModel
    {
        void Enter();
        void Exit();
        IViewLogin ViewLogin { get; set; }
    }
}
