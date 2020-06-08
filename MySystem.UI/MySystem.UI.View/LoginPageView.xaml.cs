using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using MySystem.UI.Contract;

namespace MySystem.UI.View
{
    public partial class LoginPageView : UserControl, IViewLogin
    {
        public LoginPageView(ILoginViewModel loginPageViewModel)
        {
            loginPageViewModel.ViewLogin = this;
            InitializeComponent();
            this.DataContext = loginPageViewModel;
        }

        public string Login
        {
            get { return this.Dispatcher.Invoke(() => this.loginTxt.Text); }
        }

        public string Password
        {
            get { return this.Dispatcher.Invoke(() => this.passwordTxt.Password); }
        }

        public string ErrorLogin
        {
            get { return this.Dispatcher.Invoke(() => this.lblLoginError.Content.ToString()); }
            set { this.Dispatcher.Invoke(() => this.lblLoginError.Content = value); }
        }

        public string ErrorPassword
        {
            get { return this.Dispatcher.Invoke(() => this.lblPasswordError.Content.ToString()); }
            set { this.Dispatcher.Invoke(() => this.lblPasswordError.Content = value); }
        }

        //Показывает текст ошибки
        public void ShowError(string errorMessage)
        {
            //this.lblError.Content = errorMessage;
            this.Dispatcher.Invoke(() => MessageBox.Show(errorMessage, "Error!", MessageBoxButton.OK, MessageBoxImage.Error));
        }

        public void ClearError(string error)
        {
            this.Dispatcher.Invoke(() => error = "");
        }
    }
}
