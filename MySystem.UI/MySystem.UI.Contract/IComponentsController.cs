using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySystem.Service.Domain;
using MySystem.Client.Contract;

namespace MySystem.UI.Contract
{
    public interface IComponentsController
    {
        void LoadMain(UserDTO userDTO, IMainClient mainClient);
        void LoadLogin();
        void LoadData(int id, UserDTO userDTO, AccountDTO accountDTO, IMainClient mainClient);
        void SetView(IViewFactory viewCreator);
    }
}
