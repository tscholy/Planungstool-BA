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
            labelDescriptionObject.Visibility = Visibility.Visible;
            labelNameObject.Visibility = Visibility.Visible;
            buttonAddObject.Visibility = Visibility.Visible;
            communityViewModel.SelectedTrainObject = (Trainingsobject)((ListView)sender).SelectedItem;
        }
        private void SelectionChanged_Exercise(object sender, SelectionChangedEventArgs e)
        {
            labelNameExercise.Visibility = Visibility.Visible;
            labelProcessExercise.Visibility = Visibility.Visible;
            labelTypeExercise.Visibility = Visibility.Visible;
            communityViewModel.SelectedTrainExercise = (Trainingsexercise)((ListView)sender).SelectedItem;
        }

        private void Button_AddObject(object sender, RoutedEventArgs e)
        {

            if(communityViewModel.AddObjectToUser())
            {
                MessageBox.Show("Trainingsobjekt wurde erfolgreich hinzugefügt.");
            }
            else
            {
                MessageBox.Show("Sie sind der Owner des Objects!");
            }
        }
    }
}
