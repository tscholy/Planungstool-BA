using Models;
using Planungstool_Client.ViewModel;
using Planungstool_Client.WebService;
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
    /// Interaktionslogik für Library.xaml
    /// </summary>
    public partial class Library : UserControl
    {
        LibraryViewModel libraryViewModel = new LibraryViewModel();
        TrainingRestClient trainingRestClient;
        private User currentUser;

        public Library(User currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            trainingRestClient = new TrainingRestClient(currentUser.Id);
            this.DataContext = libraryViewModel;
            libraryViewModel.CurrentTrainingsobjects = trainingRestClient.GetAllTrainingsobjectsForUser(currentUser.Id);

        }

        private void Button_Click_UploadNewTrainingsobject(object sender, RoutedEventArgs e)
        {
            libraryViewModel.NewUploadObjectControl = new Upload(currentUser, libraryViewModel);
        }
    }
}
