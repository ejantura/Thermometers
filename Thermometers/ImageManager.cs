using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Thermometers
{
    class ImageManager
    {
        private BitmapImage[] bitmapImages = new BitmapImage[3];
        private ImageBrush[] imageBrushes = new ImageBrush[3];
        private String[] imagePaths = { "file:///e:\\Projects\\Thermometers\\smile1.png",
                                        "file:///e:\\Projects\\Thermometers\\smile2.png",
                                        "file:///e:\\Projects\\Thermometers\\smile3.png"}; 

        public ImageManager()
        {
            for (int i = 0; i < 3; i++)
            {
                bitmapImages[i] = new BitmapImage(new Uri(imagePaths[i], UriKind.Absolute));
                imageBrushes[i] = new ImageBrush();
                imageBrushes[i].ImageSource = bitmapImages[i];
            }
        }

        public ImageBrush[] getImageBrushes()
        {
            return imageBrushes;
        }
    }
}
