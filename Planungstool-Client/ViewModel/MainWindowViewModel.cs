using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Planungstool_Client.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        private UserControl currentControl;
        private Bitmap currentBackground;

        public MainWindowViewModel()
        {
            CurrentBackground = new Bitmap(Properties.Resources.back);
        }
        public UserControl CurrentControl
        {
            get { return currentControl; }
            set
            {
                SetProperty(ref currentControl, value);
            }
        }

        public Bitmap CurrentBackground
        {
            get { return currentBackground; }
            set { SetProperty(ref currentBackground, value); }
        }
    }
}
