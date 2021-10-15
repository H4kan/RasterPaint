using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RasterPaint
{
    public class BresenhamLine
    {
        public Bitmap bmp { get; set; }

        public BresenhamLine(Bitmap bmp)
        {
            this.bmp = bmp;
        }

        private void BresenhamLow(Line line, int x1, int y1, int x2, int y2)
        {
            int dx = x2 - x1;
            int dy = y2 - y1;
            int y_step = 1;
            if (dy < 0)
            {
                y_step = -1;
                dy = -dy;
            }
            int d = (2 * dy) - dx;
            int y = y1;
            int x = x1;

            while (x <= x2)
            {
                bmp.SetPixel(x, y, Color.Black);
                line.AppendPoint(new Point(x, y));
                if (d > 0)
                {
                    y += y_step;
                    d += 2 * (dy - dx);
                }
                else
                {
                    d += 2 * dy;
                }
                x++;
            }
        }

        private void BresenhamHigh(Line line, int x1, int y1, int x2, int y2)
        {
            int dx = x2 - x1;
            int dy = y2 - y1;
            int x_step = 1;
            if (dx < 0)
            {
                x_step = -1;
                dx = -dx;
            }
            int d = (2 * dx) - dy;
            int y = y1;
            int x = x1;

            while (y <= y2)
            {
                bmp.SetPixel(x, y, Color.Black);
                line.AppendPoint(new Point(x, y));
                if (d > 0)
                {
                    x += x_step;
                    d += 2 * (dx - dy);
                }
                else
                {
                    d += 2 * dx;
                }
                y++;
            }
        }

        public Line CreateLine(int x1, int y1, int x2, int y2)
        {
            var line = new Line();
            if (Math.Abs(y2 - y1) < Math.Abs(x2 - x1))
            {
                if (x1 > x2)
                    BresenhamLow(line, x2, y2, x1, y1);
                else
                    BresenhamLow(line, x1, y1, x2, y2);
            }
            else
            {
                if (y1 > y2)
                    BresenhamHigh(line, x2, y2, x1, y1);
                else
                    BresenhamHigh(line, x1, y1, x2, y2);
            }
            return line;
        }
    }
}
