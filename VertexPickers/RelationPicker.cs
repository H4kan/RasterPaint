using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RasterPaint.VertexPickers
{
    public class RelationPicker : VertexPicker
    {

        protected override Size PickerSize { get { return new Size(30, 30); } }

        private RelationService relationService;

        public RelationPicker(Point Origin, int index, RelationService relationService, string relationShortCut) : base(Origin, index)
        {
            this.relationService = relationService;
            this.MouseClick += DestroyRelation;
            this.Text = relationShortCut;
        }

        public void DestroyRelation(object sender, MouseEventArgs e)
        {
            if (this.relationService.IsDeletingModeOn)
            {
                this.relationService.DestroyRelation(Index);
                this.relationService.FixVertexPickerIndexing();
            }
        }

        public void MoveUp()
        {
            this.Location = new Point(this.Location.X, this.Location.Y - PickerSize.Height);
        }
    }
}
