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
    /// Interaktionslogik für DraggableControl.xaml
    /// </summary>
    public partial class DraggableControl : UserControl
    {
        protected bool isDragging;
        private Point clickPosition;
        private Point actualPosition;

        private Canvas parentCanvas;

        private Exercise exercise;
        private double angle;

        public DraggableControl(Exercise ex)
        {
            angle = 0.0;
            InitializeComponent();
            exercise = ex;
            this.MouseLeftButtonDown += new MouseButtonEventHandler(Control_MouseLeftButtonDown);
            this.MouseLeftButtonUp += new MouseButtonEventHandler(Control_MouseLeftButtonUp);
            this.MouseMove += new MouseEventHandler(Control_MouseMove);
        }

        public Canvas ParentCanvas { get => parentCanvas; set => parentCanvas = value; }
        public Point ClickPosition { get => clickPosition; set => clickPosition = value; }

        private void Control_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            var draggableControl = sender as UserControl;
            clickPosition = e.GetPosition(this);
            draggableControl.CaptureMouse();
        }

        private void Control_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            var draggable = sender as UserControl;            
            draggable.ReleaseMouseCapture();
            clickPosition = e.GetPosition(this);
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            var draggableControl = sender as UserControl;

            if (isDragging && draggableControl != null)
            {
                Point currentPosition = e.GetPosition(this.Parent as UIElement);
                Console.WriteLine("CURRENT POSITION MOUSE MOVE : " + currentPosition.ToString());

                var move = draggableControl.RenderTransform as TranslateTransform;
                var transformGroup = new TransformGroup();
                actualPosition = new Point();
                if (move == null)
                {
                    move = new TranslateTransform();
                    move.X = currentPosition.X - this.ActualWidth;
                    move.Y = currentPosition.Y - this.ActualHeight;
                    actualPosition.X = move.X;
                    actualPosition.Y = move.Y;
                    var rotate = new RotateTransform(angle, 0.5, 0.5);
                    transformGroup.Children.Add(rotate);
                    transformGroup.Children.Add(move);
                    draggableControl.RenderTransform = transformGroup;
                }
            }
        }

        private void OnMouseLeftButtonDown_UserControl(object sender, MouseButtonEventArgs e)
        {
            exercise.SelectedObject = this;
        }

        internal void Rotate()
        {
            angle = angle + 10;
            var transformGroup = new TransformGroup();
            var rotate  = new RotateTransform(angle, 0.5, 0.5);
            var move = new TranslateTransform(actualPosition.X, actualPosition.Y);
            transformGroup.Children.Add(rotate);
            transformGroup.Children.Add(move);
            this.RenderTransform = transformGroup;
        }
    }
}
