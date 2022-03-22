namespace BankSystem
{
    partial class LoginForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.regButton = new System.Windows.Forms.Button();
            this.undButLabel = new System.Windows.Forms.Label();
            this.pasLabel = new System.Windows.Forms.Label();
            this.logLabel = new System.Windows.Forms.Label();
            this.logButton = new System.Windows.Forms.Button();
            this.pasBox = new System.Windows.Forms.TextBox();
            this.logBox = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Stencil", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.label1.Size = new System.Drawing.Size(800, 100);
            this.label1.TabIndex = 2;
            this.label1.Tag = "";
            this.label1.Text = "Equilibrium";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.regButton);
            this.panel1.Controls.Add(this.undButLabel);
            this.panel1.Controls.Add(this.pasLabel);
            this.panel1.Controls.Add(this.logLabel);
            this.panel1.Controls.Add(this.logButton);
            this.panel1.Controls.Add(this.pasBox);
            this.panel1.Controls.Add(this.logBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 3;
            // 
            // regButton
            // 
            this.regButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.regButton.Font = new System.Drawing.Font("RomanD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.regButton.Location = new System.Drawing.Point(322, 392);
            this.regButton.Name = "regButton";
            this.regButton.Size = new System.Drawing.Size(156, 34);
            this.regButton.TabIndex = 4;
            this.regButton.Text = "Register";
            this.regButton.UseVisualStyleBackColor = false;
            this.regButton.Click += new System.EventHandler(this.regButton_Click);
            // 
            // undButLabel
            // 
            this.undButLabel.AutoSize = true;
            this.undButLabel.Font = new System.Drawing.Font("RomanD", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.undButLabel.Location = new System.Drawing.Point(322, 370);
            this.undButLabel.Name = "undButLabel";
            this.undButLabel.Size = new System.Drawing.Size(156, 19);
            this.undButLabel.TabIndex = 6;
            this.undButLabel.Text = "I\'M NEW CUSTOMER";
            this.undButLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pasLabel
            // 
            this.pasLabel.AutoSize = true;
            this.pasLabel.Font = new System.Drawing.Font("RomanD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pasLabel.Location = new System.Drawing.Point(203, 276);
            this.pasLabel.MinimumSize = new System.Drawing.Size(0, 27);
            this.pasLabel.Name = "pasLabel";
            this.pasLabel.Size = new System.Drawing.Size(91, 27);
            this.pasLabel.TabIndex = 5;
            this.pasLabel.Text = "Password";
            // 
            // logLabel
            // 
            this.logLabel.AutoSize = true;
            this.logLabel.Font = new System.Drawing.Font("RomanD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.logLabel.Location = new System.Drawing.Point(238, 228);
            this.logLabel.MinimumSize = new System.Drawing.Size(0, 27);
            this.logLabel.Name = "logLabel";
            this.logLabel.Size = new System.Drawing.Size(56, 27);
            this.logLabel.TabIndex = 5;
            this.logLabel.Text = "Login";
            // 
            // logButton
            // 
            this.logButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.logButton.Font = new System.Drawing.Font("RomanD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.logButton.Location = new System.Drawing.Point(349, 306);
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(100, 34);
            this.logButton.TabIndex = 4;
            this.logButton.Text = "Sign in";
            this.logButton.UseVisualStyleBackColor = false;
            this.logButton.Click += new System.EventHandler(this.logButton_Click);
            // 
            // pasBox
            // 
            this.pasBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pasBox.Location = new System.Drawing.Point(300, 273);
            this.pasBox.MaxLength = 5;
            this.pasBox.Name = "pasBox";
            this.pasBox.Size = new System.Drawing.Size(200, 27);
            this.pasBox.TabIndex = 3;
            this.pasBox.UseSystemPasswordChar = true;
            this.pasBox.Click += new System.EventHandler(this.pasBox_Click);
            // 
            // logBox
            // 
            this.logBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logBox.Location = new System.Drawing.Point(300, 225);
            this.logBox.MaxLength = 5;
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(200, 27);
            this.logBox.TabIndex = 3;
            this.logBox.Click += new System.EventHandler(this.logBox_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "LoginForm";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox pasBox;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.Button logButton;
        private System.Windows.Forms.Label pasLabel;
        private System.Windows.Forms.Label logLabel;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label undButLabel;
        private System.Windows.Forms.Button regButton;
    }
}

