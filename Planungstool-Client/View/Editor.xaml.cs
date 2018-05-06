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
    /// Interaktionslogik für Editor.xaml
    /// </summary>
    public partial class Editor : UserControl
    {
        private Library library;
        private Community community;
        private Exercise exercise;
        public Editor(User currentUser)
        {
            InitializeComponent();
            library = new Library(currentUser);
            libTabItem.Content = library;
            community = new Community(currentUser);
            comTabItem.Content = community;
            exercise = new Exercise(currentUser);
            exerTabItem.Content = exercise;

        }

        private void TabItem_Changed(object sender, SelectionChangedEventArgs e)
        {
            if(e.Source is TabControl)
            {
                TabItem tabItem = tabControl.SelectedItem as TabItem;
                switch(tabItem.Name)
                {
                    case "exerTabItem":
                        ((ExerciseViewModel)((Exercise)tabItem.Content).DataContext).Refresh();
                        break;
                    case "libTabItem":
                        ((LibraryViewModel)((Library)tabItem.Content).DataContext).Refresh();
                        break;
                    case "comTabItem":
                        ((CommunityViewModel)((Community)tabItem.Content).DataContext).Refresh();
                        break;

                }
            }
            e.Handled = true;
        }
    }

}
