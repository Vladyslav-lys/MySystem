using System;
using System.Collections.Generic;
using MySystem.BL.Contract;
using MySystem.UI.Contract;
using MySystem.Client.Contract;
using MySystem.Service.Domain;

namespace MySystem.UI.ViewModel
{
    public class ViewModelFactory : IViewModelFactory
    {
        IValidationRuleFactory validationRuleFactory;
        IComponentsController componentsController;
        IClientFactory clientCreator;
        IApp app;

        public ViewModelFactory(IValidationRuleFactory validationRuleFactory, IComponentsController componentsController, IClientFactory clientCreator, IApp app)
        {
            this.validationRuleFactory = validationRuleFactory;
            this.componentsController = componentsController;
            this.clientCreator = clientCreator;
            this.app = app;
        }

        public ILoginViewModel CreateLoginPageViewModel()
        {
            return new LoginPageViewModel(validationRuleFactory.CreateEnterValidationRule(), componentsController, clientCreator.CreateMainClient(), app);
        }

        public IMainViewModel CreateMainPageViewModel(UserDTO userDTO, IMainClient mainClient)
        {
            return new MainPageViewModel(validationRuleFactory.CreateUpdateAccountValidationRule(), componentsController, mainClient, userDTO);
        }

        public IDataViewModel CreateDataPageViewModel(IMainClient mainClient, AccountDTO accountDTO, UserDTO userDTO, int id)
        {
            return new DataPageViewModel(validationRuleFactory.CreateDataNotesValidationRule(), componentsController, mainClient, app, accountDTO, userDTO, id);
        }
    }
}
