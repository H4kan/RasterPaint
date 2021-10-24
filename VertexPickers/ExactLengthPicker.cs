using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RasterPaint.VertexPickers
{
    public class ExactLengthPicker : VertexPicker
    {
        private MemoryService memoryService;

        private Polygon polygon;

        private RelationService relationService;

        public ExactLengthPicker(Point Origin, MemoryService memoryService, int index, RelationService relationService, Polygon polygon) : base(Origin, index)
        {
            this.memoryService = memoryService;
            this.relationService = relationService;
            this.polygon = polygon;
            this.MouseClick += InvokeRelation;
        }

        public void InvokeRelation(object sender, MouseEventArgs e)
        {
            this.relationService.InvokeExactLength(polygon, Index);
        }
    }
}
