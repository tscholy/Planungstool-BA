using Models;
using Planungstool_Client.Converter;
using Planungstool_Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public Exercise(User currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            exerciseViewModel = new ExerciseViewModel(currentUser);
            this.DataContext = exerciseViewModel;
            
        }

        private void Button_Click_SaveExercise(object sender, RoutedEventArgs e)
        {
            Bitmap field = ImageFromCanvas;
        }

        private Bitmap ImageFromCanvas
        {
            get
            {
                RenderTargetBitmap rtb = new RenderTargetBitmap((int)canvas.RenderSize.Width,
                (int)canvas.RenderSize.Height, 96d, 96d, System.Windows.Media.PixelFormats.Default);
                rtb.Render(canvas);

                var crop = new CroppedBitmap(rtb, new Int32Rect(50, 50, 250, 250));

                BitmapEncoder pngEncoder = new PngBitmapEncoder();
                pngEncoder.Frames.Add(BitmapFrame.Create(crop));

                using (var fs = System.IO.File.OpenWrite("logo.png"))
                {
                    pngEncoder.Save(fs);
                }
                return null;
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
                    Canvas.SetLeft(myCanvas1, 50);
                    Canvas.SetTop(myCanvas1, 50);
                    canvas.Children.Add(myCanvas1);
                }
            }
        }
    }
}
