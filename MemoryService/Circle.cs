using RasterPaint.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RasterPaint
{
    public class Circle
    {
        public Point Origin { get; set; }

        public int Radius { get; set; }

        public Relation LengthRelation { get; set; }

        public Relation TangentRelation { get; set; }

        public Circle(Point origin, int radius)
        {
            this.Origin = origin;
            this.Radius = radius;
        }
    }
}
