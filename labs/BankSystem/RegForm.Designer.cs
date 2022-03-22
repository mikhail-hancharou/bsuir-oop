namespace BankSystem
{
    partial class RegForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lNameBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.passwBox = new System.Windows.Forms.TextBox();
            this.paspNumberLabel = new System.Windows.Forms.Label();
            this.passpNumbBox = new System.Windows.Forms.TextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.loginBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Font = new System.Drawing.Font("RomanD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(324, 320);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "Register";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.RegButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("RomanD", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(322, 370);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "I\'M NEW CUSTOMER";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Font = new System.Drawing.Font("RomanD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lastNameLabel.Location = new System.Drawing.Point(14, 211);
            this.lastNameLabel.MinimumSize = new System.Drawing.Size(0, 27);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(105, 27);
            this.lastNameLabel.TabIndex = 5;
            this.lastNameLabel.Text = "Last Name";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("RomanD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nameLabel.Location = new System.Drawing.Point(60, 163);
            this.nameLabel.MinimumSize = new System.Drawing.Size(0, 27);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(59, 27);
            this.nameLabel.TabIndex = 5;
            this.nameLabel.Text = "Name";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Font = new System.Drawing.Font("RomanD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(354, 404);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 34);
            this.button2.TabIndex = 4;
            this.button2.Text = "Sign in";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.SignIn_Click);
            // 
            // lNameBox
            // 
            this.lNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lNameBox.Location = new System.Drawing.Point(125, 208);
            this.lNameBox.MaxLength = 5;
            this.lNameBox.Name = "lNameBox";
            this.lNameBox.Size = new System.Drawing.Size(200, 27);
            this.lNameBox.TabIndex = 3;
            this.lNameBox.Click += new System.EventHandler(this.lNameBox_Click);
            // 
            // nameBox
            // 
            this.nameBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameBox.Location = new System.Drawing.Point(125, 160);
            this.nameBox.MaxLength = 5;
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(200, 27);
            this.nameBox.TabIndex = 3;
            this.nameBox.Click += new System.EventHandler(this.nameBox_Click);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Stencil", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.label4.Size = new System.Drawing.Size(800, 100);
            this.label4.TabIndex = 2;
            this.label4.Tag = "";
            this.label4.Text = "Equilibrium";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.dateBox);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.passwBox);
            this.panel1.Controls.Add(this.paspNumberLabel);
            this.panel1.Controls.Add(this.passpNumbBox);
            this.panel1.Controls.Add(this.idLabel);
            this.panel1.Controls.Add(this.loginBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lastNameLabel);
            this.panel1.Controls.Add(this.nameLabel);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.lNameBox);
            this.panel1.Controls.Add(this.nameBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 3;
            // 
            // dateBox
            // 
            this.dateBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateBox.Location = new System.Drawing.Point(560, 208);
            this.dateBox.MaxLength = 8;
            this.dateBox.Name = "dateBox";
            this.dateBox.Size = new System.Drawing.Size(200, 27);
            this.dateBox.TabIndex = 3;
            this.dateBox.Click += new System.EventHandler(this.dateBox_Click);
            this.dateBox.Leave += new System.EventHandler(this.dateBox_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("RomanD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(463, 255);
            this.label11.MinimumSize = new System.Drawing.Size(0, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 27);
            this.label11.TabIndex = 5;
            this.label11.Text = "Password";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("RomanD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(358, 211);
            this.label10.MinimumSize = new System.Drawing.Size(0, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(196, 27);
            this.label10.TabIndex = 5;
            this.label10.Text = "Passport expiry date";
            // 
            // passwBox
            // 
            this.passwBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwBox.Location = new System.Drawing.Point(560, 252);
            this.passwBox.MaxLength = 5;
            this.passwBox.Name = "passwBox";
            this.passwBox.Size = new System.Drawing.Size(200, 27);
            this.passwBox.TabIndex = 3;
            this.passwBox.UseSystemPasswordChar = true;
            this.passwBox.Click += new System.EventHandler(this.passwBox_Click);
            // 
            // paspNumberLabel
            // 
            this.paspNumberLabel.AutoSize = true;
            this.paspNumberLabel.Font = new System.Drawing.Font("RomanD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.paspNumberLabel.Location = new System.Drawing.Point(393, 163);
            this.paspNumberLabel.MinimumSize = new System.Drawing.Size(0, 27);
            this.paspNumberLabel.Name = "paspNumberLabel";
            this.paspNumberLabel.Size = new System.Drawing.Size(161, 27);
            this.paspNumberLabel.TabIndex = 5;
            this.paspNumberLabel.Text = "Passport number";
            // 
            // passpNumbBox
            // 
            this.passpNumbBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passpNumbBox.Location = new System.Drawing.Point(560, 160);
            this.passpNumbBox.MaxLength = 5;
            this.passpNumbBox.Name = "passpNumbBox";
            this.passpNumbBox.Size = new System.Drawing.Size(200, 27);
            this.passpNumbBox.TabIndex = 3;
            this.passpNumbBox.Click += new System.EventHandler(this.passpNumbBox_Click);
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Font = new System.Drawing.Font("RomanD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.idLabel.Location = new System.Drawing.Point(39, 255);
            this.idLabel.MinimumSize = new System.Drawing.Size(0, 27);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(80, 27);
            this.idLabel.TabIndex = 5;
            this.idLabel.Text = "ID/login";
            // 
            // loginBox
            // 
            this.loginBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginBox.Location = new System.Drawing.Point(125, 252);
            this.loginBox.MaxLength = 5;
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(200, 27);
            this.loginBox.TabIndex = 3;
            this.loginBox.Click += new System.EventHandler(this.loginBox_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("RomanD", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(288, 382);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(234, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "ALREADY HAVE AN ACCOUNT?";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RegForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "RegForm";
            this.Text = "RegForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox lNameBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox passwBox;
        private System.Windows.Forms.Label paspNumberLabel;
        private System.Windows.Forms.TextBox passpNumbBox;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.TextBox loginBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox dateBox;
    }
}