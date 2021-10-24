using RasterPaint.VertexPickers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using RasterPaint.Enums;

namespace RasterPaint
{
    public class MemoryService
    {
        public List<Polygon> Polygons;

        public List<Circle> Circles;

        public Polygon SelectedPolygon { get; set; }

        public Circle SelectedCircle { get; set; }

        public List<VertexPicker> VertexPickers = new List<VertexPicker>();

        public List<VertexPicker> RelationPickers = new List<VertexPicker>();

        GroupBox polygonActionsBox;
        ListView polygonListBox;

        GroupBox circleActionsBox;
        ListView circleListBox;

        GroupBox relationBox;

        PictureBox pictureBox;
        public Form1 form;
        public LineService LineService { get; set; }

        public MemoryService(
            GroupBox polygonActionsBox,
            ListView polygonListBox,
            GroupBox circleActionsBox,
            ListView circleListBox,
            GroupBox relationBox,
            PictureBox pictureBox,
            LineService lineService, 
            Form1 form)
        {
            Circles = new List<Circle>();
            Polygons = new List<Polygon>();

            this.polygonListBox = polygonListBox;
            this.polygonActionsBox = polygonActionsBox;

            this.circleActionsBox = circleActionsBox;
            this.circleListBox = circleListBox;

            this.relationBox = relationBox;

            this.pictureBox = pictureBox;
            this.LineService = lineService;
            this.form = form;
        }

        public void ShowPolygonOptions()
        {
            polygonActionsBox.Visible = true;
        }

        public void ExitPolygonOptions()
        {
            polygonActionsBox.Visible = false;
        
            this.SelectedPolygon = null;
            this.polygonListBox.SelectedIndices.Clear();
            this.polygonListBox.Items.Clear();
            int idx = 1;
            foreach (var polygon in this.Polygons)
            {
                this.polygonListBox.Items.Add(new ListViewItem() { Text = $"p_{idx}", Name = $"p_{idx}" });
                idx++;
            }

        }

        public void ShowCircleOptions() 
        {
            circleActionsBox.Visible = true;
        }

        public void ExitCircleOptions()
        {
            circleActionsBox.Visible = false;
            this.SelectedCircle = null;
            this.circleListBox.SelectedIndices.Clear();
            // regenerating in case of destruction
            this.circleListBox.Items.Clear();
            int idx = 1;
            foreach (var circle in this.Circles)
            {
                this.circleListBox.Items.Add(new ListViewItem() { Text = $"c_{idx}", Name = $"c_{idx}" });
                idx++;
            }

        }

        public void ShowRelationOptions()
        {
            relationBox.Visible = true;
            this.form.RelationService.AppendRelationsToView();
        }

        public void ExitRelationOptions()
        {
            relationBox.Visible = false;
            this.form.RelationService.RemoveRelationsFromView();
        }

        public void EnterMoveVerticeMode()
        {        
            int idx = 0;
            foreach (var vertice in SelectedPolygon.Vertices)
            {
                if (SelectedPolygon.Edges[idx == 0 ? SelectedPolygon.Edges.Count - 1 : idx - 1].Relation == Relation.None
                    && SelectedPolygon.Edges[idx].Relation == Relation.None)
                {
                    var mover = new Mover(vertice, this, idx++);
                    VertexPickers.Add(mover);
                    this.pictureBox.Controls.Add(mover);
                }
                else
                {
                    var polyMover = new PolyMover(vertice, this, form.RelationService, form.CircleService, idx++);
                    VertexPickers.Add(polyMover);
                    this.pictureBox.Controls.Add(polyMover);
                }
            }
        }

        public void EnterDeleteVerticeMode()
        {
            int idx = 0;
            foreach (var vertice in SelectedPolygon.Vertices)
            {
                var deleter = new Deleter(vertice, idx++, this);
                VertexPickers.Add(deleter);
                this.pictureBox.Controls.Add(deleter);
            }
        }

