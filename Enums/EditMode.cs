using System;
using System.Collections.Generic;
using System.Text;

namespace RasterPaint
{
    public enum EditMode
    {
        Default = 0,
        AddPolygon,
        MoveVertice,
        DeleteVertice,
        AddVertice,
        MoveEdge,
        MovePolygon,
        AddCircle,
        MoveCircle,
        ChangeRadius
    }
}
