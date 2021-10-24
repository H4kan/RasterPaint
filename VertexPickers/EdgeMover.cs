using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RasterPaint.VertexPickers
{
    public class EdgeMover : VertexPicker
    {
        private MemoryService memoryService;
        private RelationService relationService;
        private CircleService circleService;

        private Circle relatedCircle;
        private Polygon polygon;

        private Point lastLocation;

        private int prevIndex;
        private int nextIndex;

        public EdgeMover(Point Origin, MemoryService memoryService, RelationService relationService, CircleService circleService, int index, Polygon polygon) : base(Origin, index)
        {
            this.MouseDown += BeginTracking;
            this.memoryService = memoryService;
            this.relationService = relationService;
            this.circleService = circleService;
            this.polygon = polygon;
        }

        private void BeginTracking(object sender, MouseEventArgs e)
        {
            this.MouseDown -= BeginTracking;
            this.MouseUp += StopTracking;
            this.MouseMove += Tracking;
            lastLocation = this.Location;

            

            this.memoryService.LineService.EraseLine(polygon.Edges[Index]);
            this.memoryService.LineService.BeginTrackingNoUpdate();

            prevIndex = this.Index == 0 ? polygon.Edges.Count - 1 : this.Index - 1;
            nextIndex = this.Index == polygon.Edges.Count - 1 ? 0 : this.Index + 1;

            if (this.memoryService.VertexPickers.Count > 1)
            {
                this.memoryService.VertexPickers[prevIndex].Hide();
                this.memoryService.VertexPickers[nextIndex].Hide();
            }

                this.memoryService.LineService.EraseLine(polygon.Edges[prevIndex]);
                this.memoryService.LineService.EraseLine(polygon.Edges[nextIndex]);

            this.relatedCircle = this.relationService.GetEdgeRelatedCircle(polygon.Edges[Index]);

            if (this.relatedCircle != null)
            {
                this.circleService.BeginTrackingFromGivenBmp(this.memoryService.LineService.TrackingBmp);

                this.circleService.EraseCircle(relatedCircle);
            }
        }

        private void Tracking(object sender, MouseEventArgs e)
        {
            var globalEventLocation = this.PointToScreen(e.Location);
            var globalPictureBoxLocation = this.memoryService.LineService.PictureBox.PointToScreen(new Point(0, 0));


            var newLocation = new Point(globalEventLocation.X - globalPictureBoxLocation.X - PickerSize.Width / 2,
                globalEventLocation.Y - globalPictureBoxLocation.Y - PickerSize.Height / 2);


            var offsetLocation = (newLocation.X - lastLocation.X, newLocation.Y - lastLocation.Y);


            var selectedEdge = polygon.Edges[this.Index];

            this.memoryService.LineService.EraseTrackingLine(selectedEdge);

            selectedEdge.Points = new List<Point>() {
                new Point(selectedEdge.Points[0].X + offsetLocation.Item1,
                    selectedEdge.Points[0].Y + offsetLocation.Item2),
                new Point(selectedEdge.Points[1].X + offsetLocation.Item1,
                    selectedEdge.Points[1].Y + offsetLocation.Item2) };


            var prevEdge = polygon.Edges[prevIndex];
            var nextEdge = polygon.Edges[nextIndex];

            this.memoryService.LineService.EraseTrackingLine(prevEdge);
            this.memoryService.LineService.EraseTrackingLine(nextEdge);

            prevEdge.Points[1] = new Point(prevEdge.Points[1].X + offsetLocation.Item1, prevEdge.Points[1].Y + offsetLocation.Item2);
            nextEdge.Points[0] = new Point(nextEdge.Points[0].X + offsetLocation.Item1, nextEdge.Points[0].Y + offsetLocation.Item2);

            this.memoryService.LineService.CreateTrackingLine(selectedEdge);
            this.memoryService.LineService.CreateTrackingLine(prevEdge);
            this.memoryService.LineService.CreateTrackingLine(nextEdge);

            if (this.relatedCircle != null)
            {
                this.circleService.EraseTrackingCircle(this.relatedCircle);
                this.relatedCircle.Origin = new Point(this.relatedCircle.Origin.X + offsetLocation.Item1,
                    this.relatedCircle.Origin.Y + offsetLocation.Item2);
                this.circleService.CreateTrackingCircle(this.relatedCircle);
            }

            this.memoryService.LineService.PictureBox.Invalidate();


            this.Location = newLocation;
            lastLocation = newLocation;
        }
         

        private void StopTracking(object sender, MouseEventArgs e)
        {
            this.MouseUp -= StopTracking;
            this.MouseMove -= Tracking;
            this.MouseDown += BeginTracking;

            this.memoryService.LineService.StopTracking(polygon.Edges[Index]);
            this.memoryService.LineService.StopTracking(polygon.Edges[prevIndex]);
            this.memoryService.LineService.StopTracking(polygon.Edges[nextIndex]);

            if (this.memoryService.VertexPickers.Count > 1)
            {
                var prevMidPoint = polygon.Edges[prevIndex].EvaluateMidPoint();
                var nextMidPoint = polygon.Edges[nextIndex].EvaluateMidPoint();

                this.memoryService.VertexPickers[prevIndex].Location = new Point(prevMidPoint.X - PickerSize.Width / 2, prevMidPoint.Y - PickerSize.Height / 2);
                this.memoryService.VertexPickers[nextIndex].Location = new Point(nextMidPoint.X - PickerSize.Width / 2, nextMidPoint.Y - PickerSize.Height / 2);
                this.memoryService.VertexPickers[prevIndex].Show();
                this.memoryService.VertexPickers[nextIndex].Show();
            }

            polygon.Vertices[Index] = polygon.Edges[Index].Points[0];
            polygon.Vertices[nextIndex] = polygon.Edges[Index].Points[1];

            if (this.relatedCircle != null)
            {
                this.circleService.CreateCircle(this.relatedCircle);
                this.circleService.StopTrackingNoDrawing();
            }
        }
    }
}
