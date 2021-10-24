using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RasterPaint.VertexPickers
{
    public class CircleMover : VertexPicker
    {
        private CircleService circleService;
        private Point lastLocation;

        public CircleMover(Point Origin, CircleService circleService, int index) : base(Origin, index)
        {
            this.MouseDown += BeginTracking;
            this.circleService = circleService;
        }

        private void BeginTracking(object sender, MouseEventArgs e)
        {
            this.MouseDown -= BeginTracking;
            this.MouseUp += StopTracking;
            this.MouseMove += Tracking;
            lastLocation = this.Location;

            this.circleService.BeginTrackingNoUpdate();
            this.circleService.EraseCircle(this.circleService.MemoryService.SelectedCircle);            
           
        }

        private void Tracking(object sender, MouseEventArgs e)
        {
            var globalEventLocation = this.PointToScreen(e.Location);
            var globalPictureBoxLocation = this.circleService.MemoryService.LineService.PictureBox.PointToScreen(new Point(0, 0));


            var newLocation = new Point(globalEventLocation.X - globalPictureBoxLocation.X - PickerSize.Width / 2,
                globalEventLocation.Y - globalPictureBoxLocation.Y - PickerSize.Height / 2);


            var currCircle = this.circleService.MemoryService.SelectedCircle;
            this.circleService.EraseTrackingCircle(currCircle);

            currCircle.Origin = new Point(globalEventLocation.X - globalPictureBoxLocation.X,
                globalEventLocation.Y - globalPictureBoxLocation.Y); ;

            this.circleService.CreateTrackingCircle(currCircle.Origin.X, currCircle.Origin.Y, currCircle.Radius);

            this.Location = newLocation;

            this.circleService.MemoryService.LineService.PictureBox.Invalidate();

            lastLocation = newLocation;
        }

        private void StopTracking(object sender, MouseEventArgs e)
        {
            this.MouseUp -= StopTracking;
            this.MouseMove -= Tracking;
            this.MouseDown += BeginTracking;

            var currCircle = this.circleService.MemoryService.SelectedCircle;
            this.circleService.CreateCircle(currCircle);

            this.circleService.StopTrackingNoDrawing();

        }
    }
}
