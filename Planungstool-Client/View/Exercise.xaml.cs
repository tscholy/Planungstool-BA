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
        private bool isDragging;
        private System.Windows.Point clickPosition;

        public Exercise(User currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            exerciseViewModel = new ExerciseViewModel(currentUser);
            this.DataContext = exerciseViewModel;


        }

        private void Button_Click_SaveExercise(object sender, RoutedEventArgs e)
        {
            MemoryStream field = ImageFromCanvas;
            trainingRestClient = new TrainingRestClient(currentUser.Id);
            Trainingsexercise trainingsexercise = new Trainingsexercise();
            trainingsexercise.Name = textboxName.Text;
            trainingsexercise.Process = textboxProcedure.Text;
            if(radioButtonPrivate.IsChecked == true)
            {
                trainingsexercise.Accessibility = "private";
            }
            else
            {
                trainingsexercise.Accessibility = "public";
            }
            trainingsexercise.Owner = currentUser.Id;
            trainingsexercise.Image = field.ToArray();
            trainingsexercise.Type = textboxName.Text;

            if(trainingRestClient.SaveExercise(trainingsexercise))
            {
                if(MessageBoxResult.OK == MessageBox.Show("Übung wurde erfolgreich gespeichert!"))
                {
                    canvas.Children.Clear();
                    textboxName.Text = "";
                    textboxProcedure.Text = "";
                    textboxType.Text = "";
                }
            }
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

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                Trainingsobject trainingsobject = (Trainingsobject)item.Content;
                using (MemoryStream mem = new MemoryStream(trainingsobject.Image))
                {
                    Bitmap bitmap = new Bitmap(mem);
                    Canvas myCanvas1 = new Canvas();
                    myCanvas1.MinHeight = 50;
                    myCanvas1.MinWidth = 50;
                    ImageBrush ib = new ImageBrush();
                    BitmapToImageSourceConverter converter = new BitmapToImageSourceConverter();
                    BitmapImage img = (BitmapImage)converter.Convert(bitmap, null, null, null);
                    ib.ImageSource = img;
                    myCanvas1.Background = ib;
                    myCanvas1.MouseLeftButtonDown += new MouseButtonEventHandler(Control_MouseLeftButtonDown);
                    myCanvas1.MouseLeftButtonUp += new MouseButtonEventHandler(Control_MouseLeftButtonUp);
                    myCanvas1.MouseMove += new MouseEventHandler(Control_MouseMove);

                    Canvas.SetLeft(myCanvas1, 50);
                    Canvas.SetTop(myCanvas1, 50);
                    canvas.Children.Add(myCanvas1);
                }
            }
        }

        private void Control_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            var draggableControl = sender as Canvas;
            clickPosition = e.GetPosition(this);
            draggableControl.CaptureMouse();
        }

        private void Control_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            var draggable = sender as Canvas;
            if(draggable != null)
            {
                draggable.ReleaseMouseCapture();
            }
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            var draggableControl = sender as Canvas;

            if (isDragging && draggableControl != null)
            {
                System.Windows.Point currentPosition = e.GetPosition(this.Parent as UIElement);

                var transform = draggableControl.RenderTransform as TranslateTransform;
                if (transform == null)
                {
                    transform = new TranslateTransform();
                    draggableControl.RenderTransform = transform;
                }

                transform.X = currentPosition.X - clickPosition.X;
                transform.Y = currentPosition.Y - clickPosition.Y;
            }
        }

    }
}
