﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RasterPaint.VertexPickers
{
    public class SameLengthPicker : VertexPicker
    {
        private MemoryService memoryService;

        private Polygon polygon;

        private RelationService relationService;

        public SameLengthPicker(Point Origin, MemoryService memoryService, int index, RelationService relationService, Polygon polygon, bool IsFirst) : base(Origin, index)
        {
            this.memoryService = memoryService;
            this.relationService = relationService;
            this.polygon = polygon;
            if (IsFirst)
            {
                this.MouseClick += InvokeFirstRelation;
            }
            else
            {
                this.MouseClick += InvokeSecondRelation;
            }
        }

        public void InvokeFirstRelation(object sender, MouseEventArgs e)
        {
            this.relationService.InvokeSameLengthFirst(polygon, Index);
        }

        public void InvokeSecondRelation(object sender, MouseEventArgs e) 
        {
            this.relationService.InvokeSameLengthSecond(polygon, Index);
        }
    }
}
