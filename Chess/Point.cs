using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Point
    {
        private int x;
        private int y;
        public Point(int a, int b) {
            this.X = a;
            this.Y = b;
        }
        public Point() { }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
    }
}
