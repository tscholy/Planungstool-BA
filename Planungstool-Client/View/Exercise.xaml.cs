using Models;
using Planungstool_Client.Converter;
using Planungstool_Client.ViewModel;
using Planungstool_Client.WebService;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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

namespace Planungstool_Client.View
{
    /// <summary>
    /// Interaktionslogik für Exercise.xaml
    /// </summary>
    public partial class Exercise : UserControl
    {
        private ExerciseViewModel exerciseViewModel;
        private User currentUser;
        private TrainingRestClient trainingRestClient;
        private DraggableControl selectedObject;


        public Exercise(User currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            exerciseViewModel = new ExerciseViewModel(currentUser);
            this.DataContext = exerciseViewModel;
            

        }

        private void Button_Click_SaveExercise(object sender, RoutedEventArgs e)
        {

            trainingRestClient = new TrainingRestClient(currentUser.Id);
            int parent = -1;
            if(chkEnableUnit.IsChecked == true)
            {
                if (radioButtonNewUnit.IsChecked == true)
                {
                    Trainingsunit trainingsunit = new Trainingsunit();
                    if (radioButtonPrivate.IsChecked == true)
                    {
                        trainingsunit.Accessibility = "private";
                    }
                    else
                    {
                        trainingsunit.Accessibility = "public";
                    }
                    trainingsunit.Description = textBoxDescripUnit.Text;
                    trainingsunit.Name = textBoxNameUnit.Text;
                    trainingsunit = trainingRestClient.SaveUnit(trainingsunit);
                }
                else if(radioButtonExisting.IsChecked == true)
                {
                    int id = (int)comboBoxUnits.SelectedValue;
                    parent = id;
                }
            }         
            
            if(trainingRestClient.SaveExercise(GetExercise(parent)))
            {
                if(MessageBoxResult.OK == MessageBox.Show("Übung wurde erfolgreich gespeichert!"))
                {
                    var images = canvas.Children.OfType<Canvas>().ToList();
                    foreach (var image in images)
                    {
                        canvas.Children.Remove(image);
                    }
                    textboxName.Text = "";
                    textboxProcedure.Text = "";
                    textboxType.Text = "";
                }
            }
        }

        private Trainingsexercise GetExercise(int parent)
        {
            MemoryStream field = ImageFromCanvas;
            Trainingsexercise trainingsexercise = new Trainingsexercise();
            trainingsexercise.Name = textboxName.Text;
            trainingsexercise.Process = textboxProcedure.Text;
            if (radioButtonPrivate.IsChecked == true)
            {
                trainingsexercise.Accessibility = "private";
            }
            else
            {
                trainingsexercise.Accessibility = "public";
            }
            trainingsexercise.Owner = currentUser.Id;
            trainingsexercise.Image = field.ToArray();
            trainingsexercise.Type = textboxType.Text;
            if(parent > 0)
            { 
                trainingsexercise.Parent = parent;
            }
            return trainingsexercise;
        }

        private MemoryStream ImageFromCanvas
        {
            get
            {
                System.Windows.Size size = new System.Windows.Size(canvas.ActualWidth, canvas.ActualHeight);
                RenderTargetBitmap rtb = new RenderTargetBitmap((int)canvas.RenderSize.Width, (int)canvas.RenderSize.Height, 96d, 96d, System.Windows.Media.PixelFormats.Default);
                canvas.Arrange(new Rect(size));
                rtb.Render(canvas);
                BitmapEncoder encoder = new BmpBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(rtb));
                using (MemoryStream mem = new MemoryStream())
                {
                    encoder.Save(mem);
                    return mem;
                }                
            }
        }

        public DraggableControl SelectedObject { get => selectedObject; set => selectedObject = value; }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                Trainingsobject trainingsobject = (Trainingsobject)item.Content;
                using (MemoryStream mem = new MemoryStream(trainingsobject.Image))
                {
                    Bitmap bitmap = new Bitmap(mem);
                    DraggableControl myCanvas1 = new DraggableControl(this);

                    myCanvas1.ParentCanvas = canvas;
                    myCanvas1.MinHeight = 15;
                    myCanvas1.MinWidth = 15;
                    myCanvas1.Height = 50;
                    myCanvas1.Width = 50;
                    ImageBrush ib = new ImageBrush();
                    BitmapToImageSourceConverter converter = new BitmapToImageSourceConverter();
                    BitmapImage img = (BitmapImage)converter.Convert(bitmap, null, null, null);
                    ib.ImageSource = img;
                    myCanvas1.canvas.Background = ib;

                    Canvas.SetLeft(myCanvas1, 50);
                    Canvas.SetTop(myCanvas1, 50);

                    canvas.Children.Add(myCanvas1);
                    myCanvas1.ParentCanvas = canvas;
                    SelectedObject = myCanvas1;
                }
            }
        }
        private void RemoveLast_OnCanvas(object sender, RoutedEventArgs e)
        {
            List<DraggableControl> images = canvas.Children.OfType<DraggableControl>().ToList();
            var element = images.LastOrDefault();
            canvas.Children.Remove(element);
        }

        private void DeleteCanvas_OnClick(object sender, RoutedEventArgs e)
        {
            var images = canvas.Children.OfType<DraggableControl>().ToList();
            foreach (var image in images)
            {
                canvas.Children.Remove(image);
            }
        }

        private void RadioButton_IsChecked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender as RadioButton;
            if(radioButton.Name == "radioButtonExisting")
            {
                grdExisting.Visibility = Visibility.Visible;
                grdNew.Visibility = Visibility.Hidden;
            }
            else if (radioButton.Name == "radioButtonNewUnit")
            {
                grdExisting.Visibility = Visibility.Hidden;
                grdNew.Visibility = Visibility.Visible;
            }
        }

        private void chkEnableUnit_Checked(object sender, RoutedEventArgs e)
        {
            stackPanelGroup.Visibility = Visibility.Visible;
        }

        private void chkEnableUnit_UnChecked(object sender, RoutedEventArgs e)
        {
            stackPanelGroup.Visibility = Visibility.Hidden;
        }

        private void MinimizeSize_OnClick(object sender, RoutedEventArgs e)
        {
            SelectedObject.Height = SelectedObject.ActualHeight - 10;
            SelectedObject.Width = SelectedObject.ActualWidth - 10;
        }

        private void MaximizeSize_OnClick(object sender, RoutedEventArgs e)
        {
            SelectedObject.Height = SelectedObject.ActualHeight + 10;
            SelectedObject.Width = SelectedObject.ActualWidth + 10;
        }

        private void Rotate_OnClick(object sender, RoutedEventArgs e)
        {
            SelectedObject.Rotate();
        }

        private void SelectedField_Changed(object sender, SelectionChangedEventArgs e)
        {
            Trainingsobject trainingsobject = (Trainingsobject)listViewFields.SelectedItem;
            if(trainingsobject != null)
            {
                using (MemoryStream mem = new MemoryStream(trainingsobject.Image))
                {
                    Bitmap img = new Bitmap(mem);
                    exerciseViewModel.CurrentField = img;
                }
            }
        }
    }
}