        public void DeleteVertice(int index)
        {


            this.pictureBox.Controls.Remove(this.VertexPickers[index]);
            this.VertexPickers.RemoveAt(index);
            if (this.VertexPickers.Count == 0)
            {
                this.Polygons.Remove(this.SelectedPolygon);
                this.ExitPolygonOptions();
                return;
            }
            int idx = 0;
            foreach (var vertexPicker in this.VertexPickers)
            {
                vertexPicker.Index = idx++;
            }

            this.SelectedPolygon.Vertices.RemoveAt(index);

            var prevEdgeIdx = index == 0 ? this.SelectedPolygon.Edges.Count - 1 : index - 1;

            this.LineService.EraseLine(this.SelectedPolygon.Edges[prevEdgeIdx]);
            this.LineService.EraseLine(this.SelectedPolygon.Edges[index]);

            this.form.RelationService.DestroyRelationOfEdge(this.SelectedPolygon.Edges[prevEdgeIdx]);
            this.form.RelationService.DestroyRelationOfEdge(this.SelectedPolygon.Edges[index]);

            var firstPoint = this.SelectedPolygon.Edges[prevEdgeIdx].Points[0];
            var secPoint = this.SelectedPolygon.Edges[index].Points[1];

            var newLine = this.LineService.CreateLine(firstPoint.X, firstPoint.Y, secPoint.X, secPoint.Y);

            this.SelectedPolygon.Edges[prevEdgeIdx] = newLine;
            this.SelectedPolygon.Edges.RemoveAt(index);

            this.pictureBox.Invalidate();

        }

        public void SavePolygon(Polygon polygon)
        {
            this.Polygons.Add(polygon);
            this.polygonListBox.Items.Add(new ListViewItem() { Text = $"p_{this.Polygons.Count}", Name= $"p_{this.Polygons.Count}" });
        }

        public void SaveCircle(Circle circle)
        {
            this.Circles.Add(circle);
            this.circleListBox.Items.Add(new ListViewItem() { Text = $"c_{this.Circles.Count}", Name = $"c_{this.Circles.Count}" });
        }

        public void BeginDoubleTracking(Mover mover)
        {
            var prevVertice = this.SelectedPolygon.Vertices[mover.Index == 0 ? this.SelectedPolygon.Vertices.Count - 1 : mover.Index - 1];
            var nextVertice = this.SelectedPolygon.Vertices[mover.Index == this.SelectedPolygon.Vertices.Count - 1 ? 0 : mover.Index + 1];
            this.LineService.BeginDoubleTracking(prevVertice.X, prevVertice.Y, nextVertice.X, nextVertice.Y);
            if (mover.Index == 0)
            {
                this.LineService.EraseTrackingLine(this.SelectedPolygon.Edges[0]);
                this.LineService.EraseTrackingLine(this.SelectedPolygon.Edges[this.SelectedPolygon.Edges.Count - 1]);

                this.LineService.EraseLine(this.SelectedPolygon.Edges[0]);
                this.LineService.EraseLine(this.SelectedPolygon.Edges[this.SelectedPolygon.Edges.Count - 1]);

                // gets regenerated after ending of double tracking
                this.SelectedPolygon.Edges[0] = null;
                this.SelectedPolygon.Edges[this.SelectedPolygon.Edges.Count - 1] = null;
            }
            else 
            {
                this.LineService.EraseTrackingLine(this.SelectedPolygon.Edges[mover.Index - 1]);
                this.LineService.EraseTrackingLine(this.SelectedPolygon.Edges[mover.Index]);

                this.LineService.EraseLine(this.SelectedPolygon.Edges[mover.Index - 1]);
                this.LineService.EraseLine(this.SelectedPolygon.Edges[mover.Index]);

                this.SelectedPolygon.Edges[mover.Index] = null;
                this.SelectedPolygon.Edges[mover.Index - 1] = null;
            }
        }

        public void ExitVertexPickersMode()
        {
            foreach (var vertexPicker in this.VertexPickers)
            {
                this.pictureBox.Controls.Remove(vertexPicker);
            }
            VertexPickers.Clear();
        }

        public void EnterAddVerticeMode()
        {
            int idx = 0;
            foreach (var edge in SelectedPolygon.Edges)
            {
                var adder = new Adder(edge.EvaluateMidPoint(), idx++, this);
                VertexPickers.Add(adder);
                this.pictureBox.Controls.Add(adder);
            }
        }

