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
            this.RbBox = new System.Windows.Forms.NumericUpDown();
            this.GbBox = new System.Windows.Forms.NumericUpDown();
            this.BbBox = new System.Windows.Forms.NumericUpDown();
            this.WidthBox = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.backBut = new System.Windows.Forms.Button();
            this.retBut = new System.Windows.Forms.Button();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.XBox = new System.Windows.Forms.NumericUpDown();
            this.YBox = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.FigureBox = new System.Windows.Forms.ComboBox();
            this.serBut = new System.Windows.Forms.Button();
            this.DesBut = new System.Windows.Forms.Button();
            this.PlugBut = new System.Windows.Forms.Button();
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.fileComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RbBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GbBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BbBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YBox)).BeginInit();
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
            // backBut
            // 
            this.backBut.Enabled = false;
            this.backBut.Font = new System.Drawing.Font("RomanD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.backBut.Location = new System.Drawing.Point(842, 411);
            this.backBut.Name = "backBut";
            this.backBut.Size = new System.Drawing.Size(90, 29);
            this.backBut.TabIndex = 6;
            this.backBut.Text = "<--";
            this.backBut.UseVisualStyleBackColor = true;
            this.backBut.Click += new System.EventHandler(this.backBut_Click);
            // 
            // retBut
            // 
            this.retBut.Enabled = false;
            this.retBut.Font = new System.Drawing.Font("RomanD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.retBut.Location = new System.Drawing.Point(936, 411);
            this.retBut.Name = "retBut";
            this.retBut.Size = new System.Drawing.Size(90, 29);
            this.retBut.TabIndex = 7;
            this.retBut.Text = "-->";
            this.retBut.UseVisualStyleBackColor = true;
            this.retBut.Click += new System.EventHandler(this.retBut_Click);
            // 
            // comboBox
            // 
            this.comboBox.Font = new System.Drawing.Font("RomanD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(841, 471);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(184, 30);
            this.comboBox.TabIndex = 8;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // XBox
            // 
            this.XBox.Font = new System.Drawing.Font("RomanD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.XBox.Location = new System.Drawing.Point(842, 537);
            this.XBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.XBox.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.XBox.Name = "XBox";
            this.XBox.Size = new System.Drawing.Size(90, 29);
            this.XBox.TabIndex = 9;
            this.XBox.ValueChanged += new System.EventHandler(this.XBox_ValueChanged);
            // 
            // YBox
            // 
            this.YBox.Font = new System.Drawing.Font("RomanD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.YBox.Location = new System.Drawing.Point(936, 537);
            this.YBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.YBox.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.YBox.Name = "YBox";
            this.YBox.Size = new System.Drawing.Size(90, 29);
            this.YBox.TabIndex = 10;
            this.YBox.ValueChanged += new System.EventHandler(this.YBox_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(884, 570);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 11;
            this.button1.Text = "Draw";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Font = new System.Drawing.Font("RomanD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox.Location = new System.Drawing.Point(842, 507);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(77, 26);
            this.checkBox.TabIndex = 12;
            this.checkBox.Text = "Show";
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // FigureBox
            // 
            this.FigureBox.FormattingEnabled = true;
            this.FigureBox.Location = new System.Drawing.Point(841, 161);
            this.FigureBox.Name = "FigureBox";
            this.FigureBox.Size = new System.Drawing.Size(180, 28);
            this.FigureBox.TabIndex = 13;
            this.FigureBox.SelectedIndexChanged += new System.EventHandler(this.FigureBox_SelectedIndexChanged);
            // 
            // serBut
            // 
            this.serBut.Location = new System.Drawing.Point(884, 195);
            this.serBut.Name = "serBut";
            this.serBut.Size = new System.Drawing.Size(94, 29);
            this.serBut.TabIndex = 14;
            this.serBut.Text = "Ser";
            this.serBut.UseVisualStyleBackColor = true;
            this.serBut.Click += new System.EventHandler(this.serBut_Click);
            // 
            // DesBut
            // 
            this.DesBut.Location = new System.Drawing.Point(884, 240);
            this.DesBut.Name = "DesBut";
            this.DesBut.Size = new System.Drawing.Size(94, 29);
            this.DesBut.TabIndex = 15;
            this.DesBut.Text = "Des";
            this.DesBut.UseVisualStyleBackColor = true;
            this.DesBut.Click += new System.EventHandler(this.DesBut_Click);
            // 
            // PlugBut
            // 
            this.PlugBut.Location = new System.Drawing.Point(936, 367);
            this.PlugBut.Name = "PlugBut";
            this.PlugBut.Size = new System.Drawing.Size(90, 29);
            this.PlugBut.TabIndex = 16;
            this.PlugBut.Text = "Plugins";
            this.PlugBut.UseVisualStyleBackColor = true;
            this.PlugBut.Click += new System.EventHandler(this.PlugBut_Click);
            // 
            // fileTextBox
            // 
            this.fileTextBox.Location = new System.Drawing.Point(842, 316);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.Size = new System.Drawing.Size(183, 27);
            this.fileTextBox.TabIndex = 17;
            // 
            // fileComboBox
            // 
            this.fileComboBox.FormattingEnabled = true;
            this.fileComboBox.Location = new System.Drawing.Point(842, 282);
            this.fileComboBox.Name = "fileComboBox";
            this.fileComboBox.Size = new System.Drawing.Size(183, 28);
            this.fileComboBox.TabIndex = 18;
            this.fileComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 618);
            this.Controls.Add(this.fileComboBox);
            this.Controls.Add(this.fileTextBox);
            this.Controls.Add(this.PlugBut);
            this.Controls.Add(this.DesBut);
            this.Controls.Add(this.serBut);
            this.Controls.Add(this.FigureBox);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.YBox);
            this.Controls.Add(this.XBox);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.retBut);
            this.Controls.Add(this.backBut);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WidthBox);
            this.Controls.Add(this.BbBox);
            this.Controls.Add(this.GbBox);
            this.Controls.Add(this.RbBox);
            this.Controls.Add(this.BBox);
            this.Controls.Add(this.GBox);
            this.Controls.Add(this.RBox);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RbBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GbBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BbBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.NumericUpDown RBox;
        private System.Windows.Forms.NumericUpDown GBox;
        private System.Windows.Forms.NumericUpDown BBox;
        private System.Windows.Forms.NumericUpDown RbBox;
        private System.Windows.Forms.NumericUpDown GbBox;
        private System.Windows.Forms.NumericUpDown BbBox;
        private System.Windows.Forms.NumericUpDown WidthBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button backBut;
        private System.Windows.Forms.Button retBut;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.NumericUpDown XBox;
        private System.Windows.Forms.NumericUpDown YBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.ComboBox FigureBox;
        private System.Windows.Forms.Button serBut;
        private System.Windows.Forms.Button DesBut;
        private System.Windows.Forms.Button PlugBut;
        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.ComboBox fileComboBox;
    }
}

