using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    class Draw
    {
        public void DrawRectangleInt(PaintEventArgs e)
        {

            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);

            // Create location and size of rectangle.
            int x = 0;
            int y = 0;
            int width = 200;
            int height = 200;

            // Draw rectangle to screen.
            e.Graphics.DrawRectangle(blackPen, x, y, width, height);
        }
    }
}
