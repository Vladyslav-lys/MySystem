using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySystem.Service.Domain;
using MySystem.Client.Contract;

namespace MySystem.UI.Contract
{
    public interface IViewModelFactory
    {
        ILoginViewModel CreateLoginPageViewModel();
        IMainViewModel CreateMainPageViewModel(UserDTO userDTO, IMainClient mainClient);
        IDataViewModel CreateDataPageViewModel(IMainClient mainClient, AccountDTO accountDTO, UserDTO userDTO, int id);
    }
}
