
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.NewPolygonBtn = new System.Windows.Forms.Button();
            this.memoryPanel = new System.Windows.Forms.Panel();
            this.circlePanel = new System.Windows.Forms.Panel();
            this.changeRadiusBtn = new System.Windows.Forms.Button();
            this.moveCircleBtn = new System.Windows.Forms.Button();
            this.polygonPanel = new System.Windows.Forms.Panel();
            this.movePolygonBtn = new System.Windows.Forms.Button();
            this.moveEdgeBtn = new System.Windows.Forms.Button();
            this.addVerticeBtn = new System.Windows.Forms.Button();
            this.deleteVerticeBtn = new System.Windows.Forms.Button();
            this.moveVerticeBtn = new System.Windows.Forms.Button();
            this.CircleLbl = new System.Windows.Forms.Label();
            this.PolygonLbl = new System.Windows.Forms.Label();
            this.polygonListBox = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.circlesListBox = new System.Windows.Forms.ListView();
            this.newCircleBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.memoryPanel.SuspendLayout();
            this.circlePanel.SuspendLayout();
            this.polygonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Location = new System.Drawing.Point(12, 83);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1050, 600);
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
            this.NewPolygonBtn.Location = new System.Drawing.Point(12, 21);
            this.NewPolygonBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NewPolygonBtn.Name = "NewPolygonBtn";
            this.NewPolygonBtn.Size = new System.Drawing.Size(129, 40);
            this.NewPolygonBtn.TabIndex = 4;
            this.NewPolygonBtn.Text = "New polygon";
            this.NewPolygonBtn.UseVisualStyleBackColor = false;
            this.NewPolygonBtn.Click += new System.EventHandler(this.NewPolygonBtn_Click);
            // 
            // memoryPanel
            // 
            this.memoryPanel.Controls.Add(this.circlePanel);
            this.memoryPanel.Controls.Add(this.polygonPanel);
            this.memoryPanel.Controls.Add(this.CircleLbl);
            this.memoryPanel.Controls.Add(this.PolygonLbl);
            this.memoryPanel.Controls.Add(this.polygonListBox);
            this.memoryPanel.Controls.Add(this.circlesListBox);
            this.memoryPanel.Location = new System.Drawing.Point(1102, 44);
            this.memoryPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.memoryPanel.Name = "memoryPanel";
            this.memoryPanel.Size = new System.Drawing.Size(302, 692);
            this.memoryPanel.TabIndex = 5;
            // 
            // circlePanel
            // 
            this.circlePanel.Controls.Add(this.changeRadiusBtn);
            this.circlePanel.Controls.Add(this.moveCircleBtn);
            this.circlePanel.Location = new System.Drawing.Point(61, 39);
            this.circlePanel.Name = "circlePanel";
            this.circlePanel.Size = new System.Drawing.Size(200, 267);
            this.circlePanel.TabIndex = 6;
            this.circlePanel.Visible = false;
            // 
            // changeRadiusBtn
            // 
            this.changeRadiusBtn.BackColor = System.Drawing.Color.Black;
            this.changeRadiusBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.changeRadiusBtn.FlatAppearance.BorderSize = 5;
            this.changeRadiusBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changeRadiusBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.changeRadiusBtn.Location = new System.Drawing.Point(33, 88);
            this.changeRadiusBtn.Name = "changeRadiusBtn";
            this.changeRadiusBtn.Size = new System.Drawing.Size(133, 40);
            this.changeRadiusBtn.TabIndex = 5;
            this.changeRadiusBtn.Text = "Change radius";
            this.changeRadiusBtn.UseVisualStyleBackColor = false;
            this.changeRadiusBtn.Click += new System.EventHandler(this.changeRadiusBtn_Click);
            // 
            // moveCircleBtn
            // 
            this.moveCircleBtn.BackColor = System.Drawing.Color.Black;
            this.moveCircleBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.moveCircleBtn.FlatAppearance.BorderSize = 5;
            this.moveCircleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveCircleBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.moveCircleBtn.Location = new System.Drawing.Point(33, 33);
            this.moveCircleBtn.Name = "moveCircleBtn";
            this.moveCircleBtn.Size = new System.Drawing.Size(133, 40);
            this.moveCircleBtn.TabIndex = 4;
            this.moveCircleBtn.Text = "Move circle";
            this.moveCircleBtn.UseVisualStyleBackColor = false;
            this.moveCircleBtn.Click += new System.EventHandler(this.moveCircleBtn_Click);
            // 
            // polygonPanel
            // 
            this.polygonPanel.Controls.Add(this.movePolygonBtn);
            this.polygonPanel.Controls.Add(this.moveEdgeBtn);
            this.polygonPanel.Controls.Add(this.addVerticeBtn);
            this.polygonPanel.Controls.Add(this.deleteVerticeBtn);
            this.polygonPanel.Controls.Add(this.moveVerticeBtn);
            this.polygonPanel.Location = new System.Drawing.Point(61, 49);
            this.polygonPanel.Name = "polygonPanel";
            this.polygonPanel.Size = new System.Drawing.Size(200, 267);
            this.polygonPanel.TabIndex = 5;
            this.polygonPanel.Visible = false;
            // 
            // movePolygonBtn
            // 
            this.movePolygonBtn.BackColor = System.Drawing.Color.Black;
            this.movePolygonBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.movePolygonBtn.FlatAppearance.BorderSize = 5;
            this.movePolygonBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.movePolygonBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.movePolygonBtn.Location = new System.Drawing.Point(33, 203);
            this.movePolygonBtn.Name = "movePolygonBtn";
            this.movePolygonBtn.Size = new System.Drawing.Size(133, 40);
            this.movePolygonBtn.TabIndex = 4;
            this.movePolygonBtn.Text = "Move polygon";
            this.movePolygonBtn.UseVisualStyleBackColor = false;
            this.movePolygonBtn.Click += new System.EventHandler(this.movePolygonBtn_Click);
            // 
            // moveEdgeBtn
            // 
            this.moveEdgeBtn.BackColor = System.Drawing.Color.Black;
            this.moveEdgeBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.moveEdgeBtn.FlatAppearance.BorderSize = 5;
            this.moveEdgeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveEdgeBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.moveEdgeBtn.Location = new System.Drawing.Point(33, 157);
            this.moveEdgeBtn.Name = "moveEdgeBtn";
            this.moveEdgeBtn.Size = new System.Drawing.Size(133, 40);
            this.moveEdgeBtn.TabIndex = 3;
            this.moveEdgeBtn.Text = "Move edge";
            this.moveEdgeBtn.UseVisualStyleBackColor = false;
            this.moveEdgeBtn.Click += new System.EventHandler(this.moveEdgeBtn_Click);
            // 
            // addVerticeBtn
            // 
            this.addVerticeBtn.BackColor = System.Drawing.Color.Black;
            this.addVerticeBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.addVerticeBtn.FlatAppearance.BorderSize = 5;
            this.addVerticeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addVerticeBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.addVerticeBtn.Location = new System.Drawing.Point(33, 111);
            this.addVerticeBtn.Name = "addVerticeBtn";
            this.addVerticeBtn.Size = new System.Drawing.Size(133, 40);
            this.addVerticeBtn.TabIndex = 2;
            this.addVerticeBtn.Text = "Add vertice";
            this.addVerticeBtn.UseVisualStyleBackColor = false;
            this.addVerticeBtn.Click += new System.EventHandler(this.addVerticeBtn_Click);
            // 
            // deleteVerticeBtn
            // 
            this.deleteVerticeBtn.BackColor = System.Drawing.Color.Black;
            this.deleteVerticeBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.deleteVerticeBtn.FlatAppearance.BorderSize = 5;
            this.deleteVerticeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteVerticeBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.deleteVerticeBtn.Location = new System.Drawing.Point(33, 65);
            this.deleteVerticeBtn.Name = "deleteVerticeBtn";
            this.deleteVerticeBtn.Size = new System.Drawing.Size(133, 40);
            this.deleteVerticeBtn.TabIndex = 1;
            this.deleteVerticeBtn.Text = "Delete vertice";
            this.deleteVerticeBtn.UseVisualStyleBackColor = false;
            this.deleteVerticeBtn.Click += new System.EventHandler(this.deleteVerticeBtn_Click);
            // 
            // moveVerticeBtn
            // 
            this.moveVerticeBtn.BackColor = System.Drawing.Color.Black;
            this.moveVerticeBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.moveVerticeBtn.FlatAppearance.BorderSize = 5;
            this.moveVerticeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveVerticeBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.moveVerticeBtn.Location = new System.Drawing.Point(33, 19);
            this.moveVerticeBtn.Name = "moveVerticeBtn";
            this.moveVerticeBtn.Size = new System.Drawing.Size(133, 40);
            this.moveVerticeBtn.TabIndex = 0;
            this.moveVerticeBtn.Text = "Move vertice";
            this.moveVerticeBtn.UseVisualStyleBackColor = false;
            this.moveVerticeBtn.Click += new System.EventHandler(this.moveVerticeBtn_Click);
            // 
            // CircleLbl
            // 
            this.CircleLbl.AutoSize = true;
            this.CircleLbl.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CircleLbl.Location = new System.Drawing.Point(61, 512);
            this.CircleLbl.Name = "CircleLbl";
            this.CircleLbl.Size = new System.Drawing.Size(52, 20);
            this.CircleLbl.TabIndex = 4;
            this.CircleLbl.Text = "Circles";
            // 
            // PolygonLbl
            // 
            this.PolygonLbl.AutoSize = true;
            this.PolygonLbl.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PolygonLbl.Location = new System.Drawing.Point(61, 347);
            this.PolygonLbl.Name = "PolygonLbl";
            this.PolygonLbl.Size = new System.Drawing.Size(68, 20);
            this.PolygonLbl.TabIndex = 3;
            this.PolygonLbl.Text = "Polygons";
            // 
            // polygonListBox
            // 
            this.polygonListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.polygonListBox.HideSelection = false;
            this.polygonListBox.Location = new System.Drawing.Point(94, 375);
            this.polygonListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.polygonListBox.Name = "polygonListBox";
            this.polygonListBox.Size = new System.Drawing.Size(133, 120);
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
            this.circlesListBox.Location = new System.Drawing.Point(94, 544);
            this.circlesListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.circlesListBox.Name = "circlesListBox";
            this.circlesListBox.Size = new System.Drawing.Size(133, 120);
            this.circlesListBox.TabIndex = 1;
            this.circlesListBox.UseCompatibleStateImageBehavior = false;
            this.circlesListBox.SelectedIndexChanged += new System.EventHandler(this.circlesListBox_SelectedIndexChanged);
            // 
            // newCircleBtn
            // 
            this.newCircleBtn.BackColor = System.Drawing.Color.Black;
            this.newCircleBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.newCircleBtn.FlatAppearance.BorderSize = 5;
            this.newCircleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newCircleBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.newCircleBtn.Location = new System.Drawing.Point(175, 21);
            this.newCircleBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.newCircleBtn.Name = "newCircleBtn";
            this.newCircleBtn.Size = new System.Drawing.Size(129, 40);
            this.newCircleBtn.TabIndex = 6;
            this.newCircleBtn.Text = "New circle";
            this.newCircleBtn.UseVisualStyleBackColor = false;
            this.newCircleBtn.Click += new System.EventHandler(this.newCircleBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1413, 807);
            this.Controls.Add(this.newCircleBtn);
            this.Controls.Add(this.memoryPanel);
            this.Controls.Add(this.NewPolygonBtn);
            this.Controls.Add(this.pictureBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.memoryPanel.ResumeLayout(false);
            this.memoryPanel.PerformLayout();
            this.circlePanel.ResumeLayout(false);
            this.polygonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button NewPolygonBtn;
        private System.Windows.Forms.Panel memoryPanel;
        private System.Windows.Forms.Label PolygonLbl;
        private System.Windows.Forms.ListView polygonListBox;
        private System.Windows.Forms.Label CircleLbl;
        private System.Windows.Forms.ListView circlesListBox;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Panel polygonPanel;
        private System.Windows.Forms.Button deleteVerticeBtn;
        private System.Windows.Forms.Button moveVerticeBtn;
        private System.Windows.Forms.Button addVerticeBtn;
        private System.Windows.Forms.Button moveEdgeBtn;
        private System.Windows.Forms.Button movePolygonBtn;
        private System.Windows.Forms.Button newCircleBtn;
        private System.Windows.Forms.Panel circlePanel;
        private System.Windows.Forms.Button moveCircleBtn;
        private System.Windows.Forms.Button changeRadiusBtn;
    }
}

