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

namespace Thermometers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int DEFAULT_CELL_SIZE = 100;
        private int dest;
        
        public MainWindow()
        {
            InitializeComponent();
            dest = new Random().Next(0, 2);

            Board myBoard = new Board(3, 3, DEFAULT_CELL_SIZE, 1.0f, myCanvas, label, dest);
            myBoard.redraw();

            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = myBoard.getBitmapImages()[dest];
            ImagePattern imagePattern = new ImagePattern(DEFAULT_CELL_SIZE, myCanvas, imageBrush);
        }
    }
}
