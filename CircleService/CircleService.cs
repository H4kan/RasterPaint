using RasterPaint.VertexPickers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RasterPaint
{
    public class CircleService
    {
        public Bitmap Bmp { get; set; }

        public Bitmap TrackingBmp { get; set; }

        public PictureBox PictureBox { get; set; }

        public Graphics Graphics { get; set; }

        public Graphics TrackingGraphics { get; set; }

        public Point Origin { get; set; }

        public Circle CurrentCircle { get; set; }

        private Form1 form { get; set; }

        public MemoryService MemoryService { get; set; }

        public CircleService(Form1 form, Bitmap bmp, PictureBox pictureBox, MemoryService memoryService)
        {
            this.form = form;

            this.Bmp = bmp;
            
            this.PictureBox = pictureBox;

            this.Graphics = Graphics.FromImage(bmp);

            this.MemoryService = memoryService;
        }

        public void BeginCircle()
        {
            
            TrackingBmp = (Bitmap)Bmp.Clone();

            this.TrackingGraphics = Graphics.FromImage(TrackingBmp);

            this.PictureBox.Image = TrackingBmp;
            this.PictureBox.Invalidate();

            this.PictureBox.MouseClick += BeginTracking;
        }

        public void BeginTrackingNoUpdate()
        {
            TrackingBmp = (Bitmap)Bmp.Clone();

            this.TrackingGraphics = Graphics.FromImage(TrackingBmp);

            this.PictureBox.Image = TrackingBmp;
            this.PictureBox.Invalidate();
        }


        public void BeginTracking(object sender, MouseEventArgs e)
        {
            this.Origin = new Point(e.X, e.Y);
            this.CurrentCircle = new Circle(Origin, 0);
            this.PictureBox.MouseClick -= BeginTracking;
            this.PictureBox.MouseMove += Tracking;
            this.PictureBox.MouseClick += StopTracking;
        }

        public void Tracking(object sender, MouseEventArgs e)
        {
            this.EraseTrackingCircle(this.CurrentCircle);

            this.CurrentCircle = new Circle(Origin, this.CalculateDistance(this.Origin, new Point(e.X, e.Y)));

            this.CreateTrackingCircle(this.CurrentCircle.Origin.X, this.CurrentCircle.Origin.Y, this.CurrentCircle.Radius);

            PictureBox.Invalidate();
        }

        public void StopTracking(object sender, MouseEventArgs e)
        {
            this.PictureBox.MouseClick -= StopTracking;
            this.PictureBox.MouseMove -= Tracking;
            this.CreateCircle(this.CurrentCircle.Origin.X, this.CurrentCircle.Origin.Y, this.CurrentCircle.Radius);
            this.MemoryService.SaveCircle(this.CurrentCircle);
            this.CurrentCircle = null;
            this.PictureBox.Image = Bmp;
            TrackingBmp.Dispose();
            this.form.ExitAnyMode();
        }

        public void StopTrackingNoDrawing()
        {
            this.PictureBox.Image = Bmp;
            TrackingBmp.Dispose();
        }

        public Circle CreateCircle(int x1, int y1, int radius)
        {
            return GenerateCircle(x1, y1, radius, this.Graphics, Pens.Black);
        }

        public Circle CreateTrackingCircle(int x1, int y1, int radius)
        {
            return GenerateCircle(x1, y1, radius, this.TrackingGraphics, Pens.Black);
        }

        private Circle GenerateCircle(int x1, int y1, int radius, Graphics gfc, Pen pen)
        {
            gfc.DrawEllipse(pen, new Rectangle(new Point(x1 - radius, y1 - radius), new Size(2 * radius, 2 * radius)));
            return new Circle(new Point(x1, y1), radius);
        }

        public Circle EraseCircle(Circle circle)
        {
            return GenerateCircle(circle.Origin.X, circle.Origin.Y, circle.Radius, this.Graphics, Pens.White);
        }

        public Circle EraseTrackingCircle(Circle circle)
        {
            return GenerateCircle(circle.Origin.X, circle.Origin.Y, circle.Radius, this.TrackingGraphics, Pens.White);
        }

        private int CalculateDistance(Point p1, Point p2)
        {
            var p = Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
            return Convert.ToInt32(Math.Round(p));
        }

        public void AbortCircleTracking()
        {
            this.PictureBox.MouseMove -= Tracking;
            this.PictureBox.MouseClick -= BeginTracking;
            this.PictureBox.MouseClick -= StopTracking;

            this.PictureBox.Image = Bmp;
            TrackingBmp.Dispose();
        }

        public void EnterMoveCircleMode()
        {
            var circleMover = new CircleMover(this.MemoryService.SelectedCircle.Origin, this, 0);
            this.MemoryService.VertexPickers.Add(circleMover);
            this.MemoryService.LineService.PictureBox.Controls.Add(circleMover);
        }

        public void EnterChangeRadiusMode()
        {
            var pointOnCircle = new Point(
                this.MemoryService.SelectedCircle.Origin.X + this.MemoryService.SelectedCircle.Radius,
                this.MemoryService.SelectedCircle.Origin.Y);
            var radiusChanger = new RadiusChanger(pointOnCircle, this, 0);
            this.MemoryService.VertexPickers.Add(radiusChanger);
            this.MemoryService.LineService.PictureBox.Controls.Add(radiusChanger);
        }
    }
}
