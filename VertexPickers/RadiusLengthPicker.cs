using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RasterPaint.VertexPickers
{
    public class RadiusLengthPicker : VertexPicker
    {
        private RelationService relationService;

        private Circle circle;

        public RadiusLengthPicker(Point Origin, int index, RelationService relationService, Circle circle) : base(Origin, index)
        {
            this.relationService = relationService;
            this.MouseClick += InvokeRelation;
            this.circle = circle;
        }

        public void InvokeRelation(object sender, MouseEventArgs e)
        {
            this.relationService.InvokeRadiusLength(circle, Index);
        }
    }
}
