using Models;
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

namespace Planungstool_Client.View
{
    /// <summary>
    /// Interaktionslogik für Community.xaml
    /// </summary>
    public partial class Community : UserControl
    {
        private User currentUser;
        private CommunityViewModel communityViewModel; 

        public Community(Models.User currentUser)
        {
            InitializeComponent();
            communityViewModel = new CommunityViewModel(currentUser);
            this.DataContext = communityViewModel;
            this.currentUser = currentUser;
        }

        private void SelectionChanged_Objects(object sender, SelectionChangedEventArgs e)
        {
            communityViewModel.SelectedTrainObject = (Trainingsobject)((ListView)sender).SelectedItem;
        }
    }
}
