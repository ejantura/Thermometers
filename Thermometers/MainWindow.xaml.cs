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
        int dest;
        Random rnd = new Random();
        int DEFAULT_CELL_SIZE = 100;

        public MainWindow()
        {
            InitializeComponent();
            dest = rnd.Next(0, 2);
            Board myBoard = new Board(3, 3, DEFAULT_CELL_SIZE, 1.0f, myCanvas, label, dest);
            myBoard.redraw();
            rect1.Width = DEFAULT_CELL_SIZE;
            rect1.Height = DEFAULT_CELL_SIZE;
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = myBoard.getBitmapImages()[dest];
            rect1.Fill = ib;
        }
    }
}
