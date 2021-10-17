using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RasterPaint.VertexPickers
{
    public class Adder : VertexPicker
    {
        MemoryService memoryService { get; set; }
        bool firstMoved { get; set; }

        public Adder(Point origin, int index, MemoryService memoryService) : base(origin, index)
        {
            this.memoryService = memoryService;
            this.MouseClick += Adding;
        }

        private void Adding(object sender, MouseEventArgs e)
        {
            this.memoryService.InsertVertice(Index);

        }

        


}
}
