using Planungstool_Client.View;
using Planungstool_Client.ViewModel;
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

namespace Planungstool_Client
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel mainWindowVM = new MainWindowViewModel();
            Login login = new Login(mainWindowVM);
            mainWindowVM.CurrentControl = login;
            this.DataContext = mainWindowVM;
        }

        private void OnClick_TerminateApp(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Really close?", "Warning", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
