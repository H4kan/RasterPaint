using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RasterPaint.VertexPickers
{
    public class PolyMover : VertexPicker
    {
        private MemoryService memoryService;
        private RelationService relationService;
        private CircleService circleService;
        private Point lastLocation;
        private List<Circle> relatedCircles;

        public PolyMover(Point Origin, MemoryService memoryService, RelationService relationService, CircleService circleService, int index) : base(Origin, index)
        {
            this.MouseDown += BeginTracking;
            this.memoryService = memoryService;
            this.relationService = relationService;
            this.circleService = circleService;
        }

        private void BeginTracking(object sender, MouseEventArgs e)
        {
            this.MouseDown -= BeginTracking;
            this.MouseUp += StopTracking;
            this.MouseMove += Tracking;
            lastLocation = this.Location;

            this.memoryService.LineService.BeginTrackingNoUpdate();
            foreach (var line in this.memoryService.SelectedPolygon.Edges)
            {
                this.memoryService.LineService.EraseLine(line);
            }
            this.circleService.BeginTrackingFromGivenBmp(this.memoryService.LineService.TrackingBmp);


            this.relatedCircles = this.relationService.GetPolygonRelatedCircles(this.memoryService.SelectedPolygon);
            foreach (var circle in this.relatedCircles)
            {
                this.circleService.EraseCircle(circle);
            }
        }

        private void Tracking(object sender, MouseEventArgs e)
        {
            var globalEventLocation = this.PointToScreen(e.Location);
            var globalPictureBoxLocation = this.memoryService.LineService.PictureBox.PointToScreen(new Point(0, 0));


            var newLocation = new Point(globalEventLocation.X - globalPictureBoxLocation.X - PickerSize.Width / 2,
                globalEventLocation.Y - globalPictureBoxLocation.Y - PickerSize.Height / 2);


            var offsetLocation = (newLocation.X - lastLocation.X, newLocation.Y - lastLocation.Y);

            for(int i = 0; i < this.memoryService.SelectedPolygon.Vertices.Count; i++)
            {
                var oldPoint = this.memoryService.SelectedPolygon.Vertices[i];

                this.memoryService.SelectedPolygon.Vertices[i] = new Point(
                    oldPoint.X + offsetLocation.Item1,
                    oldPoint.Y + offsetLocation.Item2);
          
                var currLine = this.memoryService.SelectedPolygon.Edges[i];
                this.memoryService.LineService.EraseTrackingLine(currLine);

                currLine.Points[0] = new Point(currLine.Points[0].X + offsetLocation.Item1,
                    currLine.Points[0].Y + offsetLocation.Item2);
                currLine.Points[1] = new Point(currLine.Points[1].X + offsetLocation.Item1,
                    currLine.Points[1].Y + offsetLocation.Item2);

                this.memoryService.LineService.CreateTrackingLine(currLine);

            
            }
            for (int i = 0; i < this.memoryService.VertexPickers.Count; i++)
            {
                var oldPickerPoint = this.memoryService.VertexPickers[i].Location;
                this.memoryService.VertexPickers[i].Location = new Point(oldPickerPoint.X + offsetLocation.Item1,
                    oldPickerPoint.Y + offsetLocation.Item2);
            }

            foreach(var circle in this.relatedCircles)
            {
                this.circleService.EraseTrackingCircle(circle);
                circle.Origin = new Point(circle.Origin.X + offsetLocation.Item1, circle.Origin.Y + offsetLocation.Item2);
                this.circleService.CreateTrackingCircle(circle);
            }

            this.memoryService.LineService.PictureBox.Invalidate();

            lastLocation = newLocation;
        }

        private void StopTracking(object sender, MouseEventArgs e)
        {
            this.MouseUp -= StopTracking;
            this.MouseMove -= Tracking;
            this.MouseDown += BeginTracking;

   

            foreach(var line in this.memoryService.SelectedPolygon.Edges)
            {
                this.memoryService.LineService.CreateLine(line);
            }

            foreach (var circle in this.relatedCircles)
            {
                this.circleService.CreateCircle(circle);
            }

            this.memoryService.LineService.StopTrackingNoDrawing();
            this.circleService.StopTrackingNoDrawing();
        }
    }
}
