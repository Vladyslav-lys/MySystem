using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using MySystem.UI.Commands;
using MySystem.BL.Contract;
using MySystem.Service.Domain;
using MySystem.UI.Contract;
using MySystem.Client.Contract;
using System.Windows.Threading;

namespace MySystem.UI.ViewModel
{
    public class LoginPageViewModel : ViewModelBase, ILoginViewModel
    {
        private IViewLogin viewLogin;

        private RelayCommand enterCommand;
        private RelayCommand exitCommand;

        private IEnterValidationRule enterValidationRule;
        private IComponentsController componentsController;
        private IMainClient mainClient;
        private IApp app;

        public LoginPageViewModel() { }

        public LoginPageViewModel(IEnterValidationRule enterValidationRule, IComponentsController componentsController, IMainClient mainClient, IApp app)
        {
            this.validatablePropertyCollection.Add("Login");
            this.validatablePropertyCollection.Add("Password");

            this.enterValidationRule = enterValidationRule;
            this.componentsController = componentsController;
            this.mainClient = mainClient;
            this.app = app;
        }

        //Команда входа
        public ICommand EnterCommand
        {
            get
            {
                if (this.enterCommand == null)
                {
                    this.enterCommand = new RelayCommand(() => this.Enter(), param => this.CanEnter);
                }
                return this.enterCommand;
            }
        }

        //Команда выхода
        public ICommand ExitCommand
        {
            get
            {
                if (this.exitCommand == null)
                {
                    this.exitCommand = new RelayCommand(() => this.Exit(), param => true);
                }
                return this.exitCommand;
            }
        }

        private bool CanEnter => this.IsValid;

        public IViewLogin ViewLogin
        {
            get { return this.viewLogin; }
            set { this.viewLogin = value; }
        }

        #region MainActive

        public void Enter()
        {
            try
            {
                string login = this.viewLogin.Login;
                string password = this.viewLogin.Password;
                UserDTO userDTO = null;

                Task task = Task.Run(async () =>
                {
                    if (!this.mainClient.IsConnected)
                    {
                        await this.mainClient.ConnectAsync();
                        this.mainClient.IsConnected = true;
                    }

                    if (this.mainClient.IsConnected)
                    {
                        userDTO = await this.mainClient.EnterAsync(login, password);
                    }
                });
                task.Wait();

                if (userDTO != null)
                {
                    this.componentsController.LoadMain(userDTO, mainClient);
                }
            }
            catch (Exception ex)
            {
                this.viewLogin.ShowError(ex.InnerException.Message);
            }
        }

        public void Exit()
        {
            try
            {
                if(this.mainClient.IsConnected)
                {
                    Task task = Task.Run(async () =>
                    {
                        await this.mainClient.DisconnectAsync();
                        this.mainClient.IsConnected = false;
                    });
                    task.Wait();
                }

                if(!this.mainClient.IsConnected)
                    this.app.Exit();
            }
            catch (Exception ex)
            {
                this.viewLogin.ShowError(ex.InnerException.Message);
            }
        }

        protected override string GetValidationError(string property)
        {
            string error = null;

            switch (property)
            {
                case "Login":
                    error = this.enterValidationRule.ValidateLogin(this.viewLogin.Login).GetError();
                    this.viewLogin.ErrorLogin = error;
                    break;
                case "Password":
                    error = this.enterValidationRule.ValidatePassword(this.viewLogin.Password).GetError();
                    this.viewLogin.ErrorPassword = error;
                    break;
                default:
                    this.viewLogin.ClearError(this.viewLogin.ErrorLogin);
                    this.viewLogin.ClearError(this.viewLogin.ErrorPassword);
                    break;
            }
            this.enterValidationRule.RefreshValidResult();

            return error;
        }
        #endregion
    }
}
////Вход в систему
//private async Task EnterAsync()
//{
//    try
//    {
//        if (this.GetValidErrorPassword(this.view.Password).Length > 0)
//        {
//            this.view.ShowError(this.GetValidErrorPassword(this.view.Password));
//            this.enterValidation.RefreshValidResult();
//        }
//        else if (this.GetValidErrorLogin(this.view.Login).Length > 0)
//        {
//            this.view.ShowError(this.GetValidErrorLogin(this.view.Login));
//            this.enterValidation.RefreshValidResult();
//        }
//        else
//        {
//            //await Task.Run(()=>
//            //{
//               this.mainClient.ConnectAsync(this.serviceUrl).Wait();
//            //});

//            //await Task.Run(() =>
//            //{
//               this.mainClient.EnterAsync(this.view.Login, this.view.Password).Wait();
//            //});

//            this.componentsController.LoadMain();
//        }
//    }
//    catch (Exception ex)
//    {
//        this.view.ShowError(ex.Message);
//    }
//}


////Проверка на корректность пароля
//public string GetValidErrorPassword(string password)
//{
//    return this.enterValidation.ValidatePassword(password).GetError();
//}

////Проверка на корректность логина
//public string GetValidErrorLogin(string login)
//{
//    return this.enterValidation.ValidateLogin(login).GetError();
//}

//public void RefreshValidResult()
//{
//    this.enterValidation.RefreshValidResult();
//}