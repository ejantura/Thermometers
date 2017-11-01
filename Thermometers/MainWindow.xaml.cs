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
        BitmapImage[] bmi = new BitmapImage[3];
        Rectangle[] rect  = new Rectangle[9];
        int[] stats = new int[9]; 
        int index = 0;
        int DEFAULT_CELL_SIZE = 100;
        int dest;
        Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
            bmi[0] = new BitmapImage(new Uri("file:///e:\\Projects\\Thermometers\\smile1.png", UriKind.Absolute));
            bmi[1] = new BitmapImage(new Uri("file:///e:\\Projects\\Thermometers\\smile2.png", UriKind.Absolute));
            bmi[2] = new BitmapImage(new Uri("file:///e:\\Projects\\Thermometers\\smile3.png", UriKind.Absolute));
            rect1.Width = DEFAULT_CELL_SIZE;
            rect1.Height = DEFAULT_CELL_SIZE;
            dest = rnd.Next(0, 2);
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = bmi[dest];
            rect1.Fill = ib;
            createBoard(3,3, DEFAULT_CELL_SIZE, 1f);
            redrawBoard();
        }

        void createBoard(int colCount, int rowCount, int cellSize, float marginPerc)
        {
             for (int col = 0; col < colCount; col++)
                for (int row = 0; row < rowCount; row++)
                {
                    stats[row * colCount + col] = rnd.Next(0, 2);
                    rect[row * colCount + col] = new Rectangle();
                    rect[row * colCount + col].Width = cellSize;
                    rect[row * colCount + col].Height = cellSize;
                    rect[row * colCount + col].Stroke = Brushes.Black;
                    rect[row * colCount + col].StrokeThickness = 1;
                    myCanvas.Children.Add(rect[row * colCount + col]);
                    Canvas.SetTop(rect[row * colCount + col], row * cellSize * marginPerc);
                    Canvas.SetLeft(rect[row * colCount + col], col * cellSize * marginPerc);
                    rect[row * colCount + col].MouseLeftButtonDown += new MouseButtonEventHandler(boardHandler);
                }
        }

        void redrawBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                ImageBrush ib = new ImageBrush();
                ib.ImageSource = bmi[stats[i]];
                rect[i].Fill = ib;
            }      

        }

        void boardHandler(object sender, MouseButtonEventArgs e)
        {
            int x = Convert.ToInt32(Math.Floor(e.GetPosition(myCanvas).X / DEFAULT_CELL_SIZE));
            int y = Convert.ToInt32(Math.Floor(e.GetPosition(myCanvas).Y / DEFAULT_CELL_SIZE));
            stats[y * 3 + x]++;
            stats[y * 3 + x] %= 3;
            redrawCell(x,y);
            if (checkIfWin())
                label.Content = "WIN";
            else
                label.Content = "Continue playing";
            e.Handled = true;
        }


        void redrawCell(int col, int row)
        {
            int pos = row * 3 + col;
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = bmi[stats[pos]];
            rect[pos].Fill = ib;


        }

        bool checkIfWin()
        {
            for (int i = 0; i < 9; i++)
            {
                if (stats[i] != dest)
                    return false; 
            }

            return true;

        }

    }
}
