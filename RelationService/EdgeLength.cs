using RasterPaint.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RasterPaint
{
    public class EdgeLength : RelationBase
    {
        public MemoryService MemoryService { get; set; }

        public EdgeLength(MemoryService memoryService, Line edgeTarget, Polygon polygon, bool IsFromOtherEdge = false)
        {
            MemoryService = memoryService;
            EdgeTarget = edgeTarget;
            PolygonTarget = polygon;
            Type = IsFromOtherEdge ? Relation.SameLength : Relation.ExactLength;
        }

        public void SetEdgeLength(Polygon polygon, int index, int pixelValue)
        {
            var line = polygon.Edges[index];
            var prevIndex = index == 0 ? polygon.Edges.Count - 1 : index - 1;
            var nextIndex = index == polygon.Edges.Count - 1 ? 0 : index + 1;

            //MemoryService.LineService.EraseLine(polygon.Edges[prevIndex]);
            MemoryService.LineService.EraseLine(polygon.Edges[index]);
            //MemoryService.LineService.EraseLine(polygon.Edges[nextIndex]);

            var midPoint = line.EvaluateMidPoint();

            // we need at least one distance so we can replace it
            var currDist = Math.Max(Utils.CalculateDistance(line.Points[0], line.Points[1]), 1);

            var smallTriangleHypo = (Math.Abs(currDist - pixelValue)) / 2;

            var smallTriangleHeight = (line.Points[1].Y - line.Points[0].Y) * smallTriangleHypo / currDist;

            var smallTriangleBase = (line.Points[1].X - line.Points[0].X) * smallTriangleHypo / currDist;

            if (currDist < pixelValue)
            {
                smallTriangleBase *= -1;
                smallTriangleHeight *= -1;
            }

            var firstPoint = new Point();
            var secPoint = new Point();

            firstPoint.X = line.Points[0].X + smallTriangleBase;
            secPoint.X = line.Points[1].X - smallTriangleBase;


            firstPoint.Y = line.Points[0].Y + smallTriangleHeight;
            secPoint.Y = line.Points[1].Y- smallTriangleHeight;
 

            var newLine = new Line();
            newLine.AppendPoint(firstPoint);
            newLine.AppendPoint(secPoint);

            var offsetBottom = (
                newLine.Points[0].X - polygon.Edges[index].Points[0].X,
                newLine.Points[0].Y - polygon.Edges[index].Points[0].Y
                );
            var offsetTop = (
                newLine.Points[1].X - polygon.Edges[index].Points[1].X,
                newLine.Points[1].Y - polygon.Edges[index].Points[1].Y
                );

            polygon.Edges[index] = newLine;

            //polygon.Edges[prevIndex].Points[1] = firstPoint;
            //polygon.Edges[nextIndex].Points[0] = secPoint;

            polygon.Vertices[index] = firstPoint;
            polygon.Vertices[nextIndex] = secPoint;

            //MemoryService.LineService.CreateLine(polygon.Edges[prevIndex]);
            MemoryService.LineService.CreateLine(polygon.Edges[index]);
            //MemoryService.LineService.CreateLine(polygon.Edges[nextIndex]);

            polygon.Edges[index].Relation = Relation.ExactLength;
            polygon.Edges[prevIndex].HasNeighbouringRelation = true;
            polygon.Edges[nextIndex].HasNeighbouringRelation = true;

            this.MemoryService.form.RelationService.FirstOfRelatedRelation = null;
            this.MemoryService.form.RelationService.MoveRelatedEdgesByOffset(polygon, index, offsetBottom, offsetTop);


            this.MemoryService.LineService.PictureBox.Invalidate();

            this.MemoryService.ExitVertexPickersMode();

            if (this.Type == Relation.ExactLength)
                this.MemoryService.EnterExactLengthMode();
            else if (this.Type == Relation.SameLength)
                this.MemoryService.EnterSameLengthMode(true);

            EdgeTarget = newLine;

        }
    }
}
