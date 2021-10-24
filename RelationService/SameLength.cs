using RasterPaint.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RasterPaint
{
    public class FirstRelatedRelation : RelationBase
    {
        public RelationService RelationService { get; set; }

        public FirstRelatedRelation(RelationService relationService, Line edgeTarget, Polygon polygon)
        {
            RelationService = relationService;
            EdgeTarget = edgeTarget;
            PolygonTarget = polygon;
        }

        public FirstRelatedRelation(RelationService relationService, Circle circle)
        {
            RelationService = relationService;
            CircleTarget = circle;
        }

        public void FirstRelatedEdge(Polygon polygon, int index)
        {
            this.RelationService.FirstOfRelatedRelation = this;

            var prevIndex = index == 0 ? polygon.Edges.Count - 1 : index - 1;
            var nextIndex = index == polygon.Edges.Count - 1 ? 0 : index + 1;

            polygon.Edges[prevIndex].HasNeighbouringRelation = true;
            polygon.Edges[nextIndex].HasNeighbouringRelation = true;

            this.RelationService.MemoryService.ExitVertexPickersMode();
           
        }

        public void FirstRelatedCircle()
        {
            this.RelationService.FirstOfRelatedRelation = this;

            this.RelationService.MemoryService.ExitVertexPickersMode();

        }
    }
}
