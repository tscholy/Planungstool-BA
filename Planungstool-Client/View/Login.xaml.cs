using Planungstool_Client.ViewModel;
using Planungstool_Client.WebService;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Planungstool_Client.View
{
    /// <summary>
    /// Interaktionslogik für Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        private MainWindowViewModel mainVM;

        public Login(MainWindowViewModel m)
        {
            InitializeComponent();
            mainVM = m;
        }



        private void Click_Login(object sender, RoutedEventArgs e)
        {
            UserRestClient userRestClient = new UserRestClient(-1);
            //usernameTextbox.Text
            //passwordTextbox.Password.ToString()
            if (userRestClient.Login("admin", "admin"))
            {
                mainVM.CurrentControl = new Editor(userRestClient.CurrentUser);
            }
            else
            {
                errorLabel.Content = "Credentials are invalid!";
            }

        }

        private void KeyUp_Login(object sender, KeyEventArgs e)
        {
            if(e.Key == System.Windows.Input.Key.Enter)
            {
                Click_Login(sender, e);
            }
            else
            {
                return;
            }
        }
    }
}
