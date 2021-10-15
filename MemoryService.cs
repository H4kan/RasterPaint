using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RasterPaint
{
    public class MemoryService
    {
        public List<Polygon> Polygons;

        public List<Line> Lines;

        public Polygon SelectedPolygon { get; set; }

        Panel polygonPanel;
        ListView polygonListBox;
        ListView verticesListBox;

        public MemoryService(
            Panel polygonPanel,
            ListView polygonListBox,
            ListView verticesListBox)
        {
            Lines = new List<Line>();
            Polygons = new List<Polygon>();
            this.polygonListBox = polygonListBox;
            this.polygonPanel = polygonPanel;
            this.verticesListBox = verticesListBox;
        }

        public void ShowPolygonInfo()
        {
            polygonPanel.Visible = true;
            verticesListBox.Items.Clear();
            verticesListBox.Items.Add(new ListViewItem() { Text = "v_2" });
            verticesListBox.Items.Add(new ListViewItem() { Text = "v_3" });
        }

        public void SavePolygon(Polygon polygon)
        {
            this.Polygons.Add(polygon);
            this.polygonListBox.Items.Add(new ListViewItem() { Text = "p_1" });
        }


    }
}
