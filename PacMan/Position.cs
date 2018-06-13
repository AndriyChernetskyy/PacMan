using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public class Position
    {
        private int x;
        private int y;
        public int X { get { return x; } set { this.x = value; } }
        public int Y { get { return x; } set { this.y = value; } }
        

        public Position(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
