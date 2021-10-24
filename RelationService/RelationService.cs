using RasterPaint.Enums;
using RasterPaint.VertexPickers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RasterPaint
{
    public class RelationService
    {
        public MemoryService MemoryService { get; set; }
        public CircleService CircleService { get; set; }
        public NumericUpDown LengthInput { get; set; }

        public bool IsDeletingModeOn { get; set; }

        public List<RelationBase> RelationHandlers = new List<RelationBase>();

        public List<RelationPicker> RelationPickers = new List<RelationPicker>();

        public RelationBase FirstOfRelatedRelation { get; set; }

        public RelationService(MemoryService memoryService, NumericUpDown lengthInput, CircleService circleService)
        {
            MemoryService = memoryService;
            CircleService = circleService;
            LengthInput = lengthInput;
        }

        public void InvokeExactLength(Polygon polygon, int index)
        {
            var relationHandler = new EdgeLength(MemoryService, polygon.Edges[index], polygon);
            this.RelationHandlers.Add(relationHandler);
            var relIdx = this.RelationHandlers.Count - 1;

            var relationPicker = new RelationPicker(polygon.Edges[index].EvaluateMidPoint(), relIdx, this, "L");

            this.RelationPickers.Add(relationPicker);
            this.MemoryService.LineService.PictureBox.Controls.Add(relationPicker);

            relationHandler.SetEdgeLength(polygon, index, Convert.ToInt32(LengthInput.Value));
        }

        public void InvokeRadiusLength(Circle circle, int index)
        {
            var relationHandler = new RadiusLength(CircleService, circle);
            this.RelationHandlers.Add(relationHandler);
            var relIdx = this.RelationHandlers.Count - 1;

            var relationPicker = new RelationPicker(circle.Origin, relIdx, this, "R");

            this.RelationPickers.Add(relationPicker);
            this.MemoryService.LineService.PictureBox.Controls.Add(relationPicker);

            relationHandler.SetRadiusLength(index, Convert.ToInt32(LengthInput.Value));

            if (relationHandler.CircleTarget.TangentRelation != Relation.None)
            {
                var tangentRelation = this.RelationHandlers.Find(r => r.CircleTarget == relationHandler.CircleTarget && r.Type == Relation.Tangency);
                (tangentRelation.RelatedRelation as Tangency)
                    .SetTangency(tangentRelation.RelatedRelation.PolygonTarget,
                    tangentRelation.RelatedRelation.PolygonTarget.Edges.FindIndex(e => e == tangentRelation.RelatedRelation.EdgeTarget),
                    tangentRelation.CircleTarget, false);
            }


        }

        public void InvokeSameLengthFirst(Polygon polygon, int index)
        {
            var relationHandler = new FirstRelatedRelation(this, polygon.Edges[index], polygon);
            this.RelationHandlers.Add(relationHandler);
            var relIdx = this.RelationHandlers.Count - 1;

            var relationPicker = new RelationPicker(polygon.Edges[index].EvaluateMidPoint(), relIdx, this, "S");

            this.RelationPickers.Add(relationPicker);
            this.MemoryService.LineService.PictureBox.Controls.Add(relationPicker);

            relationHandler.Type = Relation.SameLength;
            polygon.Edges[index].Relation = Relation.SameLength;
            relationHandler.FirstRelatedEdge(polygon, index);
            this.MemoryService.EnterSameLengthMode(false);
        }

        public void InvokeSameLengthSecond(Polygon polygon, int index)
        {
            var relationHandler = new EdgeLength(MemoryService, polygon.Edges[index], polygon, true);

            relationHandler.RelatedRelation = this.FirstOfRelatedRelation;
            relationHandler.RelatedRelation.RelatedRelation = relationHandler;

            this.RelationHandlers.Add(relationHandler);
            var relIdx = this.RelationHandlers.Count - 1;

            var relationPicker = new RelationPicker(polygon.Edges[index].EvaluateMidPoint(), relIdx, this, "S");

            this.RelationPickers.Add(relationPicker);
            this.MemoryService.LineService.PictureBox.Controls.Add(relationPicker);

            relationHandler.SetEdgeLength(polygon, index, Utils.CalculateDistance(relationHandler.RelatedRelation.EdgeTarget.Points[0], 
                relationHandler.RelatedRelation.EdgeTarget.Points[1]));

            this.FirstOfRelatedRelation = null;
        }

        public void InvokePerpendicularityFirst(Polygon polygon, int index)
        {
            var relationHandler = new FirstRelatedRelation(this, polygon.Edges[index], polygon);
            this.RelationHandlers.Add(relationHandler);
            var relIdx = this.RelationHandlers.Count - 1;

            var relationPicker = new RelationPicker(polygon.Edges[index].EvaluateMidPoint(), relIdx, this, "P");

            this.RelationPickers.Add(relationPicker);
            this.MemoryService.LineService.PictureBox.Controls.Add(relationPicker);

            relationHandler.Type = Relation.Perpendicularity;
            polygon.Edges[index].Relation = Relation.Perpendicularity;
            relationHandler.FirstRelatedEdge(polygon, index);
            this.MemoryService.EnterPerpendicularityMode(false);
        }

        public void InvokePerpendicularitySecond(Polygon polygon, int index)
        {
            var relationHandler = new Perpendicularity(MemoryService, polygon.Edges[index], polygon);

            relationHandler.RelatedRelation = this.FirstOfRelatedRelation;
            relationHandler.RelatedRelation.RelatedRelation = relationHandler;

            this.RelationHandlers.Add(relationHandler);
            var relIdx = this.RelationHandlers.Count - 1;

            var relationPicker = new RelationPicker(polygon.Edges[index].EvaluateMidPoint(), relIdx, this, "P");

            this.RelationPickers.Add(relationPicker);
            this.MemoryService.LineService.PictureBox.Controls.Add(relationPicker);

            relationHandler.SetPerpendicularity(polygon, index, this.FirstOfRelatedRelation.EdgeTarget);

            this.FirstOfRelatedRelation = null;
        }

        public void InvokeTangencyFirst(Circle circle)
        {
            var relationHandler = new FirstRelatedRelation(this, circle);
            this.RelationHandlers.Add(relationHandler);
            var relIdx = this.RelationHandlers.Count - 1;

            var relationPicker = new RelationPicker(circle.Origin, relIdx, this, "T");

            this.RelationPickers.Add(relationPicker);
            this.MemoryService.LineService.PictureBox.Controls.Add(relationPicker);

            relationHandler.Type = Relation.Tangency;
            circle.TangentRelation = Relation.Tangency;
            relationHandler.FirstRelatedCircle();
            this.MemoryService.EnterTangencyMode(false);
        }

        public void InvokeTangencySecond(Polygon polygon, int index)
        {
            var relationHandler = new Tangency(this, polygon.Edges[index], polygon);

            relationHandler.RelatedRelation = this.FirstOfRelatedRelation;
            relationHandler.RelatedRelation.RelatedRelation = relationHandler;

            this.RelationHandlers.Add(relationHandler);
            var relIdx = this.RelationHandlers.Count - 1;

            var relationPicker = new RelationPicker(polygon.Edges[index].EvaluateMidPoint(), relIdx, this, "T");

            this.RelationPickers.Add(relationPicker);
            this.MemoryService.LineService.PictureBox.Controls.Add(relationPicker);

            relationHandler.SetTangency(polygon, index, this.FirstOfRelatedRelation.CircleTarget, false);

            this.MemoryService.ExitVertexPickersMode();
            this.MemoryService.EnterTangencyMode(true);

            this.FirstOfRelatedRelation = null;
        }

        public void DestroyRelation(int index)
        {
            var relationHandler = this.RelationHandlers[index];

            Polygon polygon;
            int edgeIndex, prevIndex, nextIndex, relatedIndex, relatedPrevIndex, relatedNextIndex, relatedRelationIdx;
            RelationPicker relationPicker = this.RelationPickers[this.RelationHandlers.FindIndex(r => r == relationHandler)];

            switch (relationHandler.Type)
            {
                case Relation.ExactLength:
                    relationHandler.EdgeTarget.Relation = Relation.None;
                    polygon = relationHandler.PolygonTarget;
                    edgeIndex = polygon.Edges.FindIndex(e => e == relationHandler.EdgeTarget);
                    prevIndex = edgeIndex == 0 ? polygon.Edges.Count - 1 : edgeIndex - 1;
                    nextIndex = edgeIndex == polygon.Edges.Count - 1 ? 0 : edgeIndex + 1;

                    polygon.Edges[prevIndex].HasNeighbouringRelation = false;
                    polygon.Edges[nextIndex].HasNeighbouringRelation = false;
                    break;
                case Relation.ExactRadius:
                    relationHandler.CircleTarget.LengthRelation = Relation.None;
                    break;
                case Relation.SameLength:
                case Relation.Perpendicularity:
                    relationHandler.EdgeTarget.Relation = Relation.None;
                    polygon = relationHandler.PolygonTarget;
                    edgeIndex = polygon.Edges.FindIndex(e => e == relationHandler.EdgeTarget);
                    prevIndex = edgeIndex == 0 ? polygon.Edges.Count - 1 : edgeIndex - 1;
                    nextIndex = edgeIndex == polygon.Edges.Count - 1 ? 0 : edgeIndex + 1;

                    polygon.Edges[prevIndex].HasNeighbouringRelation = false;
                    polygon.Edges[nextIndex].HasNeighbouringRelation = false;

                    relationHandler.RelatedRelation.EdgeTarget.Relation = Relation.None;
                    relatedIndex = relationHandler.RelatedRelation.PolygonTarget.Edges
                        .FindIndex(e => e == relationHandler.RelatedRelation.EdgeTarget);
                    relatedPrevIndex = relatedIndex == 0 ? 
                        relationHandler.RelatedRelation.PolygonTarget.Edges.Count - 1 : relatedIndex - 1;
                    relatedNextIndex = relatedIndex == relationHandler.RelatedRelation.PolygonTarget.Edges.Count - 1 ?
                        0 : relatedIndex + 1;

                    relationHandler.RelatedRelation.PolygonTarget.Edges[relatedPrevIndex].HasNeighbouringRelation = false;
                    relationHandler.RelatedRelation.PolygonTarget.Edges[relatedNextIndex].HasNeighbouringRelation = false;

                    relatedRelationIdx = this.RelationHandlers.FindIndex(r => r == relationHandler.RelatedRelation);
                    this.RelationHandlers.RemoveAt(relatedRelationIdx);
                    this.MemoryService.LineService.PictureBox.Controls.Remove(this.RelationPickers[relatedRelationIdx]);
                    this.RelationPickers.RemoveAt(relatedRelationIdx);          
                    break;
                case Relation.Tangency:
                    if (relationHandler.CircleTarget != null)
                    {
                        relationHandler.CircleTarget.TangentRelation = Relation.None;

                        relationHandler.RelatedRelation.EdgeTarget.Relation = Relation.None;
                        relatedIndex = relationHandler.RelatedRelation.PolygonTarget.Edges
                            .FindIndex(e => e == relationHandler.RelatedRelation.EdgeTarget);
                        relatedPrevIndex = relatedIndex == 0 ?
                            relationHandler.RelatedRelation.PolygonTarget.Edges.Count - 1 : relatedIndex - 1;
                        relatedNextIndex = relatedIndex == relationHandler.RelatedRelation.PolygonTarget.Edges.Count - 1 ?
                            0 : relatedIndex + 1;

                        relationHandler.RelatedRelation.PolygonTarget.Edges[relatedPrevIndex].HasNeighbouringRelation = false;
                        relationHandler.RelatedRelation.PolygonTarget.Edges[relatedNextIndex].HasNeighbouringRelation = false;
                    }
                    else
                    {
                        relationHandler.EdgeTarget.Relation = Relation.None;
                        polygon = relationHandler.PolygonTarget;
                        edgeIndex = polygon.Edges.FindIndex(e => e == relationHandler.EdgeTarget);
                        prevIndex = edgeIndex == 0 ? polygon.Edges.Count - 1 : edgeIndex - 1;
                        nextIndex = edgeIndex == polygon.Edges.Count - 1 ? 0 : edgeIndex + 1;

                        polygon.Edges[prevIndex].HasNeighbouringRelation = false;
                        polygon.Edges[nextIndex].HasNeighbouringRelation = false;

                        relationHandler.RelatedRelation.CircleTarget.TangentRelation = Relation.None;
                    }

                    relatedRelationIdx = this.RelationHandlers.FindIndex(r => r == relationHandler.RelatedRelation);
                    this.RelationHandlers.RemoveAt(relatedRelationIdx);
                    this.MemoryService.LineService.PictureBox.Controls.Remove(this.RelationPickers[relatedRelationIdx]);
                    this.RelationPickers.RemoveAt(relatedRelationIdx);
                    break;
            }
            this.RelationHandlers.Remove(relationHandler);
            this.MemoryService.LineService.PictureBox.Controls.Remove(relationPicker);
            this.RelationPickers.Remove(relationPicker);
        }

        public void AbortFirstRelatedRelation()
        {
            if (this.FirstOfRelatedRelation != null)
            {
                if (this.FirstOfRelatedRelation.EdgeTarget != null)
                {
                this.FirstOfRelatedRelation.EdgeTarget.Relation = Relation.None;
                var relatedIndex = this.FirstOfRelatedRelation.PolygonTarget.Edges
                    .FindIndex(e => e == this.FirstOfRelatedRelation.EdgeTarget);
                var relatedPrevIndex = relatedIndex == 0 ?
                    this.FirstOfRelatedRelation.PolygonTarget.Edges.Count - 1 : relatedIndex - 1;
                var relatedNextIndex = relatedIndex == this.FirstOfRelatedRelation.PolygonTarget.Edges.Count - 1 ?
                    0 : relatedIndex + 1;

                this.FirstOfRelatedRelation.PolygonTarget.Edges[relatedPrevIndex].HasNeighbouringRelation = false;
                this.FirstOfRelatedRelation.PolygonTarget.Edges[relatedNextIndex].HasNeighbouringRelation = false;
                }
                else if (this.FirstOfRelatedRelation.CircleTarget != null)
                {
                    this.FirstOfRelatedRelation.CircleTarget.TangentRelation = Relation.None;
                }

                var relatedRelationIdx = this.RelationHandlers.FindIndex(r => r == this.FirstOfRelatedRelation);
                this.RelationHandlers.RemoveAt(relatedRelationIdx);
                this.MemoryService.LineService.PictureBox.Controls.Remove(this.RelationPickers[relatedRelationIdx]);
                this.RelationPickers.RemoveAt(relatedRelationIdx);

                this.FirstOfRelatedRelation = null;
            }
        }

        public void AppendRelationsToView()
        {
            for (int i = 0; i < this.RelationHandlers.Count; i++)
            {
                if (this.RelationHandlers[i].CircleTarget != null)
                {
                    if (this.RelationHandlers[i].CircleTarget.TangentRelation != Relation.None
                        && this.RelationHandlers[i].Type == Relation.ExactRadius)
                    {
                        this.RelationPickers[i].SetLocation(this.RelationHandlers[i].CircleTarget.Origin);
                        this.RelationPickers[i].MoveUp();
                    }
                    else
                    {
                        this.RelationPickers[i].SetLocation(this.RelationHandlers[i].CircleTarget.Origin);
                    }
                    
                }
                else if (this.RelationHandlers[i].EdgeTarget != null)
                {
                    this.RelationPickers[i].SetLocation(this.RelationHandlers[i].EdgeTarget.EvaluateMidPoint());
                }

                this.MemoryService.LineService.PictureBox.Controls.Add(this.RelationPickers[i]);
            }

            this.MemoryService.LineService.PictureBox.Invalidate();
        }

        public void RemoveRelationsFromView()
        {
            this.AbortFirstRelatedRelation();
            foreach (var relationPicker in this.RelationPickers)
            {
                this.MemoryService.LineService.PictureBox.Controls.Remove(relationPicker);
            }
        }

        public void FixVertexPickerIndexing()
        {
            int idx = 0;
            foreach(var relationPicker in this.RelationPickers)
            {
                relationPicker.Index = idx++;
            }
        }

        public void DestroyRelationOfEdge(Line edge)
        {
            var relIdx = this.RelationHandlers.FindIndex(r => r.EdgeTarget == edge);
            if (relIdx >= 0)
            {
                this.DestroyRelation(relIdx);
            }
        }

        public List<Circle> GetPolygonRelatedCircles(Polygon polygon)
        {
            var circleList = new List<Circle>();

            foreach (var relationHandler in this.RelationHandlers)
            {
                if (relationHandler.PolygonTarget == polygon && relationHandler.Type == Relation.Tangency)
                {
                    circleList.Add(relationHandler.RelatedRelation.CircleTarget);
                }
            }

            return circleList;
        }

        public Circle GetEdgeRelatedCircle(Line edge)
        {

            foreach (var relationHandler in this.RelationHandlers)
            {
                if (relationHandler.EdgeTarget == edge && relationHandler.Type == Relation.Tangency)
                {
                    return relationHandler.RelatedRelation.CircleTarget;
                }
            }

            return null;
        }

        public void MoveRelatedEdgesByOffset(Polygon polygon, int startingIdx, (int, int) offsetBottom, (int, int) offsetTop)
        {
            int nextIdx = (startingIdx + 1) % polygon.Edges.Count;

            while (nextIdx != startingIdx)
            {
                if (polygon.Edges[nextIdx].Relation != Relation.None)
                {
                    this.MemoryService.LineService.EraseLine(polygon.Edges[nextIdx]);

                    polygon.Edges[nextIdx].Points[0] = new Point(
                        polygon.Edges[nextIdx].Points[0].X + offsetTop.Item1,
                        polygon.Edges[nextIdx].Points[0].Y + offsetTop.Item2);

                    polygon.Edges[nextIdx].Points[1] = new Point(
                        polygon.Edges[nextIdx].Points[1].X + offsetTop.Item1,
                        polygon.Edges[nextIdx].Points[1].Y + offsetTop.Item2);

                    polygon.Vertices[nextIdx] = polygon.Edges[nextIdx].Points[0];

                    this.MemoryService.LineService.CreateLine(polygon.Edges[nextIdx]);

                    nextIdx = (nextIdx + 1) % polygon.Edges.Count;
                }
                else
                {
                    this.MemoryService.LineService.EraseLine(polygon.Edges[nextIdx]);

                    polygon.Edges[nextIdx].Points[0] = new Point(
                        polygon.Edges[nextIdx].Points[0].X + offsetTop.Item1,
                        polygon.Edges[nextIdx].Points[0].Y + offsetTop.Item2);

                    polygon.Vertices[nextIdx] = polygon.Edges[nextIdx].Points[0];

                    this.MemoryService.LineService.CreateLine(polygon.Edges[nextIdx]);
                    break;
                }
            }

            int prevIdx = startingIdx > 0 ? startingIdx - 1 : polygon.Edges.Count -1;
            while (prevIdx != startingIdx)
            {
                if (polygon.Edges[prevIdx].Relation != Relation.None)
                {
                    this.MemoryService.LineService.EraseLine(polygon.Edges[prevIdx]);

                    polygon.Edges[prevIdx].Points[0] = new Point(
                        polygon.Edges[prevIdx].Points[0].X + offsetBottom.Item1,
                        polygon.Edges[prevIdx].Points[0].Y + offsetBottom.Item2);

                    polygon.Edges[prevIdx].Points[1] = new Point(
                        polygon.Edges[prevIdx].Points[1].X + offsetBottom.Item1,
                        polygon.Edges[prevIdx].Points[1].Y + offsetBottom.Item2);

                    polygon.Vertices[prevIdx] = polygon.Edges[prevIdx].Points[0];

                    this.MemoryService.LineService.CreateLine(polygon.Edges[prevIdx]);

                    prevIdx = prevIdx > 0 ? prevIdx - 1 : polygon.Edges.Count - 1;
                }
                else
                {
                    this.MemoryService.LineService.EraseLine(polygon.Edges[prevIdx]);

                    polygon.Edges[prevIdx].Points[1] = new Point(
                        polygon.Edges[prevIdx].Points[1].X + offsetBottom.Item1,
                        polygon.Edges[prevIdx].Points[1].Y + offsetBottom.Item2);

                    polygon.Vertices[prevIdx] = polygon.Edges[prevIdx].Points[1];

                    this.MemoryService.LineService.CreateLine(polygon.Edges[prevIdx]);
                    break;
                }
            }

            this.RemoveRelationsFromView();
            this.AppendRelationsToView();
        }
    }
}
