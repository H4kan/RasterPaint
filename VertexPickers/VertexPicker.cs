using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RasterPaint.VertexPickers
{
    public class VertexPicker : Button
    {
        protected Size PickerSize = new Size(15, 15);

        public int Index { get; set; }

        public VertexPicker(Point Origin, int index)
        {
            this.Size = PickerSize;
            this.Location = new Point(Origin.X - PickerSize.Width / 2, Origin.Y - PickerSize.Height / 2);
            this.Index = index;
        }
    }
}
