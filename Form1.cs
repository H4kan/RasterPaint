using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RasterPaint
{
    public partial class Form1 : Form
    {
        Bitmap bmp;

        private bool IsLineTracking { get; set; }

        private Polygon CurrentPolygon { get; set; }

        LineService LineService { get; set; }
        MemoryService MemoryService { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetupScreen();
            this.LineService = new LineService(bmp, pictureBox);
            this.MemoryService = new MemoryService(this.polygonPanel, this.polygonListBox, this.verticesListBox);
        }

        private void SetupScreen()
        {
            bmp = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
     
            pictureBox.Image = bmp;
        }

        private void SetPixel(int x, int y)
        {
            bmp.SetPixel(x, y, Color.Black);
        }

    
        private void BeginLine(object sender, MouseEventArgs e)
        {
            pictureBox.Invalidate();
            this.pictureBox.MouseClick -= BeginLine;
            this.LineService.BeginTracking(e.X, e.Y);
            this.pictureBox.MouseMove += this.LineService.LineTracker.Update;
            this.pictureBox.MouseClick += StopLineTracking;
            this.IsLineTracking = true;
        }

        private void BeginPolygon(object sender, MouseEventArgs e)
        {
            CurrentPolygon = new Polygon(e.X, e.Y);
            pictureBox.Invalidate();
            this.pictureBox.MouseClick -= BeginPolygon;
            this.LineService.BeginTracking(e.X, e.Y);
            this.pictureBox.MouseMove += this.LineService.LineTracker.Update;
            this.pictureBox.MouseClick += ContinuePolygon;
           
            this.IsLineTracking = true;

        }

        private void ContinuePolygon(object sender, MouseEventArgs e)
        {
            
            this.pictureBox.MouseClick -= ContinuePolygon;
            if (e.Button == MouseButtons.Left)
            {
                this.pictureBox.MouseMove -= this.LineService.LineTracker.Update;
                CurrentPolygon.AppendLine(this.LineService.LineTracker.LastLine);
                this.LineService.StopTracking();
                pictureBox.Invalidate();
                this.LineService.BeginTracking(e.X, e.Y);
                this.pictureBox.MouseMove += this.LineService.LineTracker.Update;
                this.pictureBox.MouseClick += ContinuePolygon;
      
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.pictureBox.MouseMove -= this.LineService.LineTracker.Update;

                var lastLine = this.LineService.LineTracker.LastLine;

                
                this.LineService.AbortTracking();

                CurrentPolygon.CompletePolygon(
                    this.LineService.CreateLine(CurrentPolygon.Vertices[0].X,
                    CurrentPolygon.Vertices[0].Y,
                    CurrentPolygon.Vertices[CurrentPolygon.Vertices.Count - 1].X,
                    CurrentPolygon.Vertices[CurrentPolygon.Vertices.Count - 1].Y));


                this.IsLineTracking = false;

                this.MemoryService.SavePolygon(CurrentPolygon);

                this.NewPolygonBtn.FlatAppearance.BorderColor = Color.Black;
            }
        }

        private void StopLineTracking(object sender, MouseEventArgs e)
        {
            this.pictureBox.MouseMove -= this.LineService.LineTracker.Update;
            this.pictureBox.MouseClick -= StopLineTracking;
            this.LineService.StopTracking();
            
            this.IsLineTracking = false;
            this.NewLineBtn.FlatAppearance.BorderColor = Color.Black;
        }

        private void NewLine_Click(object sender, EventArgs e)
        {
            if (!IsLineTracking)
            {
                this.pictureBox.MouseClick += BeginLine;
                this.NewLineBtn.FlatAppearance.BorderColor = Color.Red;
            }
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData) {
                case Keys.E: 
                    if (!IsLineTracking)
                    {
                        this.NewLineBtn.FlatAppearance.BorderColor = Color.Red;
                        this.pictureBox.MouseClick += BeginLine;
                    }
                    return true;
                case Keys.P:
                    if (!IsLineTracking)
                    {
                        this.NewPolygonBtn.FlatAppearance.BorderColor = Color.Red;
                        this.pictureBox.MouseClick += BeginPolygon;
                    }
                    return true;

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void AbortTracking()
        {
            this.pictureBox.MouseMove -= this.LineService.LineTracker.Update;
            this.pictureBox.MouseClick -= StopLineTracking;
            this.LineService.AbortTracking();
            this.NewLineBtn.FlatAppearance.BorderColor = Color.Black;
            this.IsLineTracking = false;
        }

        private void AbortPolygonTracking()
        {
            this.pictureBox.MouseMove -= this.LineService.LineTracker.Update;
            this.pictureBox.MouseClick -= StopLineTracking;
            this.LineService.AbortTracking();
            this.IsLineTracking = false;
        }

        private void NewPolygonBtn_Click(object sender, EventArgs e)
        {
            this.NewPolygonBtn.FlatAppearance.BorderColor = Color.Red;
            this.pictureBox.MouseClick += BeginPolygon;
            
        }

        private void polygonListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.MemoryService.SelectedPolygon = this.MemoryService.Polygons[this.polygonListBox.SelectedItems[0].Index];
            this.MemoryService.ShowPolygonInfo();
        }
    }

    
}
