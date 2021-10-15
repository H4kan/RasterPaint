using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RasterPaint
{
    public class Line
    {
        public List<Point> Points = new List<Point>();

        public void AppendPoint(Point point)
        {
            Points.Add(point);
        }
    }
}