        public void InsertVertice(int index)
        {
            this.form.RelationService.DestroyRelationOfEdge(this.SelectedPolygon.Edges[index]);

            var newPoint = this.SelectedPolygon.Edges[index].EvaluateMidPoint();
            this.SelectedPolygon.Vertices.Insert(index + 1, newPoint);

            var oldEndPoint = this.SelectedPolygon.Edges[index].Points[1];

            this.LineService.EraseLine(this.SelectedPolygon.Edges[index]);
            this.SelectedPolygon.Edges[index].Points[1] = newPoint;

            var newEdge = new Line();
            newEdge.AppendPoint(newPoint);
            newEdge.AppendPoint(oldEndPoint);



            this.SelectedPolygon.Edges.Insert(index + 1, newEdge);

            this.LineService.CreateLine(this.SelectedPolygon.Edges[index]);

            this.LineService.CreateLine(this.SelectedPolygon.Edges[index + 1]);

            this.pictureBox.Invalidate();

            this.form.switchToMoveVerticeMode();
        }


        public void EnterMoveEdgeMode()
        {
            int idx = 0;
            foreach (var edge in SelectedPolygon.Edges)
            {
                if (SelectedPolygon.Edges[idx == 0 ? SelectedPolygon.Edges.Count - 1 : idx - 1].Relation == Relation.None
                    && SelectedPolygon.Edges[idx == SelectedPolygon.Edges.Count - 1 ? 0 : idx + 1].Relation == Relation.None)
                {
                    var edgeMover = new EdgeMover(edge.EvaluateMidPoint(), this, form.RelationService, form.CircleService, idx++, SelectedPolygon);
                    VertexPickers.Add(edgeMover);
                    this.pictureBox.Controls.Add(edgeMover);
                }
                else
                {
                    var polyMover = new PolyMover(edge.EvaluateMidPoint(), this, form.RelationService, form.CircleService, idx++);
                    VertexPickers.Add(polyMover);
                    this.pictureBox.Controls.Add(polyMover);
                }
            }
        }

        public void EnterMovePolygonMode()
        {
            var polyMover = new PolyMover(SelectedPolygon.Vertices[0], this, form.RelationService, form.CircleService, 0);
            VertexPickers.Add(polyMover);
            this.pictureBox.Controls.Add(polyMover);
        }

        public void EnterExactLengthMode()
        {
            int idx;
            foreach (var polygon in Polygons)
            {
                if (polygon.Edges.FindAll(e => e.Relation == Relation.None).Count < 2) break;
                idx = 0;
                foreach (var edge in polygon.Edges)
                {
                    if (edge.Relation == Relation.None)
                    {
                        var picker = new ExactLengthPicker(edge.EvaluateMidPoint(), this, idx, this.form.RelationService, polygon);
                        VertexPickers.Add(picker);
                        this.pictureBox.Controls.Add(picker);
                    }
                    idx++;
                }
            }
        }

        public void EnterRadiusLengthMode()
        {
            int idx = 0;
            foreach (var circle in Circles)
            {
                if (circle.LengthRelation == Relation.None)
                {
                    if (circle.TangentRelation != Relation.None)
                    {
                        var tanRelIdx = this.form.RelationService.RelationHandlers
                            .FindIndex(r => r.CircleTarget == circle && r.Type == Relation.Tangency);

                        this.form.RelationService.RelationPickers[tanRelIdx].MoveUp();

                    }
                    var picker = new RadiusLengthPicker(circle.Origin, idx++, this.form.RelationService, circle);
                    VertexPickers.Add(picker);
                    this.pictureBox.Controls.Add(picker);
                }
            }
        }
        public void EnterSameLengthMode(bool isFirst)
        {
            int idx;
            
            foreach (var polygon in Polygons)
            {
                if (polygon.Edges.FindAll(e => e.Relation == Relation.None).Count < 2) break;
                idx = 0;
                foreach (var edge in polygon.Edges)
                {
                    if (edge.Relation == Relation.None)
                    {
                        var picker = new SameLengthPicker(edge.EvaluateMidPoint(), this, idx, this.form.RelationService, polygon, isFirst);
                        VertexPickers.Add(picker);
                        this.pictureBox.Controls.Add(picker);
                    }
                    idx++;
                }
            }
        }

        public void EnterPerpendicularityMode(bool isFirst)
        {
            int idx;
            foreach (var polygon in Polygons)
            {
                idx = 0;
                if (polygon.Edges.FindAll(e => e.Relation == Relation.None).Count < 2) break;
                foreach (var edge in polygon.Edges)
                {
                    if (edge.Relation == Relation.None)
                    {
                        var picker = new PerpendicularityPicker(edge.EvaluateMidPoint(), this, idx, this.form.RelationService, polygon, isFirst);
                        VertexPickers.Add(picker);
                        this.pictureBox.Controls.Add(picker);
                    }
                    idx++;
                }
            }
        }

