namespace Paint
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.RBox = new System.Windows.Forms.NumericUpDown();
            this.GBox = new System.Windows.Forms.NumericUpDown();
            this.BBox = new System.Windows.Forms.NumericUpDown();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.PolyBut = new System.Windows.Forms.RadioButton();
            this.BrokenBut = new System.Windows.Forms.RadioButton();
            this.EllipseBut = new System.Windows.Forms.RadioButton();
            this.RectBut = new System.Windows.Forms.RadioButton();
            this.LineBut = new System.Windows.Forms.RadioButton();
            this.RbBox = new System.Windows.Forms.NumericUpDown();
            this.GbBox = new System.Windows.Forms.NumericUpDown();
            this.BbBox = new System.Windows.Forms.NumericUpDown();
            this.WidthBox = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BBox)).BeginInit();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RbBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GbBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BbBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(830, 618);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDoubleClick);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // RBox
            // 
            this.RBox.Font = new System.Drawing.Font("RomanD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RBox.Location = new System.Drawing.Point(841, 45);
            this.RBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RBox.Name = "RBox";
            this.RBox.Size = new System.Drawing.Size(56, 29);
            this.RBox.TabIndex = 1;
            this.RBox.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RBox.ValueChanged += new System.EventHandler(this.RBox_ValueChanged);
            // 
            // GBox
            // 
            this.GBox.Font = new System.Drawing.Font("RomanD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GBox.Location = new System.Drawing.Point(903, 45);
            this.GBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GBox.Name = "GBox";
            this.GBox.Size = new System.Drawing.Size(56, 29);
            this.GBox.TabIndex = 1;
            this.GBox.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GBox.ValueChanged += new System.EventHandler(this.GBox_ValueChanged);
            // 
            // BBox
            // 
            this.BBox.Font = new System.Drawing.Font("RomanD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BBox.Location = new System.Drawing.Point(965, 45);
            this.BBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.BBox.Name = "BBox";
            this.BBox.Size = new System.Drawing.Size(56, 29);
            this.BBox.TabIndex = 1;
            this.BBox.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.BBox.ValueChanged += new System.EventHandler(this.BBox_ValueChanged);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.PolyBut);
            this.groupBox.Controls.Add(this.BrokenBut);
            this.groupBox.Controls.Add(this.EllipseBut);
            this.groupBox.Controls.Add(this.RectBut);
            this.groupBox.Controls.Add(this.LineBut);
            this.groupBox.Font = new System.Drawing.Font("RomanD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox.Location = new System.Drawing.Point(836, 145);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(190, 185);
            this.groupBox.TabIndex = 2;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Figures";
            // 
            // PolyBut
            // 
            this.PolyBut.AutoSize = true;
            this.PolyBut.Location = new System.Drawing.Point(6, 146);
            this.PolyBut.Name = "PolyBut";
            this.PolyBut.Size = new System.Drawing.Size(98, 26);
            this.PolyBut.TabIndex = 0;
            this.PolyBut.TabStop = true;
            this.PolyBut.Text = "Polygon";
            this.PolyBut.UseVisualStyleBackColor = true;
            this.PolyBut.CheckedChanged += new System.EventHandler(this.PolyBut_CheckedChanged);
            // 
            // BrokenBut
            // 
            this.BrokenBut.AutoSize = true;
            this.BrokenBut.Location = new System.Drawing.Point(6, 116);
            this.BrokenBut.Name = "BrokenBut";
            this.BrokenBut.Size = new System.Drawing.Size(136, 26);
            this.BrokenBut.TabIndex = 0;
            this.BrokenBut.TabStop = true;
            this.BrokenBut.Text = "Broken Line";
            this.BrokenBut.UseVisualStyleBackColor = true;
            this.BrokenBut.CheckedChanged += new System.EventHandler(this.BrokenBut_CheckedChanged);
            // 
            // EllipseBut
            // 
            this.EllipseBut.AutoSize = true;
            this.EllipseBut.Location = new System.Drawing.Point(6, 86);
            this.EllipseBut.Name = "EllipseBut";
            this.EllipseBut.Size = new System.Drawing.Size(86, 26);
            this.EllipseBut.TabIndex = 0;
            this.EllipseBut.TabStop = true;
            this.EllipseBut.Text = "Ellipse";
            this.EllipseBut.UseVisualStyleBackColor = true;
            this.EllipseBut.CheckedChanged += new System.EventHandler(this.EllipseBut_CheckedChanged);
            // 
            // RectBut
            // 
            this.RectBut.AutoSize = true;
            this.RectBut.Location = new System.Drawing.Point(6, 56);
            this.RectBut.Name = "RectBut";
            this.RectBut.Size = new System.Drawing.Size(116, 26);
            this.RectBut.TabIndex = 0;
            this.RectBut.TabStop = true;
            this.RectBut.Text = "Rectangel";
            this.RectBut.UseVisualStyleBackColor = true;
            this.RectBut.CheckedChanged += new System.EventHandler(this.RectBut_CheckedChanged);
            // 
            // LineBut
            // 
            this.LineBut.AutoSize = true;
            this.LineBut.Location = new System.Drawing.Point(6, 26);
            this.LineBut.Name = "LineBut";
            this.LineBut.Size = new System.Drawing.Size(66, 26);
            this.LineBut.TabIndex = 0;
            this.LineBut.TabStop = true;
            this.LineBut.Text = "Line";
            this.LineBut.UseVisualStyleBackColor = true;
            this.LineBut.CheckedChanged += new System.EventHandler(this.LineBut_CheckedChanged);
            // 
            // RbBox
            // 
            this.RbBox.Font = new System.Drawing.Font("RomanD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RbBox.Location = new System.Drawing.Point(841, 112);
            this.RbBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RbBox.Name = "RbBox";
            this.RbBox.Size = new System.Drawing.Size(56, 29);
            this.RbBox.TabIndex = 1;
            this.RbBox.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RbBox.ValueChanged += new System.EventHandler(this.RbBox_ValueChanged);
            // 
            // GbBox
            // 
            this.GbBox.Font = new System.Drawing.Font("RomanD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GbBox.Location = new System.Drawing.Point(903, 112);
            this.GbBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GbBox.Name = "GbBox";
            this.GbBox.Size = new System.Drawing.Size(56, 29);
            this.GbBox.TabIndex = 1;
            this.GbBox.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GbBox.ValueChanged += new System.EventHandler(this.GbBox_ValueChanged);
            // 
            // BbBox
            // 
            this.BbBox.Font = new System.Drawing.Font("RomanD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BbBox.Location = new System.Drawing.Point(965, 112);
            this.BbBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.BbBox.Name = "BbBox";
            this.BbBox.Size = new System.Drawing.Size(56, 29);
            this.BbBox.TabIndex = 1;
            this.BbBox.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.BbBox.ValueChanged += new System.EventHandler(this.BbBox_ValueChanged);
            // 
            // WidthBox
            // 
            this.WidthBox.Location = new System.Drawing.Point(842, 369);
            this.WidthBox.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.WidthBox.Name = "WidthBox";
            this.WidthBox.Size = new System.Drawing.Size(58, 27);
            this.WidthBox.TabIndex = 3;
            this.WidthBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WidthBox.ValueChanged += new System.EventHandler(this.WidthBox_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("RomanD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(842, 346);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("RomanD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(841, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 30);
            this.label2.TabIndex = 5;
            this.label2.Text = "Borders";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("RomanD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(841, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 30);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fill";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 618);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WidthBox);
            this.Controls.Add(this.BbBox);
            this.Controls.Add(this.GbBox);
            this.Controls.Add(this.RbBox);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.BBox);
            this.Controls.Add(this.GBox);
            this.Controls.Add(this.RBox);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BBox)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RbBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GbBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BbBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.NumericUpDown RBox;
        private System.Windows.Forms.NumericUpDown GBox;
        private System.Windows.Forms.NumericUpDown BBox;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.RadioButton PolyBut;
        private System.Windows.Forms.RadioButton BrokenBut;
        private System.Windows.Forms.RadioButton EllipseBut;
        private System.Windows.Forms.RadioButton RectBut;
        private System.Windows.Forms.RadioButton LineBut;
        private System.Windows.Forms.NumericUpDown RbBox;
        private System.Windows.Forms.NumericUpDown GbBox;
        private System.Windows.Forms.NumericUpDown BbBox;
        private System.Windows.Forms.NumericUpDown WidthBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

