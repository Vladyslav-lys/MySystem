using System;
using System.Configuration;
using System.Windows;
using MySystem.BL.Contract;
using MySystem.BL.Rules;
using MySystem.UI.Contract;
using MySystem.UI.View;
using MySystem.UI.ViewModel;
using MySystem.Client.Contract;
using MySystem.Client.Main;

namespace MySystem.UI.Main
{
    public partial class App : Application, IApp
    {
        //Событие выполняется при старте
        private void AppStartUp(object sender, StartupEventArgs args)
        {
            try
            {
                IClientFactory clientCreator = new ClientFactory();
                IComponentsController componentsController = new ComponentsController();
                IValidationRuleFactory validationRuleFactory = new ValidationRuleFactory();
                IViewModelFactory viewModelCreator = new ViewModelFactory(validationRuleFactory, componentsController, clientCreator, this);
                IViewFactory viewCreator = new ViewFactory(viewModelCreator);
                componentsController.SetView(viewCreator);
                componentsController.LoadLogin();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Событие выполняется при выходе
        private void AppExit(object sender, ExitEventArgs args)
        {
            this.Shutdown();
        }

        void IApp.Exit()
        {
            this.Shutdown();
        }
    }
}
