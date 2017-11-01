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
                
        public MainWindow()
        {
            InitializeComponent();

            ImageManager imageManager = new ImageManager();
            ImagePattern imagePattern = new ImagePattern(DEFAULT_CELL_SIZE, myCanvas, imageManager);

            Board myBoard = new Board(3, 3, DEFAULT_CELL_SIZE, 1.0f, myCanvas, label, imagePattern.getDest(), imageManager);
            myBoard.redraw();
          }
    }
}
