using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace MySystem.UI.Contract
{
    public interface IViewData
    {
        string Topic { get; set; }
        string Text { get; set; }
        string ErrorTopic { get; set; }
        string ErrorText { get; set; }
        DateTime Calendar { get; set; }
        Image Image { get; set; }
        void ShowError(string error);
        void ShowMsh(string msg);
        void ClearError(string error);
    }
}
