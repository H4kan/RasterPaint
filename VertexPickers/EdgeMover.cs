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

        private Point lastLocation;

        private int prevIndex;
        private int nextIndex;

        public EdgeMover(Point Origin, MemoryService memoryService, int index) : base(Origin, index)
        {
            this.MouseDown += BeginTracking;
            this.memoryService = memoryService;
        }

        private void BeginTracking(object sender, MouseEventArgs e)
        {
            this.MouseDown -= BeginTracking;
            this.MouseUp += StopTracking;
            this.MouseMove += Tracking;
            lastLocation = this.Location;

            this.memoryService.LineService.EraseLine(this.memoryService.SelectedPolygon.Edges[Index]);
            this.memoryService.LineService.BeginTrackingNoUpdate();


            prevIndex = this.Index == 0 ? this.memoryService.SelectedPolygon.Edges.Count - 1 : this.Index - 1;
            nextIndex = this.Index == this.memoryService.SelectedPolygon.Edges.Count - 1 ? 0 : this.Index + 1;

            this.memoryService.VertexPickers[prevIndex].Hide();
            this.memoryService.VertexPickers[nextIndex].Hide();

            this.memoryService.LineService.EraseLine(this.memoryService.SelectedPolygon.Edges[prevIndex]);
            this.memoryService.LineService.EraseLine(this.memoryService.SelectedPolygon.Edges[nextIndex]);
        }

        private void Tracking(object sender, MouseEventArgs e)
        {
            var globalEventLocation = this.PointToScreen(e.Location);
            var globalPictureBoxLocation = this.memoryService.LineService.PictureBox.PointToScreen(new Point(0, 0));


            var newLocation = new Point(globalEventLocation.X - globalPictureBoxLocation.X - PickerSize.Width / 2,
                globalEventLocation.Y - globalPictureBoxLocation.Y - PickerSize.Height / 2);


            var offsetLocation = (newLocation.X - lastLocation.X, newLocation.Y - lastLocation.Y);


            var selectedEdge = this.memoryService.SelectedPolygon.Edges[this.Index];

            this.memoryService.LineService.EraseTrackingLine(selectedEdge);

            selectedEdge.Points = new List<Point>() {
                new Point(selectedEdge.Points[0].X + offsetLocation.Item1,
                    selectedEdge.Points[0].Y + offsetLocation.Item2),
                new Point(selectedEdge.Points[1].X + offsetLocation.Item1,
                    selectedEdge.Points[1].Y + offsetLocation.Item2) };


            var prevEdge = this.memoryService.SelectedPolygon.Edges[prevIndex];
            var nextEdge = this.memoryService.SelectedPolygon.Edges[nextIndex];

            this.memoryService.LineService.EraseTrackingLine(prevEdge);
            this.memoryService.LineService.EraseTrackingLine(nextEdge);

            prevEdge.Points[1] = new Point(prevEdge.Points[1].X + offsetLocation.Item1, prevEdge.Points[1].Y + offsetLocation.Item2);
            nextEdge.Points[0] = new Point(nextEdge.Points[0].X + offsetLocation.Item1, nextEdge.Points[0].Y + offsetLocation.Item2);

            this.memoryService.LineService.CreateTrackingLine(selectedEdge);
            this.memoryService.LineService.CreateTrackingLine(prevEdge);
            this.memoryService.LineService.CreateTrackingLine(nextEdge);


            this.memoryService.LineService.PictureBox.Invalidate();


            this.Location = newLocation;
            lastLocation = newLocation;
        }
         

        private void StopTracking(object sender, MouseEventArgs e)
        {
            this.MouseUp -= StopTracking;
            this.MouseMove -= Tracking;
            this.MouseDown += BeginTracking;

            this.memoryService.LineService.StopTracking(this.memoryService.SelectedPolygon.Edges[Index]);
            this.memoryService.LineService.StopTracking(this.memoryService.SelectedPolygon.Edges[prevIndex]);
            this.memoryService.LineService.StopTracking(this.memoryService.SelectedPolygon.Edges[nextIndex]);


            var prevMidPoint = this.memoryService.SelectedPolygon.Edges[prevIndex].EvaluateMidPoint();
            var nextMidPoint = this.memoryService.SelectedPolygon.Edges[nextIndex].EvaluateMidPoint();


            this.memoryService.VertexPickers[prevIndex].Location = new Point(prevMidPoint.X - PickerSize.Width / 2, prevMidPoint.Y - PickerSize.Height / 2);
            this.memoryService.VertexPickers[nextIndex].Location = new Point(nextMidPoint.X - PickerSize.Width / 2, nextMidPoint.Y - PickerSize.Height / 2);
            this.memoryService.VertexPickers[prevIndex].Show();
            this.memoryService.VertexPickers[nextIndex].Show();

            this.memoryService.SelectedPolygon.Vertices[Index] = this.memoryService.SelectedPolygon.Edges[Index].Points[0];
            this.memoryService.SelectedPolygon.Vertices[nextIndex] = this.memoryService.SelectedPolygon.Edges[Index].Points[1];

        }
    }
}
