using RasterPaint.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RasterPaint
{
    public class RelationBase
    {
        public Relation Type { get; set; }

        public Line EdgeTarget { get; set; }

        public Circle CircleTarget { get; set; }

        public Polygon PolygonTarget { get; set; }

        public RelationBase RelatedRelation { get; set; }

    }
}
