using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RasterPaint.VertexPickers
{
    public class RadiusChanger : VertexPicker
    {
        private CircleService circleService;

        public RadiusChanger(Point Origin, CircleService circleService, int index) : base(Origin, index)
        {
            this.MouseDown += BeginTracking;
            this.circleService = circleService;
        }

        private void BeginTracking(object sender, MouseEventArgs e)
        {
            this.MouseDown -= BeginTracking;
            this.MouseUp += StopTracking;
            this.circleService.CurrentCircle = this.circleService.MemoryService.SelectedCircle;
            this.circleService.Origin = this.circleService.MemoryService.SelectedCircle.Origin;
            this.MouseMove += this.Tracking;

            this.circleService.StartTrackingTangency(this.circleService.CurrentCircle);

            this.circleService.MemoryService.LineService.BeginTrackingNoUpdate();
            this.circleService.BeginTrackingFromGivenBmp(this.circleService.MemoryService.LineService.TrackingBmp);
            this.circleService.EraseCircle(this.circleService.MemoryService.SelectedCircle);

         

        }

        private void Tracking(object sender, MouseEventArgs e)
        {
            var globalEventLocation = this.PointToScreen(e.Location);
            var globalPictureBoxLocation = this.circleService.MemoryService.LineService.PictureBox.PointToScreen(new Point(0, 0));


            var newLocation = new Point(globalEventLocation.X - globalPictureBoxLocation.X - PickerSize.Width / 2,
                globalEventLocation.Y - globalPictureBoxLocation.Y - PickerSize.Height / 2);


            this.Location = newLocation;
            this.circleService.Tracking(sender, new MouseEventArgs(MouseButtons.Left, 1, 
                newLocation.X + PickerSize.Width / 2, 
                newLocation.Y + PickerSize.Height / 2, 0));

            if (this.circleService.CurrentCircle.TangentRelation != Enums.Relation.None)
            {
                this.circleService.FixTrackingTangency(this.circleService.CurrentCircle);
            }
        }

        private void StopTracking(object sender, MouseEventArgs e)
        {
            this.MouseUp -= StopTracking;
            this.MouseMove -= Tracking;
            this.MouseDown += BeginTracking;

            this.circleService.MemoryService.SelectedCircle.Radius = this.circleService.CurrentCircle.Radius;
            var currCircle = this.circleService.MemoryService.SelectedCircle;

            this.circleService.CreateCircle(currCircle);

            this.circleService.FinishTrackingTangency(this.circleService.CurrentCircle);

            this.circleService.StopTrackingNoDrawing();

        }
    }
}