        public void EnterTangencyMode(bool isFirst)
        {
            int idx = 0;
            if (isFirst)
            {
                foreach (var circle in Circles)
                {
                    if (circle.TangentRelation == Relation.None)
                    {
                        if (circle.LengthRelation != Relation.None)
                        {
                            var lenRelIdx = this.form.RelationService.RelationHandlers
                                .FindIndex(r => r.CircleTarget == circle && r.Type == Relation.ExactRadius);

                            this.form.RelationService.RelationPickers[lenRelIdx].MoveUp();

                        }
                        var picker = new TangencyPicker(circle.Origin, this, idx++, this.form.RelationService, circle);
                        VertexPickers.Add(picker);
                        this.pictureBox.Controls.Add(picker);
                    }
                }
            }
            else
            {
                foreach (var polygon in Polygons)
                {
                    idx = 0;
                    if (polygon.Edges.FindAll(e => e.Relation == Relation.None).Count < 2) break;
                    foreach (var edge in polygon.Edges)
                    {
                        if (edge.Relation == Relation.None)
                        {
                            var picker = new TangencyPicker(edge.EvaluateMidPoint(), this, idx, this.form.RelationService, polygon);
                            VertexPickers.Add(picker);
                            this.pictureBox.Controls.Add(picker);
                        }
                        idx++;
                    }
                }
            }
        }

        public void CreateInitialScene()
        {
            var circlesToAdd = new List<Circle>()
            {
                new Circle(new Point(500, 500), 150),
                new Circle(new Point(700, 600), 200)
            };

            var polygonsToAdd = new List<Polygon>();

            
            var poly1 = new Polygon(100, 200);

            var line1 = new Line();
            line1.AppendPoint(new Point(100, 200));
            line1.AppendPoint(new Point(200, 200));
            poly1.AppendLine(line1);

            var line2 = new Line();
            line2.AppendPoint(new Point(200, 200));
            line2.AppendPoint(new Point(350, 350));
            poly1.AppendLine(line2);

            var line3 = new Line();
            line3.AppendPoint(new Point(350, 350));
            line3.AppendPoint(new Point(600, 400));
            poly1.AppendLine(line3);

            var line4 = new Line();
            line4.AppendPoint(new Point(600, 400));
            line4.AppendPoint(new Point(200, 400));
            poly1.AppendLine(line4);

            var line5 = new Line();
            line5.AppendPoint(new Point(200, 400));
            line5.AppendPoint(new Point(100, 200));

            poly1.CompletePolygon(line5);

            polygonsToAdd.Add(poly1);

            var poly2 = new Polygon(700, 200);

            var line6 = new Line();
            line6.AppendPoint(new Point(700, 200));
            line6.AppendPoint(new Point(700, 300));
            poly2.AppendLine(line6);

            var line7 = new Line();
            line7.AppendPoint(new Point(700, 300));
            line7.AppendPoint(new Point(850, 450));
            poly2.AppendLine(line7);

            var line8 = new Line();
            line8.AppendPoint(new Point(850, 450));
            line8.AppendPoint(new Point(900, 700));
            poly2.AppendLine(line8);

            var line9 = new Line();
            line9.AppendPoint(new Point(900, 700));
            line9.AppendPoint(new Point(900, 300));
            poly2.AppendLine(line9);

            var line10 = new Line();
            line10.AppendPoint(new Point(900, 300));
            line10.AppendPoint(new Point(700, 200));

            poly2.CompletePolygon(line10);

            polygonsToAdd.Add(poly2);

            circlesToAdd.ForEach(circle =>
            {
                this.form.CircleService.CreateCircle(circle);
                SaveCircle(circle);
            });

            polygonsToAdd.ForEach(polygon =>
            {
                this.SavePolygon(polygon);
                foreach(var line in polygon.Edges)
                {
                    this.LineService.CreateLine(line);
                }
            });


            this.form.RelationService.InvokeTangencyFirst(circlesToAdd[0]);
            this.form.RelationService.InvokeTangencySecond(poly1, 1);

            this.form.RelationService.InvokePerpendicularityFirst(poly2, 1);
            this.form.RelationService.InvokePerpendicularitySecond(poly2, 4);

            this.form.RelationService.RemoveRelationsFromView();

            this.pictureBox.Invalidate();

        }
    }
}
