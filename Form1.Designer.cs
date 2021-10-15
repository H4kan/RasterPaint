
namespace RasterPaint
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("");
            this.NewLineBtn = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.NewPolygonBtn = new System.Windows.Forms.Button();
            this.memoryPanel = new System.Windows.Forms.Panel();
            this.polygonPanel = new System.Windows.Forms.Panel();
            this.VerticesLbl = new System.Windows.Forms.Label();
            this.verticesListBox = new System.Windows.Forms.ListView();
            this.CircleLbl = new System.Windows.Forms.Label();
            this.PolygonLbl = new System.Windows.Forms.Label();
            this.polygonListBox = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.circlesListBox = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.memoryPanel.SuspendLayout();
            this.polygonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // NewLineBtn
            // 
            this.NewLineBtn.BackColor = System.Drawing.Color.Black;
            this.NewLineBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.NewLineBtn.FlatAppearance.BorderSize = 5;
            this.NewLineBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewLineBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.NewLineBtn.Location = new System.Drawing.Point(12, 12);
            this.NewLineBtn.Name = "NewLineBtn";
            this.NewLineBtn.Size = new System.Drawing.Size(129, 40);
            this.NewLineBtn.TabIndex = 1;
            this.NewLineBtn.Text = "New line (E)";
            this.NewLineBtn.UseVisualStyleBackColor = false;
            this.NewLineBtn.Click += new System.EventHandler(this.NewLine_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Location = new System.Drawing.Point(12, 71);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1200, 800);
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // NewPolygonBtn
            // 
            this.NewPolygonBtn.BackColor = System.Drawing.Color.Black;
            this.NewPolygonBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.NewPolygonBtn.FlatAppearance.BorderSize = 5;
            this.NewPolygonBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewPolygonBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.NewPolygonBtn.Location = new System.Drawing.Point(164, 12);
            this.NewPolygonBtn.Name = "NewPolygonBtn";
            this.NewPolygonBtn.Size = new System.Drawing.Size(147, 40);
            this.NewPolygonBtn.TabIndex = 4;
            this.NewPolygonBtn.Text = "New polygon (P)";
            this.NewPolygonBtn.UseVisualStyleBackColor = false;
            this.NewPolygonBtn.Click += new System.EventHandler(this.NewPolygonBtn_Click);
            // 
            // memoryPanel
            // 
            this.memoryPanel.Controls.Add(this.polygonPanel);
            this.memoryPanel.Controls.Add(this.CircleLbl);
            this.memoryPanel.Controls.Add(this.PolygonLbl);
            this.memoryPanel.Controls.Add(this.polygonListBox);
            this.memoryPanel.Controls.Add(this.circlesListBox);
            this.memoryPanel.Location = new System.Drawing.Point(1260, 59);
            this.memoryPanel.Name = "memoryPanel";
            this.memoryPanel.Size = new System.Drawing.Size(345, 922);
            this.memoryPanel.TabIndex = 5;
            // 
            // polygonPanel
            // 
            this.polygonPanel.Controls.Add(this.VerticesLbl);
            this.polygonPanel.Controls.Add(this.verticesListBox);
            this.polygonPanel.Location = new System.Drawing.Point(55, 34);
            this.polygonPanel.Name = "polygonPanel";
            this.polygonPanel.Size = new System.Drawing.Size(250, 307);
            this.polygonPanel.TabIndex = 5;
            // 
            // VerticesLbl
            // 
            this.VerticesLbl.AutoSize = true;
            this.VerticesLbl.Location = new System.Drawing.Point(53, 144);
            this.VerticesLbl.Name = "VerticesLbl";
            this.VerticesLbl.Size = new System.Drawing.Size(60, 20);
            this.VerticesLbl.TabIndex = 1;
            this.VerticesLbl.Text = "Vertices";
            // 
            // verticesListBox
            // 
            this.verticesListBox.HideSelection = false;
            this.verticesListBox.Location = new System.Drawing.Point(53, 177);
            this.verticesListBox.Name = "verticesListBox";
            this.verticesListBox.Size = new System.Drawing.Size(151, 87);
            this.verticesListBox.TabIndex = 0;
            this.verticesListBox.UseCompatibleStateImageBehavior = false;
            // 
            // CircleLbl
            // 
            this.CircleLbl.AutoSize = true;
            this.CircleLbl.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CircleLbl.Location = new System.Drawing.Point(70, 683);
            this.CircleLbl.Name = "CircleLbl";
            this.CircleLbl.Size = new System.Drawing.Size(62, 25);
            this.CircleLbl.TabIndex = 4;
            this.CircleLbl.Text = "Circles";
            // 
            // PolygonLbl
            // 
            this.PolygonLbl.AutoSize = true;
            this.PolygonLbl.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PolygonLbl.Location = new System.Drawing.Point(70, 463);
            this.PolygonLbl.Name = "PolygonLbl";
            this.PolygonLbl.Size = new System.Drawing.Size(85, 25);
            this.PolygonLbl.TabIndex = 3;
            this.PolygonLbl.Text = "Polygons";
            // 
            // polygonListBox
            // 
            this.polygonListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.polygonListBox.HideSelection = false;
            this.polygonListBox.Location = new System.Drawing.Point(108, 500);
            this.polygonListBox.Name = "polygonListBox";
            this.polygonListBox.Size = new System.Drawing.Size(151, 159);
            this.polygonListBox.TabIndex = 2;
            this.polygonListBox.UseCompatibleStateImageBehavior = false;
            this.polygonListBox.SelectedIndexChanged += new System.EventHandler(this.polygonListBox_SelectedIndexChanged);
            // 
            // circlesListBox
            // 
            this.circlesListBox.HideSelection = false;
            this.circlesListBox.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.circlesListBox.Location = new System.Drawing.Point(108, 726);
            this.circlesListBox.Name = "circlesListBox";
            this.circlesListBox.Size = new System.Drawing.Size(151, 159);
            this.circlesListBox.TabIndex = 1;
            this.circlesListBox.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1615, 1045);
            this.Controls.Add(this.memoryPanel);
            this.Controls.Add(this.NewPolygonBtn);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.NewLineBtn);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.memoryPanel.ResumeLayout(false);
            this.memoryPanel.PerformLayout();
            this.polygonPanel.ResumeLayout(false);
            this.polygonPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button NewLineBtn;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button NewPolygonBtn;
        private System.Windows.Forms.Panel memoryPanel;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Label PolygonLbl;
        private System.Windows.Forms.ListView polygonListBox;
        private System.Windows.Forms.Label CircleLbl;
        private System.Windows.Forms.Panel polygonPanel;
        private System.Windows.Forms.Label VerticesLbl;
        private System.Windows.Forms.ListView verticesListBox;
        private System.Windows.Forms.ListView circlesListBox;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}

