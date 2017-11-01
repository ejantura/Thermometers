using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Thermometers
{
    class ImagePattern
    {
        private int dest;
        public ImagePattern(int imageSize, Canvas myCanvas, ImageManager imageManager)
        {
            dest = new Random().Next(0, 2);
            Rectangle rectanglePattern = new Rectangle();
            rectanglePattern.Width = imageSize;
            rectanglePattern.Height = imageSize;
            rectanglePattern.Stroke = Brushes.Black;
            rectanglePattern.StrokeThickness = 1;
            myCanvas.Children.Add(rectanglePattern);
            Canvas.SetTop(rectanglePattern, 200);
            Canvas.SetLeft(rectanglePattern, 350);
            rectanglePattern.Fill = imageManager.getImageBrushes()[dest];
        }

        public int getDest()
        {
            return dest;
        }
    }
}
