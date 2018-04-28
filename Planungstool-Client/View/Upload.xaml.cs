using System;
using System.Collections.Generic;
using System.IO;
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
using Models;
using Planungstool_Client.ViewModel;
using Planungstool_Client.WebService;

namespace Planungstool_Client.View
{
    /// <summary>
    /// Interaktionslogik für Upload.xaml
    /// </summary>
    public partial class Upload : UserControl
    {
        private User currentUser;
        private LibraryViewModel libraryViewModel;
        private MemoryStream memoryStreamFile;

        private TrainingRestClient trainingRestClient;

        public Upload(User currentUser, LibraryViewModel libraryViewModel)
        {
            InitializeComponent();
            trainingRestClient = new TrainingRestClient(currentUser.Id);
            this.currentUser = currentUser;
            this.libraryViewModel = libraryViewModel;
        }

        private void Button_Click_ChooseFile(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                memoryStreamFile = new MemoryStream();
                using(FileStream fileStream = new FileStream(dlg.FileName, FileMode.Open))
                {
                    fileStream.CopyTo(memoryStreamFile);
                }               
                string filename = dlg.FileName;
                textboxFilename.Text = filename;
            }
        }

        private void Button_Click_Upload(object sender, RoutedEventArgs e)
        {
            Trainingsobject trainingsobject = new Trainingsobject();
            trainingsobject.Name = textBoxName.Text;
            trainingsobject.Description = textboxBeschreibung.Text;
            trainingsobject.Owner = currentUser.Id;
            if(radioButtonPrivate.IsChecked == true)
            {
                trainingsobject.Accessibility = "private";
            } else
            {
                trainingsobject.Accessibility = "public";
            }
            trainingsobject.Image = memoryStreamFile.ToArray();
            trainingRestClient.SaveObject(trainingsobject);
            
            libraryViewModel.NewUploadObjectControl = null;
        }
    }
}
