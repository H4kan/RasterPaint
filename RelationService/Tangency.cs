using RasterPaint.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RasterPaint
{
    public class Tangency : RelationBase
    {
        public RelationService RelationService { get; set; }

        public Tangency(RelationService relationService, Line edgeTarget, Polygon polygon)
        {
            RelationService = relationService;
            EdgeTarget = edgeTarget;
            PolygonTarget = polygon;
            Type = Relation.Tangency;
        }

        public void SetTangency(Polygon polygon, int index, Circle relatedCircle, bool toTracking)
        {

            var edge = polygon.Edges[index];

            //var prevIndex = index == 0 ? polygon.Edges.Count - 1 : index - 1;
            //var nextIndex = index == polygon.Edges.Count - 1 ? 0 : index + 1;

            if (toTracking)
            {
                //RelationService.MemoryService.LineService.EraseTrackingLine(polygon.Edges[prevIndex]);
                RelationService.MemoryService.LineService.EraseTrackingLine(polygon.Edges[index]);
                //RelationService.MemoryService.LineService.EraseTrackingLine(polygon.Edges[nextIndex]);
            }
            else
            {
                //RelationService.MemoryService.LineService.EraseLine(polygon.Edges[prevIndex]);
                RelationService.MemoryService.LineService.EraseLine(polygon.Edges[index]);
                //RelationService.MemoryService.LineService.EraseLine(polygon.Edges[nextIndex]);
            }
           

            Point pointAfterOnCircle = new Point(), pointBeforeOnCircle = new Point();

            var midPoint = edge.EvaluateMidPoint();

            if (edge.Points[1].Y == edge.Points[0].Y)
            {
                pointBeforeOnCircle = new Point(relatedCircle.Origin.X, relatedCircle.Origin.Y - relatedCircle.Radius);
                pointAfterOnCircle = new Point(relatedCircle.Origin.X, relatedCircle.Origin.Y + relatedCircle.Radius);
            }
            else
            {
                // tangent of perpendicular line
                var a = (edge.Points[0].X - edge.Points[1].X) / ((double)(edge.Points[1].Y - edge.Points[0].Y));

                // unit vector is [1, a]

                var vecRatio = relatedCircle.Radius / Math.Sqrt(a * a + 1);

                pointAfterOnCircle = new Point(Convert.ToInt32(Math.Round(relatedCircle.Origin.X + vecRatio)), Convert.ToInt32(Math.Round(relatedCircle.Origin.Y + vecRatio * a)));
                pointBeforeOnCircle = new Point(Convert.ToInt32(Math.Round(relatedCircle.Origin.X - vecRatio)), Convert.ToInt32(Math.Round(relatedCircle.Origin.Y - vecRatio * a)));

            }

            var pointOnCircle = Utils.CalculateDistance(pointBeforeOnCircle, midPoint) < Utils.CalculateDistance(pointAfterOnCircle, midPoint) ?
                pointBeforeOnCircle : pointAfterOnCircle;



            var vecToMoveEdge = (pointOnCircle.X - midPoint.X, pointOnCircle.Y - midPoint.Y);

            edge.Points[0] = new Point(edge.Points[0].X + vecToMoveEdge.Item1, edge.Points[0].Y + vecToMoveEdge.Item2);
            edge.Points[1] = new Point(edge.Points[1].X + vecToMoveEdge.Item1, edge.Points[1].Y + vecToMoveEdge.Item2);


            //polygon.Edges[prevIndex].Points[1] = edge.Points[0];
            //polygon.Edges[nextIndex].Points[0] = edge.Points[1];

            //polygon.Vertices[index] = edge.Points[0];
            //polygon.Vertices[nextIndex] = edge.Points[1];

            if (toTracking)
            {
                //RelationService.MemoryService.LineService.CreateTrackingLine(polygon.Edges[prevIndex]);
                RelationService.MemoryService.LineService.CreateTrackingLine(polygon.Edges[index]);
                //RelationService.MemoryService.LineService.CreateTrackingLine(polygon.Edges[nextIndex]);

            }
            else
            {
                //RelationService.MemoryService.LineService.CreateLine(polygon.Edges[prevIndex]);
                RelationService.MemoryService.LineService.CreateLine(polygon.Edges[index]);
                //RelationService.MemoryService.LineService.CreateLine(polygon.Edges[nextIndex]);

            }


            polygon.Edges[index].Relation = Relation.Tangency;
            //polygon.Edges[prevIndex].HasNeighbouringRelation = true;
            //polygon.Edges[nextIndex].HasNeighbouringRelation = true;

            this.RelationService.FirstOfRelatedRelation = null;
            this.RelationService.MoveRelatedEdgesByOffset(polygon, index, vecToMoveEdge, vecToMoveEdge);

            RelationService.MemoryService.LineService.PictureBox.Invalidate();



            var relIdx = RelationService.RelationHandlers.FindIndex(r => r == this);

            RelationService.RelationPickers[relIdx].SetLocation(polygon.Edges[index].EvaluateMidPoint());

        }
    }
}
