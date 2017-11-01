using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thermometers
{
    class BoardConfig
    {
        public int ColCount { get; set; }
        public int RowCount { get; set; }
        public int CellSize { get; set; }
        public int Dest { get; set; }
        public float MarginPerc { get; set; }

        public BoardConfig()
        {
            

        }
    }
}
