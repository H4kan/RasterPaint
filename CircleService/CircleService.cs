using RasterPaint.Enums;
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

        public void BeginTrackingFromGivenBmp(Bitmap trackingBmp)
        {
            this.TrackingGraphics = Graphics.FromImage(trackingBmp);
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

            this.CurrentCircle.Radius = Utils.CalculateDistance(this.Origin, new Point(e.X, e.Y));

            this.CreateTrackingCircle(this.CurrentCircle.Origin.X, this.CurrentCircle.Origin.Y, this.CurrentCircle.Radius);

            PictureBox.Invalidate();
        }



        public void StopTracking(object sender, MouseEventArgs e)
        {
            this.PictureBox.MouseClick -= StopTracking;
            this.PictureBox.MouseMove -= Tracking;
            this.CreateCircle(this.CurrentCircle);
            this.MemoryService.SaveCircle(this.CurrentCircle);
            this.CurrentCircle = null;
            this.PictureBox.Image = Bmp;
            TrackingBmp.Dispose();
            this.form.ExitAnyMode();
        }

        public void StopTrackingNoDrawing()
        {
            this.PictureBox.Image = Bmp;
            if (TrackingBmp != null)
                TrackingBmp.Dispose();
        }

        public Circle CreateCircle(int x1, int y1, int radius)
        {
            return GenerateCircle(x1, y1, radius, this.Graphics, Pens.Black);
        }

        public Circle CreateCircle(Circle circle)
        {
            return GenerateCircle(circle.Origin.X, circle.Origin.Y, circle.Radius, this.Graphics, Pens.Black);
        }

        public Circle CreateTrackingCircle(int x1, int y1, int radius)
        {
            return GenerateCircle(x1, y1, radius, this.TrackingGraphics, Pens.Black);
        }

        public Circle CreateTrackingCircle(Circle circle)
        {
            return GenerateCircle(circle.Origin.X, circle.Origin.Y, circle.Radius, this.TrackingGraphics, Pens.Black);
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
            if (this.MemoryService.SelectedCircle.TangentRelation != Enums.Relation.Tangency)
            {
                var circleMover = new CircleMover(this.MemoryService.SelectedCircle.Origin, this, 0);
                this.MemoryService.VertexPickers.Add(circleMover);
                this.MemoryService.LineService.PictureBox.Controls.Add(circleMover);
            }
            else
            {
                var relationHandler = this.form.RelationService.RelationHandlers.Find(r => r.CircleTarget == this.MemoryService.SelectedCircle && r.Type == Enums.Relation.Tangency);

                var edge = relationHandler.RelatedRelation.EdgeTarget;

                var edgeIdx = relationHandler.RelatedRelation.PolygonTarget.Edges.FindIndex(e => e == edge);

                var edgeMover = new EdgeMover(this.MemoryService.SelectedCircle.Origin, this.MemoryService, form.RelationService, this, edgeIdx, relationHandler.RelatedRelation.PolygonTarget);

                this.MemoryService.VertexPickers.Add(edgeMover);
                this.MemoryService.LineService.PictureBox.Controls.Add(edgeMover);
            }
        }

        public void EnterChangeRadiusMode()
        {
            if (this.MemoryService.SelectedCircle.LengthRelation == Enums.Relation.None)
            {
                var pointOnCircle = new Point(
                    this.MemoryService.SelectedCircle.Origin.X + this.MemoryService.SelectedCircle.Radius,
                    this.MemoryService.SelectedCircle.Origin.Y);
                var radiusChanger = new RadiusChanger(pointOnCircle, this, 0);
                this.MemoryService.VertexPickers.Add(radiusChanger);
                this.MemoryService.LineService.PictureBox.Controls.Add(radiusChanger);
            }
        }

        public void StartTrackingTangency(Circle circle)
        {
            var tangentRelation = this.form.RelationService.RelationHandlers.Find(r => r.CircleTarget == circle && r.Type == Relation.Tangency);


            var edgeIdx = tangentRelation.RelatedRelation.PolygonTarget.Edges.FindIndex(e => e == tangentRelation.RelatedRelation.EdgeTarget);
            var prevIdx = edgeIdx == 0 ? tangentRelation.RelatedRelation.PolygonTarget.Edges.Count - 1 : edgeIdx - 1;
            var nextIdx = edgeIdx == tangentRelation.RelatedRelation.PolygonTarget.Edges.Count - 1 ? 0 : edgeIdx + 1;

            this.MemoryService.LineService.EraseLine(tangentRelation.RelatedRelation.PolygonTarget.Edges[prevIdx]);
            this.MemoryService.LineService.EraseLine(tangentRelation.RelatedRelation.PolygonTarget.Edges[edgeIdx]);
            this.MemoryService.LineService.EraseLine(tangentRelation.RelatedRelation.PolygonTarget.Edges[nextIdx]);
        }

        public void FixTrackingTangency(Circle circle)
        {
            var tangentRelation = this.form.RelationService.RelationHandlers.Find(r => r.CircleTarget == circle && r.Type == Relation.Tangency);
            (tangentRelation.RelatedRelation as Tangency)
                .SetTangency(tangentRelation.RelatedRelation.PolygonTarget,
                tangentRelation.RelatedRelation.PolygonTarget.Edges.FindIndex(e => e == tangentRelation.RelatedRelation.EdgeTarget),
                tangentRelation.CircleTarget, true);
        }

        public void FinishTrackingTangency(Circle circle)
        {
            var tangentRelation = this.form.RelationService.RelationHandlers.Find(r => r.CircleTarget == circle && r.Type == Relation.Tangency);
            (tangentRelation.RelatedRelation as Tangency)
                .SetTangency(tangentRelation.RelatedRelation.PolygonTarget,
                tangentRelation.RelatedRelation.PolygonTarget.Edges.FindIndex(e => e == tangentRelation.RelatedRelation.EdgeTarget),
                tangentRelation.CircleTarget, false);
        }
    }
}
