using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySystem.UI.Contract;
using MySystem.Service.Domain;
using MySystem.Client.Contract;

namespace MySystem.UI.View
{
    public class ViewFactory : IViewFactory
    {
        private IViewModelFactory viewModelCreator;

        public ViewFactory() { }

        public ViewFactory(IViewModelFactory viewModelCreator)
        {
            this.viewModelCreator = viewModelCreator;
        }

        public IViewLogin CreateLoginPageView()
        {
            return new LoginPageView(this.viewModelCreator.CreateLoginPageViewModel());
        }

        public IViewMain CreateMainPageView(UserDTO userDTO, IMainClient mainClient)
        {
            return new MainPageView(this.viewModelCreator.CreateMainPageViewModel(userDTO, mainClient));
        }

        public IViewData CreateDataPageView(int id, UserDTO userDTO, AccountDTO accountDTO, IMainClient mainClient)
        {
            return new DataPageView(this.viewModelCreator.CreateDataPageViewModel(mainClient, accountDTO, userDTO, id));
        }
    }
}
