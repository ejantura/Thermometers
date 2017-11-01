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

            BoardConfig boardConfig = new BoardConfig();
            boardConfig.CellSize = DEFAULT_CELL_SIZE;
            boardConfig.ColCount = 3;
            boardConfig.RowCount = 3;
            boardConfig.MarginPerc = 1.0f;
            boardConfig.Dest = imagePattern.getDest();

            Board myBoard = new Board(boardConfig, myCanvas, label, imageManager);
            myBoard.redraw();
          }
    }
}
