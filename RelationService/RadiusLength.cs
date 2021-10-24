using RasterPaint.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RasterPaint
{
    public class RadiusLength : RelationBase
    {
        public CircleService CircleService { get; set; }

        public RadiusLength(CircleService circleService, Circle circleTarget)
        {
            CircleService = circleService;
            CircleTarget = circleTarget;
            Type = Relation.ExactRadius;
        }

        public void SetRadiusLength(int index, int pixelValue)
        {
            this.CircleService.EraseCircle(CircleTarget);

            CircleTarget.Radius = pixelValue;
            CircleTarget.LengthRelation = Relation.ExactRadius;

            this.CircleService.CreateCircle(CircleTarget);

            this.CircleService.MemoryService.LineService.PictureBox.Invalidate();

            this.CircleService.MemoryService.ExitVertexPickersMode();
            this.CircleService.MemoryService.EnterRadiusLengthMode();

        }
    }
}
