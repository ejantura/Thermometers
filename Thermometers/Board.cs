﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Thermometers
{
    class Board
    {
        private int cellSize;
        private int dest;
        private int rowCount;
        private int colCount;
        private float marginPerc;
        private int[] stats = new int[9];
        private Rectangle[] rect = new Rectangle[9];
        private Random rnd = new Random();
        private Canvas myCanvas;
        private Label myLabel;
        private ImageManager imageManager;

        public Board(BoardConfig boardConfig, Canvas myCanvas, Label myLabel, ImageManager imageManager)
        {
            this.myCanvas = myCanvas;
            this.myLabel = myLabel;
            this.dest = boardConfig.Dest;
            this.cellSize = boardConfig.CellSize;
            this.rowCount = boardConfig.RowCount;
            this.colCount = boardConfig.ColCount;
            this.marginPerc = boardConfig.MarginPerc;
            this.imageManager = imageManager;
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
        void boardHandler(object sender, MouseButtonEventArgs e)
        {
            int x = Convert.ToInt32(Math.Floor(e.GetPosition(myCanvas).X / cellSize));
            int y = Convert.ToInt32(Math.Floor(e.GetPosition(myCanvas).Y / cellSize));
            stats[y * 3 + x]++;
            stats[y * 3 + x] %= 3;
            redrawCell(x, y);
            if (checkIfWin())
                myLabel.Content = "WIN";
            else
                myLabel.Content = "Continue playing";
            e.Handled = true;
        }

        void redrawCell(int col, int row)
        {
            int pos = row * 3 + col;
            rect[pos].Fill = imageManager.getImageBrushes()[stats[pos]];
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

        public void redraw()
        {
            for (int i = 0; i < 9; i++)
            {
                rect[i].Fill = imageManager.getImageBrushes()[stats[i]]; ;
            }
        }
    }


}
