using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using MySystem.UI.Contract;
using MySystem.Service.Domain;
using System.Data;
using System.Collections;

namespace MySystem.UI.View
{
    public partial class MainPageView : UserControl, IViewMain
    {
        public MainPageView(IMainViewModel mainPageViewModel)
        {
            mainPageViewModel.ViewMain = this;
            InitializeComponent();
            this.DataContext = mainPageViewModel;
            mainPageViewModel.ShowAccount();
            mainPageViewModel.ShowNotes();
        }

        public string LastName
        {
            get { return this.Dispatcher.Invoke(() => this.lastNameTxt.Text); }
            set { this.Dispatcher.Invoke(() => this.lastNameTxt.Text = value); }
        }

        public string FirstName
        {
            get { return this.Dispatcher.Invoke(() => this.firstNameTxt.Text); }
            set { this.Dispatcher.Invoke(() => this.firstNameTxt.Text = value); }
        }

        public string SecondName
        {
            get { return this.Dispatcher.Invoke(() => this.secondNameTxt.Text); }
            set { this.Dispatcher.Invoke(() => this.secondNameTxt.Text = value); }
        }

        public Image Photo
        {
            get { return this.Dispatcher.Invoke(() => this.imagePhoto); }
            set { this.Dispatcher.Invoke(() => this.imagePhoto = value); }
        }

        public string ErrorLastName
        {
            get { return this.Dispatcher.Invoke(() => this.lblLastNameError.Content.ToString()); }
            set { this.Dispatcher.Invoke(() => this.lblLastNameError.Content = value); }
        }

        public string ErrorFirstName
        {
            get { return this.Dispatcher.Invoke(() => this.lblFirstNameError.Content.ToString()); }
            set { this.Dispatcher.Invoke(() => this.lblFirstNameError.Content = value); }
        }

        public string ErrorSecondName
        {
            get { return this.Dispatcher.Invoke(() => this.lblSecondNameError.Content.ToString()); }
            set { this.Dispatcher.Invoke(() => this.lblSecondNameError.Content = value); }
        }

        public Visibility NotesGridVisibility
        {
            get { return this.Dispatcher.Invoke(() => this.notesGrid.Visibility); }
            set { this.Dispatcher.Invoke(() => this.notesGrid.Visibility = value); }
        }

        public Visibility AccountGridVisibility
        {
            get { return this.Dispatcher.Invoke(() => this.accountGrid.Visibility); }
            set { this.Dispatcher.Invoke(() => this.accountGrid.Visibility = value); }
        }

        public ListView ListNotes
        {
            get { return this.Dispatcher.Invoke(() => this.listNotes); }
            set { this.Dispatcher.Invoke(() => this.listNotes = value); }
        }

        public void ShowError(string error)
        {
            this.Dispatcher.Invoke(() => MessageBox.Show(error, "Error!", MessageBoxButton.OK, MessageBoxImage.Error));
        }

        public void ShowMsh(string msg)
        {
            this.Dispatcher.Invoke(() => MessageBox.Show(msg, "Info!", MessageBoxButton.OK, MessageBoxImage.Information));
        }

        public void ClearError(string error)
        {
            this.Dispatcher.Invoke(() => error = "");
        }
    }
}
