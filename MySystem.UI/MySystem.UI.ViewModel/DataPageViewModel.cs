using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using MySystem.UI.Commands;
using MySystem.BL.Contract;
using MySystem.Service.Domain;
using MySystem.UI.Contract;
using MySystem.Client.Contract;
using System.Drawing.Imaging;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace MySystem.UI.ViewModel
{
    public class DataPageViewModel : ViewModelBase, IDataViewModel
    {
        private IViewData viewData;
        
        private RelayCommand executeCommand;
        private RelayCommand browseCommand;
        private RelayCommand exitCommand;

        private IDataNotesValidationRule dataNotesValidationRule;
        private IComponentsController componentsController;
        private IMainClient mainClient;
        private IApp app;
        private UserDTO userDTO;
        private AccountDTO accountDTO;
        private NotesDTO notesDTO = null;
        private List<NotesDTO> notesesDTO = new List<NotesDTO>();
        private int id;

        public DataPageViewModel() { }

        public DataPageViewModel(IDataNotesValidationRule dataNotesValidationRule, IComponentsController componentsController, IMainClient mainClient, IApp app, AccountDTO accountDTO, UserDTO userDTO, int id)
        {
            this.validatablePropertyCollection.Add("Topic");
            this.validatablePropertyCollection.Add("Text");

            this.dataNotesValidationRule = dataNotesValidationRule;
            this.componentsController = componentsController;
            this.mainClient = mainClient;
            this.app = app;
            this.accountDTO = accountDTO;
            this.userDTO = userDTO;
            this.id = id;
        }

        public ICommand ExecuteCommand
        {
            get
            {
                if (this.executeCommand == null)
                {
                    if(this.id > 0)
                        this.executeCommand = new RelayCommand(() => this.EditNotes(), param => this.CanExecute);
                    else if (this.id == 0)
                        this.executeCommand = new RelayCommand(() => this.AddNotes(), param => this.CanExecute);
                }
                return this.executeCommand;
            }
        }

        public ICommand BrowseCommand
        {
            get
            {
                if (this.browseCommand == null)
                {
                    this.browseCommand = new RelayCommand(() => this.Browse(), param => true);
                }
                return this.browseCommand;
            }
        }

        public ICommand ExitCommand
        {
            get
            {
                if (this.exitCommand == null)
                {
                    this.exitCommand = new RelayCommand(() => this.ExitNotes(), param => true);
                }
                return this.exitCommand;
            }
        }

        private bool CanExecute => this.IsValid;

        public IViewData ViewData
        {
            get { return this.viewData; }
            set { this.viewData = value; }
        }

        public void ShowNotes()
        {
            try
            {
                if(id > 0)
                {
                    Task task = Task.Run(async () =>
                    {
                        this.notesesDTO = await this.mainClient.ShowNotesAsync(this.accountDTO.Id);
                    });
                    task.Wait();
                    
                    if(notesesDTO.Count > 0)
                    {
                        foreach (NotesDTO curNotesDTO in notesesDTO)
                        {
                            if (id.Equals(curNotesDTO.Id))
                            {
                                notesDTO = curNotesDTO;
                                break;
                            }
                        }

                        if (this.notesDTO != null)
                        {
                            this.viewData.Topic = notesDTO.Topic;
                            this.viewData.Text = notesDTO.Text;
                            this.viewData.Calendar = notesDTO.Date;

                            if(notesDTO.Image != null && notesDTO.Image.Length > 0)
                            {
                                MemoryStream memoryStream = new MemoryStream(notesDTO.Image);
                                memoryStream.Seek(0, SeekOrigin.Begin);
                                this.viewData.Image.Source = BitmapFrame.Create(memoryStream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                                memoryStream.Dispose();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.viewData.ShowError(ex.InnerException.Message);
            }
        }

        public void AddNotes()
        {
            try
            {
                OperationStatusInfo operationStatusInfo = null;

                string topic = this.viewData.Topic;
                string text = this.viewData.Text;
                DateTime date = this.viewData.Calendar;

                byte[] image = new byte[0];
                if (this.viewData.Image.Source != null)
                {
                    image = GetImageByBitmapImage(this.viewData.Image.Source as BitmapImage, this.viewData.Image.Source.ToString());
                }

                Task task = Task.Run(async () =>
                {
                    NotesDTO newNotesDTO = new NotesDTO();
                    newNotesDTO.Topic = topic;
                    newNotesDTO.Text = text;
                    newNotesDTO.Date = date;
                    newNotesDTO.Image = image;
                    newNotesDTO.IdAccount = accountDTO.Id;

                    operationStatusInfo = await this.mainClient.AddNotesAsync(newNotesDTO);
                });
                task.Wait();

                if (operationStatusInfo != null)
                {
                    this.viewData.ShowMsh(operationStatusInfo.AttachedInfo);
                }
            }
            catch (Exception ex)
            {
                this.viewData.ShowError(ex.InnerException.Message);
            }
        }

        public void EditNotes()
        {
            try
            {
                OperationStatusInfo operationStatusInfo = null;

                string topic = this.viewData.Topic;
                string text = this.viewData.Text;
                DateTime date = this.viewData.Calendar;

                byte[] image = new byte[0];
                if (this.viewData.Image.Source != null)
                {
                    image = GetImageByBitmapImage(this.viewData.Image.Source as BitmapImage, this.viewData.Image.Source.ToString());
                }

                Task task = Task.Run(async () =>
                {
                    this.notesDTO.Topic = topic;
                    this.notesDTO.Text = text;
                    this.notesDTO.Date = date;
                    this.notesDTO.Image = image;

                    operationStatusInfo = await this.mainClient.UpdateNotesAsync(this.notesDTO);
                });
                task.Wait();

                if (operationStatusInfo != null)
                {
                    this.viewData.ShowMsh(operationStatusInfo.AttachedInfo);
                }
            }
            catch (Exception ex)
            {
                this.viewData.ShowError(ex.InnerException.Message);
            }
        }

        public void Browse()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                {
                    double width = this.viewData.Image.Width;
                    double height = this.viewData.Image.Height;

                    Uri uri = new Uri(openFileDialog.FileName, UriKind.Relative);
                    BitmapImage bitmapImage = new BitmapImage(uri);
                    
                    this.viewData.Image.Width = bitmapImage.Width;
                    this.viewData.Image.Height = bitmapImage.Height;
                    this.viewData.Image.Source = bitmapImage;
                    this.viewData.Image.Width = width;
                    this.viewData.Image.Height = height;
                }
            }
            catch(Exception ex)
            {
                this.viewData.ShowError(ex.Message);
            }
        }

        public void ExitNotes()
        {
            try
            {
                this.componentsController.LoadMain(userDTO, mainClient);
            }
            catch (Exception ex)
            {
                this.viewData.ShowError(ex.InnerException.Message);
            }
        }

        protected override string GetValidationError(string property)
        {
            string error = null;

            switch (property)
            {
                case "Topic":
                    error = this.dataNotesValidationRule.ValidateTopic(this.viewData.Topic).GetError();
                    this.viewData.ErrorTopic = error;
                    break;
                case "Text":
                    error = this.dataNotesValidationRule.ValidateText(this.viewData.Text).GetError();
                    this.viewData.ErrorText = error;
                    break;
                default:
                    this.viewData.ClearError(this.viewData.ErrorTopic);
                    this.viewData.ClearError(this.viewData.ErrorText);
                    break;
            }
            this.dataNotesValidationRule.RefreshValidResult();

            return error;
        }

        private byte[] GetImageByBitmapImage(BitmapImage bitmapImage, string path)
        {
            byte[] image = this.accountDTO.Photo;
            if (this.accountDTO.Photo == null)
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
    }
}
