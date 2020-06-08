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
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.IO;

namespace MySystem.UI.ViewModel
{
    public class MainPageViewModel : ViewModelBase, IMainViewModel
    {
        private IViewMain viewMain;
        
        private RelayCommand editAccountCommand;
        private RelayCommand editNotesCommand;
        private RelayCommand addNotesCommand;
        private RelayCommand browseAccountCommand;
        private RelayCommand showAccountElementsCommand;
        private RelayCommand showNotesElementsCommand;

        private IUpdateAccountValidationRule updateAccountValidationRule;
        private IComponentsController componentsController;
        private IMainClient mainClient;
        private UserDTO userDTO;
        private AccountDTO accountDTO = null;
        private List<NotesDTO> notesesDTO = new List<NotesDTO>();

        public MainPageViewModel() { }

        public MainPageViewModel(IUpdateAccountValidationRule updateAccountValidationRule, IComponentsController componentsController, IMainClient mainClient, UserDTO userDTO)
        {
            this.validatablePropertyCollection.Add("LastName");
            this.validatablePropertyCollection.Add("FirstName");
            this.validatablePropertyCollection.Add("SecondName");

            this.updateAccountValidationRule = updateAccountValidationRule;
            this.componentsController = componentsController;
            this.mainClient = mainClient;
            this.userDTO = userDTO;
        }
        
        public ICommand EditAccountCommand
        {
            get
            {
                if (this.editAccountCommand == null)
                {
                    this.editAccountCommand = new RelayCommand(() => this.EditAccount(), param => this.CanEdit);
                }
                return this.editAccountCommand;
            }
        }

        public ICommand EditNotesCommand
        {
            get
            {
                if (this.editNotesCommand == null)
                {
                    this.editNotesCommand = new RelayCommand(() => this.ShowData(this.viewMain.ListNotes.SelectedIndex), param => true);
                }
                return this.editNotesCommand;
            }
        }

        public ICommand AddNotesCommand
        {
            get
            {
                if (this.addNotesCommand == null)
                {
                    this.addNotesCommand = new RelayCommand(() => this.ShowData(), param => true);
                }
                return this.addNotesCommand;
            }
        }

        public ICommand BrowseAccountCommand
        {
            get
            {
                if (this.browseAccountCommand == null)
                {
                    this.browseAccountCommand = new RelayCommand(() => this.Browse(), param => true);
                }
                return this.browseAccountCommand;
            }
        }

        public ICommand ShowNotesElementsCommand
        {
            get
            {
                if (this.showNotesElementsCommand == null)
                {
                    this.showNotesElementsCommand = new RelayCommand(() => this.ShowNotesElements(), param => true);
                }
                return this.showNotesElementsCommand;
            }
        }

        public ICommand ShowAccountElementsCommand
        {
            get
            {
                if (this.showAccountElementsCommand == null)
                {
                    this.showAccountElementsCommand = new RelayCommand(() => this.ShowAccountElements(), param => true);
                }
                return this.showAccountElementsCommand;
            }
        }

        private bool CanEdit => this.IsValid;

        public IViewMain ViewMain
        {
            get { return this.viewMain; }
            set { this.viewMain = value; }
        }

