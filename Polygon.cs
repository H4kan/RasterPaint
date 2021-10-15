using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RasterPaint
{
    public class Polygon
    {
        public List<Line> Edges { get; set; }

        public List<Point> Vertices { get; set; }
        
        public Polygon(int x, int y)
        {
            Vertices = new List<Point>();
            Vertices.Add(new Point(x, y));
            Edges = new List<Line>();
        }
         
        public void AppendLine(Line line)
        {
            this.Vertices.Add(line.Points[line.Points.Count - 1]);
            this.Edges.Add(line);
        }

        public void CompletePolygon(Line line)
        {
            this.Edges.Add(line);
        }
    }
}
