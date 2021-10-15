using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RasterPaint
{
    public class LineService
    {
        public Bitmap Bmp { get; set; }

        public Bitmap TrackingBmp { get; set; }

        public BresenhamLine BrensehamLine { get; set; }

        public BresenhamLine BrensehamTrackingLine { get; set; }

        public LineTracker LineTracker { get; set; }

        public PictureBox PictureBox { get; set; }

        public LineService(Bitmap bmp, PictureBox pictureBox)
        {
            this.Bmp = bmp;
            this.BrensehamLine = new BresenhamLine(bmp);
            
            this.PictureBox = pictureBox;
        }

        public void BeginTracking(int x, int y)
        {
            TrackingBmp = (Bitmap)Bmp.Clone();
            this.BrensehamTrackingLine = new BresenhamLine(TrackingBmp);
            this.PictureBox.Image = TrackingBmp;
            this.PictureBox.Invalidate();
            LineTracker = new LineTracker(this, x, y);
        }

        public void StopTracking()
        {
            var line = this.LineTracker.LastLine;
            this.CreateLine(line.Points[0].X, line.Points[0].Y,
                line.Points[line.Points.Count - 1].X,
                line.Points[line.Points.Count - 1].Y);

            this.PictureBox.Image = Bmp;
            this.TrackingBmp.Dispose();
            LineTracker = null;

            this.PictureBox.Invalidate();
        }

        public void AbortTracking()
        {

            this.PictureBox.Image = Bmp;
            this.TrackingBmp.Dispose();
            LineTracker = null;

            this.PictureBox.Invalidate();
        }

        public Line CreateLine(int x1, int y1, int x2, int y2)
        {
            return BrensehamLine.CreateLine(x1, y1, x2, y2);
        }

        public Line CreateTrackingLine(int x1, int y1, int x2, int y2)
        {
            return BrensehamTrackingLine.CreateLine(x1, y1, x2, y2);
        }

        public void EraseLine(Line line)
        {
            foreach(var point in line.Points)
            {
                Bmp.SetPixel(point.X, point.Y, Color.White);
            }
        }

        public void EraseTrackingLine(Line line)
        {
            foreach (var point in line.Points)
            {
                TrackingBmp.SetPixel(point.X, point.Y, Color.White);
            }
        }
    }
}
