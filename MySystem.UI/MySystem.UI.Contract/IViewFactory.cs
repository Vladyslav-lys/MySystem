using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySystem.Service.Domain;
using MySystem.Client.Contract;

namespace MySystem.UI.Contract
{
    public interface IViewFactory
    {
        IViewLogin CreateLoginPageView();
        IViewMain CreateMainPageView(UserDTO userDTO, IMainClient mainClient);
        IViewData CreateDataPageView(int id, UserDTO userDTO, AccountDTO accountDTO, IMainClient mainClient);
    }
}
