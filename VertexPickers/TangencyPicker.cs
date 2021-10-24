using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RasterPaint.VertexPickers
{
    public class TangencyPicker : VertexPicker
    {
        private MemoryService memoryService;

        private Polygon polygon;

        private Circle circle;

        private RelationService relationService;

        public TangencyPicker(Point Origin, MemoryService memoryService, int index, RelationService relationService, Polygon polygon) : base(Origin, index)
        {
            this.memoryService = memoryService;
            this.relationService = relationService;
            this.polygon = polygon;
            this.MouseClick += InvokeSecondRelation;
        }

        public TangencyPicker(Point Origin, MemoryService memoryService, int index, RelationService relationService, Circle circle) : base(Origin, index)
        {
            this.memoryService = memoryService;
            this.relationService = relationService;
            this.circle = circle;
            this.MouseClick += InvokeFirstRelation;
        }

        public void InvokeFirstRelation(object sender, MouseEventArgs e)
        {
            this.relationService.InvokeTangencyFirst(circle);
        }

        public void InvokeSecondRelation(object sender, MouseEventArgs e)
        {
            this.relationService.InvokeTangencySecond(polygon, Index);
        }
    }
}
