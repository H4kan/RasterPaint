using RasterPaint.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RasterPaint
{
    public class Perpendicularity : RelationBase
    {
        public MemoryService MemoryService { get; set; }

        public Perpendicularity(MemoryService memoryService, Line edgeTarget, Polygon polygon)
        {
            MemoryService = memoryService;
            EdgeTarget = edgeTarget;
            PolygonTarget = polygon;
            Type = Relation.Perpendicularity;
        }

        public void SetPerpendicularity(Polygon polygon, int index, Line relatedEdge)
        {

            var edge = polygon.Edges[index];

            //var prevIndex = index == 0 ? polygon.Edges.Count - 1 : index - 1;
            //var nextIndex = index == polygon.Edges.Count - 1 ? 0 : index + 1;

            //MemoryService.LineService.EraseLine(polygon.Edges[prevIndex]);
            MemoryService.LineService.EraseLine(polygon.Edges[index]);
            //MemoryService.LineService.EraseLine(polygon.Edges[nextIndex]);

            var currDist = Math.Max(Utils.CalculateDistance(edge.Points[0], edge.Points[1]), 1);

            Point firstPoint = new Point(), secPoint = new Point();

            var midPoint = edge.EvaluateMidPoint();

            if (relatedEdge.Points[0].Y == relatedEdge.Points[1].Y)
            {
                firstPoint = new Point(midPoint.X, midPoint.Y + currDist / 2);

                secPoint = new Point(midPoint.X, midPoint.Y - currDist / 2);
            }
            else
            {
                // tangent of perpendicular line
                var a = (relatedEdge.Points[0].X - relatedEdge.Points[1].X) / ((double)(relatedEdge.Points[1].Y - relatedEdge.Points[0].Y));

                // unit vector is [1, a]

                var vecRatio = currDist / (2 * Math.Sqrt(a * a + 1));

 

                firstPoint = new Point(Convert.ToInt32(Math.Round(midPoint.X + vecRatio)), Convert.ToInt32(Math.Round(midPoint.Y + vecRatio * a)));

                secPoint = new Point(Convert.ToInt32(Math.Round(midPoint.X - vecRatio)), Convert.ToInt32(Math.Round(midPoint.Y - vecRatio * a)));
            }

            (int, int) offsetBottom, offsetTop;

            if (Utils.CalculateDistance(edge.Points[0], firstPoint) < Utils.CalculateDistance(edge.Points[0], secPoint))
            {
                offsetBottom = (firstPoint.X - edge.Points[0].X, firstPoint.Y - edge.Points[0].Y);
                offsetTop = (secPoint.X - edge.Points[1].X, secPoint.Y - edge.Points[1].Y);
                edge.Points[0] = firstPoint;
                edge.Points[1] = secPoint;
            }
            else
            {
                offsetBottom = (secPoint.X - edge.Points[0].X, secPoint.Y - edge.Points[0].Y);
                offsetTop = (firstPoint.X - edge.Points[1].X, firstPoint.Y - edge.Points[1].Y);
                edge.Points[1] = firstPoint;
                edge.Points[0] = secPoint;
            }


            //polygon.Edges[prevIndex].Points[1] = edge.Points[0];
            //polygon.Edges[nextIndex].Points[0] = edge.Points[1];

            //polygon.Vertices[index] = edge.Points[0];
            //polygon.Vertices[nextIndex] = edge.Points[1];

            //MemoryService.LineService.CreateLine(polygon.Edges[prevIndex]);
            MemoryService.LineService.CreateLine(polygon.Edges[index]);
            //MemoryService.LineService.CreateLine(polygon.Edges[nextIndex]);

            polygon.Edges[index].Relation = Relation.Perpendicularity;
            //polygon.Edges[prevIndex].HasNeighbouringRelation = true;
            //polygon.Edges[nextIndex].HasNeighbouringRelation = true;

            this.MemoryService.form.RelationService.FirstOfRelatedRelation = null;
            this.MemoryService.form.RelationService.MoveRelatedEdgesByOffset(polygon, index, offsetBottom, offsetTop);

            this.MemoryService.LineService.PictureBox.Invalidate();

            this.MemoryService.ExitVertexPickersMode();

            this.MemoryService.EnterPerpendicularityMode(true);


        }
    }
}