        #region MainActive
        public void ShowAccount()
        {
            try
            {
                Task task = Task.Run(async () =>
                {
                    this.accountDTO = await this.mainClient.ShowAccountAsync(this.userDTO.Id);
                });
                task.Wait();

                if (this.accountDTO != null)
                {
                    this.viewMain.LastName = this.accountDTO.LastName;
                    this.viewMain.FirstName = this.accountDTO.FirstName;
                    this.viewMain.SecondName = this.accountDTO.SecondName;

                    if (accountDTO.Photo != null && accountDTO.Photo.Length > 0)
                    {
                        MemoryStream memoryStream = new MemoryStream(accountDTO.Photo);
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        this.viewMain.Photo.Source = BitmapFrame.Create(memoryStream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                        memoryStream.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                this.viewMain.ShowError(ex.InnerException.Message);
            }
        }

        public void ShowNotes()
        {
            try
            {
                Task task = Task.Run(async () =>
                {
                    this.notesesDTO = await this.mainClient.ShowNotesAsync(this.accountDTO.Id);
                });
                task.Wait();

                if (this.notesesDTO.Count > 0)
                {
                    this.viewMain.ListNotes.ItemsSource = this.notesesDTO;
                }
            }
            catch (Exception ex)
            {
                this.viewMain.ShowError(ex.InnerException.Message);
            }
        }

        public void EditAccount()
        {
            try
            {
                OperationStatusInfo operationStatusInfo = null;

                string lastName = this.viewMain.LastName;
                string firstName = this.viewMain.FirstName;
                string secondName = this.viewMain.SecondName;

                byte[] photo = new byte[0];
                if (this.viewMain.Photo.Source != null)
                {
                    photo = GetImageByBitmapImage(this.viewMain.Photo.Source as BitmapImage, this.viewMain.Photo.Source.ToString());
                }

                Task task = Task.Run(async () =>
                {
                    this.accountDTO.LastName = lastName;
                    this.accountDTO.FirstName = firstName;
                    this.accountDTO.SecondName = secondName;
                    this.accountDTO.Photo = photo;
                    operationStatusInfo = await this.mainClient.UpdateAccountAsync(this.accountDTO);
                });
                task.Wait();

                if (operationStatusInfo != null)
                {
                    this.viewMain.ShowMsh(operationStatusInfo.AttachedInfo);
                }
            }
            catch (Exception ex)
            {
                this.viewMain.ShowError(ex.InnerException.Message);
            }
        }

        public void ShowData(int id)
        {
            try
            {
                if (id.Equals(-1))
                {
                    throw new Exception("Choose any notes!");
                }
                else
                {
                    id = ((NotesDTO)this.viewMain.ListNotes.SelectedItem).Id;
                    this.componentsController.LoadData(id, userDTO, accountDTO, mainClient);
                }
            }
            catch (Exception ex)
            {
                this.viewMain.ShowError(ex.Message);
            }
        }

        public void ShowData()
        {
            this.componentsController.LoadData(0, userDTO, accountDTO, mainClient);
        }

        public void Browse()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                {
                    double width = this.viewMain.Photo.Width;
                    double height = this.viewMain.Photo.Height;

                    Uri uri = new Uri(openFileDialog.FileName, UriKind.Relative);
                    BitmapImage bitmapImage = new BitmapImage(uri);

                    this.viewMain.Photo.Width = bitmapImage.Width;
                    this.viewMain.Photo.Height = bitmapImage.Height;
                    this.viewMain.Photo.Source = bitmapImage;
                    this.viewMain.Photo.Width = width;
                    this.viewMain.Photo.Height = height;
                }
            }
            catch (Exception ex)
            {
                this.viewMain.ShowError(ex.Message);
            }
        }

        public void ShowNotesElements()
        {
            this.viewMain.AccountGridVisibility = Visibility.Hidden;
            this.viewMain.NotesGridVisibility = Visibility.Visible;
        }

        public void ShowAccountElements()
        {
            this.viewMain.AccountGridVisibility = Visibility.Visible;
            this.viewMain.NotesGridVisibility = Visibility.Hidden;
        }

        protected override string GetValidationError(string property)
        {
            string error = null;

            switch (property)
            {
                case "LastName":
                    error = this.updateAccountValidationRule.ValidateLastName(this.viewMain.LastName).GetError();
                    this.viewMain.ErrorLastName = error;
                    break;
                case "FirstName":
                    error = this.updateAccountValidationRule.ValidateFirstName(this.viewMain.FirstName).GetError();
                    this.viewMain.ErrorFirstName = error;
                    break;
                case "SecondName":
                    error = this.updateAccountValidationRule.ValidateSecondName(this.viewMain.SecondName).GetError();
                    this.viewMain.ErrorSecondName = error;
                    break;
                default:
                    this.viewMain.ClearError(this.viewMain.ErrorLastName);
                    this.viewMain.ClearError(this.viewMain.ErrorFirstName);
                    this.viewMain.ClearError(this.viewMain.ErrorSecondName);
                    break;
            }
            this.updateAccountValidationRule.RefreshValidResult();

            return error;
        }

        private byte[] GetImageByBitmapImage(BitmapImage bitmapImage, string path)
        {
            byte[] image = this.accountDTO.Photo;
            if(this.accountDTO.Photo == null)
            {
                image = new byte[0];
            }
            
            if (bitmapImage != null)
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = File.OpenRead(path);
                bi.EndInit();
                image = new byte[bi.StreamSource.Length];
                bi.StreamSource.Seek(0, SeekOrigin.Begin);
                bi.StreamSource.Read(image, 0, image.Length);
            }

            return image;
        }
        #endregion
    }
}


//public string GetValidProfileLastName(string lastName)
//{
//    return this.profileValidation.ValidateLastName(lastName).GetError();
//}

//public string GetValidProfileFirstName(string firstName)
//{
//    return this.profileValidation.ValidateFirstName(firstName).GetError();
//}

//public string GetValidProfileSecondName(string secondName)
//{
//    return this.profileValidation.ValidateSecondName(secondName).GetError();
//}

//public void RefreshValidResult()
//{
//    this.profileValidation.RefreshValidResult();
//}