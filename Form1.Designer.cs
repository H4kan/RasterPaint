
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
            this.relationBox = new System.Windows.Forms.GroupBox();
            this.deleteRelationBtn = new System.Windows.Forms.Button();
            this.lengthInput = new System.Windows.Forms.NumericUpDown();
            this.perpendicularityBtn = new System.Windows.Forms.Button();
            this.tangencyBtn = new System.Windows.Forms.Button();
            this.sameLengthBtn = new System.Windows.Forms.Button();
            this.exactRadiusBtn = new System.Windows.Forms.Button();
            this.exactLengthBtn = new System.Windows.Forms.Button();
            this.polyActions = new System.Windows.Forms.GroupBox();
            this.movePolygonBtn = new System.Windows.Forms.Button();
            this.moveVerticeBtn = new System.Windows.Forms.Button();
            this.moveEdgeBtn = new System.Windows.Forms.Button();
            this.deleteVerticeBtn = new System.Windows.Forms.Button();
            this.addVerticeBtn = new System.Windows.Forms.Button();
            this.CircleLbl = new System.Windows.Forms.Label();
            this.PolygonLbl = new System.Windows.Forms.Label();
            this.polygonListBox = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.circlesListBox = new System.Windows.Forms.ListView();
            this.circleActions = new System.Windows.Forms.GroupBox();
            this.moveCircleBtn = new System.Windows.Forms.Button();
            this.changeRadiusBtn = new System.Windows.Forms.Button();
            this.newCircleBtn = new System.Windows.Forms.Button();
            this.newRelationBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.memoryPanel.SuspendLayout();
            this.relationBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lengthInput)).BeginInit();
            this.polyActions.SuspendLayout();
            this.circleActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Location = new System.Drawing.Point(24, 81);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1200, 862);
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
            this.NewPolygonBtn.Location = new System.Drawing.Point(24, 12);
            this.NewPolygonBtn.Name = "NewPolygonBtn";
            this.NewPolygonBtn.Size = new System.Drawing.Size(147, 53);
            this.NewPolygonBtn.TabIndex = 4;
            this.NewPolygonBtn.Text = "New polygon";
            this.NewPolygonBtn.UseVisualStyleBackColor = false;
            this.NewPolygonBtn.Click += new System.EventHandler(this.NewPolygonBtn_Click);
            // 
            // memoryPanel
            // 
            this.memoryPanel.Controls.Add(this.relationBox);
            this.memoryPanel.Controls.Add(this.polyActions);
            this.memoryPanel.Controls.Add(this.CircleLbl);
            this.memoryPanel.Controls.Add(this.PolygonLbl);
            this.memoryPanel.Controls.Add(this.polygonListBox);
            this.memoryPanel.Controls.Add(this.circlesListBox);
            this.memoryPanel.Controls.Add(this.circleActions);
            this.memoryPanel.Location = new System.Drawing.Point(1259, 59);
            this.memoryPanel.Name = "memoryPanel";
            this.memoryPanel.Size = new System.Drawing.Size(345, 987);
            this.memoryPanel.TabIndex = 5;
            // 
            // relationBox
            // 
            this.relationBox.Controls.Add(this.deleteRelationBtn);
            this.relationBox.Controls.Add(this.lengthInput);
            this.relationBox.Controls.Add(this.perpendicularityBtn);
            this.relationBox.Controls.Add(this.tangencyBtn);
            this.relationBox.Controls.Add(this.sameLengthBtn);
            this.relationBox.Controls.Add(this.exactRadiusBtn);
            this.relationBox.Controls.Add(this.exactLengthBtn);
            this.relationBox.Location = new System.Drawing.Point(70, 22);
            this.relationBox.Name = "relationBox";
            this.relationBox.Size = new System.Drawing.Size(229, 543);
            this.relationBox.TabIndex = 9;
            this.relationBox.TabStop = false;
            this.relationBox.Text = "Relations";
            this.relationBox.Visible = false;
            // 
            // deleteRelationBtn
            // 
            this.deleteRelationBtn.BackColor = System.Drawing.Color.Black;
            this.deleteRelationBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.deleteRelationBtn.FlatAppearance.BorderSize = 5;
            this.deleteRelationBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteRelationBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.deleteRelationBtn.Location = new System.Drawing.Point(40, 413);
            this.deleteRelationBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deleteRelationBtn.Name = "deleteRelationBtn";
            this.deleteRelationBtn.Size = new System.Drawing.Size(152, 53);
            this.deleteRelationBtn.TabIndex = 12;
            this.deleteRelationBtn.Text = "Delete relation";
            this.deleteRelationBtn.UseVisualStyleBackColor = false;
            this.deleteRelationBtn.Click += new System.EventHandler(this.deleteRelationBtn_Click);
            // 
            // lengthInput
            // 
            this.lengthInput.Location = new System.Drawing.Point(40, 487);
            this.lengthInput.Maximum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.lengthInput.Name = "lengthInput";
            this.lengthInput.Size = new System.Drawing.Size(150, 27);
            this.lengthInput.TabIndex = 11;
            this.lengthInput.Visible = false;
            // 
            // perpendicularityBtn
            // 
            this.perpendicularityBtn.BackColor = System.Drawing.Color.Black;
            this.perpendicularityBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.perpendicularityBtn.FlatAppearance.BorderSize = 5;
            this.perpendicularityBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.perpendicularityBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.perpendicularityBtn.Location = new System.Drawing.Point(37, 343);
            this.perpendicularityBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.perpendicularityBtn.Name = "perpendicularityBtn";
            this.perpendicularityBtn.Size = new System.Drawing.Size(152, 53);
            this.perpendicularityBtn.TabIndex = 10;
            this.perpendicularityBtn.Text = "Perpendicularity";
            this.perpendicularityBtn.UseVisualStyleBackColor = false;
            this.perpendicularityBtn.Click += new System.EventHandler(this.perpendicularityBtn_Click);
            // 
            // tangencyBtn
            // 
            this.tangencyBtn.BackColor = System.Drawing.Color.Black;
            this.tangencyBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.tangencyBtn.FlatAppearance.BorderSize = 5;
            this.tangencyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tangencyBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.tangencyBtn.Location = new System.Drawing.Point(37, 272);
            this.tangencyBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tangencyBtn.Name = "tangencyBtn";
            this.tangencyBtn.Size = new System.Drawing.Size(152, 53);
            this.tangencyBtn.TabIndex = 4;
            this.tangencyBtn.Text = "Tangency";
            this.tangencyBtn.UseVisualStyleBackColor = false;
            this.tangencyBtn.Click += new System.EventHandler(this.tangencyBtn_Click);
            // 
            // sameLengthBtn
            // 
            this.sameLengthBtn.BackColor = System.Drawing.Color.Black;
            this.sameLengthBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.sameLengthBtn.FlatAppearance.BorderSize = 5;
            this.sameLengthBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sameLengthBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.sameLengthBtn.Location = new System.Drawing.Point(37, 198);
            this.sameLengthBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sameLengthBtn.Name = "sameLengthBtn";
            this.sameLengthBtn.Size = new System.Drawing.Size(152, 53);
            this.sameLengthBtn.TabIndex = 3;
            this.sameLengthBtn.Text = "Same length";
            this.sameLengthBtn.UseVisualStyleBackColor = false;
            this.sameLengthBtn.Click += new System.EventHandler(this.sameLengthBtn_Click);
            // 
            // exactRadiusBtn
            // 
            this.exactRadiusBtn.BackColor = System.Drawing.Color.Black;
            this.exactRadiusBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.exactRadiusBtn.FlatAppearance.BorderSize = 5;
            this.exactRadiusBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exactRadiusBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.exactRadiusBtn.Location = new System.Drawing.Point(36, 124);
            this.exactRadiusBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exactRadiusBtn.Name = "exactRadiusBtn";
            this.exactRadiusBtn.Size = new System.Drawing.Size(152, 53);
            this.exactRadiusBtn.TabIndex = 2;
            this.exactRadiusBtn.Text = "Radius length";
            this.exactRadiusBtn.UseVisualStyleBackColor = false;
            this.exactRadiusBtn.Click += new System.EventHandler(this.exactRadiusBtn_Click);
            // 
            // exactLengthBtn
            // 
            this.exactLengthBtn.BackColor = System.Drawing.Color.Black;
            this.exactLengthBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.exactLengthBtn.FlatAppearance.BorderSize = 5;
            this.exactLengthBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exactLengthBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.exactLengthBtn.Location = new System.Drawing.Point(36, 49);
            this.exactLengthBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exactLengthBtn.Name = "exactLengthBtn";
            this.exactLengthBtn.Size = new System.Drawing.Size(152, 53);
            this.exactLengthBtn.TabIndex = 1;
            this.exactLengthBtn.Text = "Edge length";
            this.exactLengthBtn.UseVisualStyleBackColor = false;
            this.exactLengthBtn.Click += new System.EventHandler(this.exactLengthBtn_Click);
            // 
            // polyActions
            // 
            this.polyActions.Controls.Add(this.movePolygonBtn);
            this.polyActions.Controls.Add(this.moveVerticeBtn);
            this.polyActions.Controls.Add(this.moveEdgeBtn);
            this.polyActions.Controls.Add(this.deleteVerticeBtn);
            this.polyActions.Controls.Add(this.addVerticeBtn);
            this.polyActions.Location = new System.Drawing.Point(70, 20);
            this.polyActions.Name = "polyActions";
            this.polyActions.Size = new System.Drawing.Size(229, 417);
            this.polyActions.TabIndex = 0;
            this.polyActions.TabStop = false;
            this.polyActions.Text = "Polygon Actions";
            this.polyActions.Visible = false;
            // 
            // movePolygonBtn
            // 
            this.movePolygonBtn.BackColor = System.Drawing.Color.Black;
            this.movePolygonBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.movePolygonBtn.FlatAppearance.BorderSize = 5;
            this.movePolygonBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.movePolygonBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.movePolygonBtn.Location = new System.Drawing.Point(34, 345);
            this.movePolygonBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.movePolygonBtn.Name = "movePolygonBtn";
            this.movePolygonBtn.Size = new System.Drawing.Size(152, 53);
            this.movePolygonBtn.TabIndex = 4;
            this.movePolygonBtn.Text = "Move polygon";
            this.movePolygonBtn.UseVisualStyleBackColor = false;
            this.movePolygonBtn.Click += new System.EventHandler(this.movePolygonBtn_Click);
            // 
            // moveVerticeBtn
            // 
            this.moveVerticeBtn.BackColor = System.Drawing.Color.Black;
            this.moveVerticeBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.moveVerticeBtn.FlatAppearance.BorderSize = 5;
            this.moveVerticeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveVerticeBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.moveVerticeBtn.Location = new System.Drawing.Point(34, 51);
            this.moveVerticeBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.moveVerticeBtn.Name = "moveVerticeBtn";
            this.moveVerticeBtn.Size = new System.Drawing.Size(152, 53);
            this.moveVerticeBtn.TabIndex = 0;
            this.moveVerticeBtn.Text = "Move vertice";
            this.moveVerticeBtn.UseVisualStyleBackColor = false;
            this.moveVerticeBtn.Click += new System.EventHandler(this.moveVerticeBtn_Click);
            // 
            // moveEdgeBtn
            // 
            this.moveEdgeBtn.BackColor = System.Drawing.Color.Black;
            this.moveEdgeBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.moveEdgeBtn.FlatAppearance.BorderSize = 5;
            this.moveEdgeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveEdgeBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.moveEdgeBtn.Location = new System.Drawing.Point(34, 274);
            this.moveEdgeBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.moveEdgeBtn.Name = "moveEdgeBtn";
            this.moveEdgeBtn.Size = new System.Drawing.Size(152, 53);
            this.moveEdgeBtn.TabIndex = 3;
            this.moveEdgeBtn.Text = "Move edge";
            this.moveEdgeBtn.UseVisualStyleBackColor = false;
            this.moveEdgeBtn.Click += new System.EventHandler(this.moveEdgeBtn_Click);
            // 
            // deleteVerticeBtn
            // 
            this.deleteVerticeBtn.BackColor = System.Drawing.Color.Black;
            this.deleteVerticeBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.deleteVerticeBtn.FlatAppearance.BorderSize = 5;
            this.deleteVerticeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteVerticeBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.deleteVerticeBtn.Location = new System.Drawing.Point(34, 126);
            this.deleteVerticeBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deleteVerticeBtn.Name = "deleteVerticeBtn";
            this.deleteVerticeBtn.Size = new System.Drawing.Size(152, 53);
            this.deleteVerticeBtn.TabIndex = 1;
            this.deleteVerticeBtn.Text = "Delete vertice";
            this.deleteVerticeBtn.UseVisualStyleBackColor = false;
            this.deleteVerticeBtn.Click += new System.EventHandler(this.deleteVerticeBtn_Click);
            // 
            // addVerticeBtn
            // 
            this.addVerticeBtn.BackColor = System.Drawing.Color.Black;
            this.addVerticeBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.addVerticeBtn.FlatAppearance.BorderSize = 5;
            this.addVerticeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addVerticeBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.addVerticeBtn.Location = new System.Drawing.Point(34, 200);
            this.addVerticeBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addVerticeBtn.Name = "addVerticeBtn";
            this.addVerticeBtn.Size = new System.Drawing.Size(152, 53);
            this.addVerticeBtn.TabIndex = 2;
            this.addVerticeBtn.Text = "Add vertice";
            this.addVerticeBtn.UseVisualStyleBackColor = false;
            this.addVerticeBtn.Click += new System.EventHandler(this.addVerticeBtn_Click);
            // 
            // CircleLbl
            // 
            this.CircleLbl.AutoSize = true;
            this.CircleLbl.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CircleLbl.Location = new System.Drawing.Point(70, 777);
            this.CircleLbl.Name = "CircleLbl";
            this.CircleLbl.Size = new System.Drawing.Size(62, 25);
            this.CircleLbl.TabIndex = 4;
            this.CircleLbl.Text = "Circles";
            // 
            // PolygonLbl
            // 
            this.PolygonLbl.AutoSize = true;
            this.PolygonLbl.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PolygonLbl.Location = new System.Drawing.Point(70, 568);
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
            this.polygonListBox.Location = new System.Drawing.Point(109, 596);
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
            this.circlesListBox.Location = new System.Drawing.Point(108, 805);
            this.circlesListBox.Name = "circlesListBox";
            this.circlesListBox.Size = new System.Drawing.Size(151, 159);
            this.circlesListBox.TabIndex = 1;
            this.circlesListBox.UseCompatibleStateImageBehavior = false;
            this.circlesListBox.SelectedIndexChanged += new System.EventHandler(this.circlesListBox_SelectedIndexChanged);
            // 
            // circleActions
            // 
            this.circleActions.Controls.Add(this.moveCircleBtn);
            this.circleActions.Controls.Add(this.changeRadiusBtn);
            this.circleActions.Location = new System.Drawing.Point(70, 52);
            this.circleActions.Name = "circleActions";
            this.circleActions.Size = new System.Drawing.Size(229, 356);
            this.circleActions.TabIndex = 7;
            this.circleActions.TabStop = false;
            this.circleActions.Text = "Circle Actions";
            this.circleActions.Visible = false;
            // 
            // moveCircleBtn
            // 
            this.moveCircleBtn.BackColor = System.Drawing.Color.Black;
            this.moveCircleBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.moveCircleBtn.FlatAppearance.BorderSize = 5;
            this.moveCircleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveCircleBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.moveCircleBtn.Location = new System.Drawing.Point(36, 53);
            this.moveCircleBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.moveCircleBtn.Name = "moveCircleBtn";
            this.moveCircleBtn.Size = new System.Drawing.Size(152, 53);
            this.moveCircleBtn.TabIndex = 4;
            this.moveCircleBtn.Text = "Move circle";
            this.moveCircleBtn.UseVisualStyleBackColor = false;
            this.moveCircleBtn.Click += new System.EventHandler(this.moveCircleBtn_Click);
            // 
            // changeRadiusBtn
            // 
            this.changeRadiusBtn.BackColor = System.Drawing.Color.Black;
            this.changeRadiusBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.changeRadiusBtn.FlatAppearance.BorderSize = 5;
            this.changeRadiusBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changeRadiusBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.changeRadiusBtn.Location = new System.Drawing.Point(36, 140);
            this.changeRadiusBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.changeRadiusBtn.Name = "changeRadiusBtn";
            this.changeRadiusBtn.Size = new System.Drawing.Size(152, 53);
            this.changeRadiusBtn.TabIndex = 5;
            this.changeRadiusBtn.Text = "Change radius";
            this.changeRadiusBtn.UseVisualStyleBackColor = false;
            this.changeRadiusBtn.Click += new System.EventHandler(this.changeRadiusBtn_Click);
            // 
            // newCircleBtn
            // 
            this.newCircleBtn.BackColor = System.Drawing.Color.Black;
            this.newCircleBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.newCircleBtn.FlatAppearance.BorderSize = 5;
            this.newCircleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newCircleBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.newCircleBtn.Location = new System.Drawing.Point(204, 12);
            this.newCircleBtn.Name = "newCircleBtn";
            this.newCircleBtn.Size = new System.Drawing.Size(147, 53);
            this.newCircleBtn.TabIndex = 6;
            this.newCircleBtn.Text = "New circle";
            this.newCircleBtn.UseVisualStyleBackColor = false;
            this.newCircleBtn.Click += new System.EventHandler(this.newCircleBtn_Click);
            // 
            // newRelationBtn
            // 
            this.newRelationBtn.BackColor = System.Drawing.Color.Black;
            this.newRelationBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlText;
            this.newRelationBtn.FlatAppearance.BorderSize = 5;
            this.newRelationBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newRelationBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.newRelationBtn.Location = new System.Drawing.Point(382, 12);
            this.newRelationBtn.Name = "newRelationBtn";
            this.newRelationBtn.Size = new System.Drawing.Size(147, 53);
            this.newRelationBtn.TabIndex = 8;
            this.newRelationBtn.Text = "Relation mode";
            this.newRelationBtn.UseVisualStyleBackColor = false;
            this.newRelationBtn.Click += new System.EventHandler(this.newRelationBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1615, 1076);
            this.Controls.Add(this.newRelationBtn);
            this.Controls.Add(this.newCircleBtn);
            this.Controls.Add(this.memoryPanel);
            this.Controls.Add(this.NewPolygonBtn);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.memoryPanel.ResumeLayout(false);
            this.memoryPanel.PerformLayout();
            this.relationBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lengthInput)).EndInit();
            this.polyActions.ResumeLayout(false);
            this.circleActions.ResumeLayout(false);
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
        private System.Windows.Forms.Button deleteVerticeBtn;
        private System.Windows.Forms.Button moveVerticeBtn;
        private System.Windows.Forms.Button addVerticeBtn;
        private System.Windows.Forms.Button moveEdgeBtn;
        private System.Windows.Forms.Button movePolygonBtn;
        private System.Windows.Forms.Button newCircleBtn;
        private System.Windows.Forms.Button moveCircleBtn;
        private System.Windows.Forms.Button changeRadiusBtn;
        private System.Windows.Forms.GroupBox circleActions;
        private System.Windows.Forms.GroupBox polyActions;
        private System.Windows.Forms.Button newRelationBtn;
        private System.Windows.Forms.GroupBox relationBox;
        private System.Windows.Forms.Button perpendicularityBtn;
        private System.Windows.Forms.Button tangencyBtn;
        private System.Windows.Forms.Button sameLengthBtn;
        private System.Windows.Forms.Button exactRadiusBtn;
        private System.Windows.Forms.Button exactLengthBtn;
        private System.Windows.Forms.NumericUpDown lengthInput;
        private System.Windows.Forms.Button deleteRelationBtn;
    }
}

