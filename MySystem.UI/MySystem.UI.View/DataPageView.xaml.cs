using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySystem.UI.Contract;

namespace MySystem.UI.View
{
    public partial class DataPageView : UserControl, IViewData
    {
        public DataPageView(IDataViewModel dataViewModel)
        {
            dataViewModel.ViewData = this;
            InitializeComponent();
            this.DataContext = dataViewModel;
            dataViewModel.ShowNotes();
        }

        public string Topic
        {
            get { return this.Dispatcher.Invoke(() => this.topicTxt.Text); }
            set { this.Dispatcher.Invoke(() => this.topicTxt.Text = value); }
        }

        public string Text
        {
            get { return this.Dispatcher.Invoke(() => this.textTxt.Text); }
            set { this.Dispatcher.Invoke(() => this.textTxt.Text = value); }
        }

        public string ErrorTopic
        {
            get { return this.Dispatcher.Invoke(() => this.lblTopicError.Content.ToString()); }
            set { this.Dispatcher.Invoke(() => this.lblTopicError.Content = value); }
        }

        public string ErrorText
        {
            get { return this.Dispatcher.Invoke(() => this.lblTextError.Content.ToString()); }
            set { this.Dispatcher.Invoke(() => this.lblTextError.Content = value); }
        }

        public DateTime Calendar
        {
            get { return this.Dispatcher.Invoke(() => this.dateCalendar.SelectedDate.Value); }
            set { this.Dispatcher.Invoke(() => this.dateCalendar.SelectedDate = value); }
        }

        public Image Image
        {
            get { return this.Dispatcher.Invoke(() => this.imageImage); }
            set { this.Dispatcher.Invoke(() => this.imageImage = value); }
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
