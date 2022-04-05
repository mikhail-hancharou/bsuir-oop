﻿namespace BankSystem
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.mainTab = new System.Windows.Forms.TabControl();
            this.cabinetTab = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.billsLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.namesBox = new System.Windows.Forms.GroupBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.allMoneyBox = new System.Windows.Forms.GroupBox();
            this.moneyLabel = new System.Windows.Forms.Label();
            this.clownBox = new System.Windows.Forms.PictureBox();
            this.opportunityTab = new System.Windows.Forms.TabPage();
            this.BillButton = new System.Windows.Forms.Button();
            this.BankComboBox = new System.Windows.Forms.ComboBox();
            this.BillPanel = new System.Windows.Forms.Panel();
            this.BillLabel = new System.Windows.Forms.Label();
            this.requestTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelRequest = new System.Windows.Forms.TableLayoutPanel();
            this.BillcomboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mainTab.SuspendLayout();
            this.cabinetTab.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.namesBox.SuspendLayout();
            this.allMoneyBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clownBox)).BeginInit();
            this.opportunityTab.SuspendLayout();
            this.requestTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTab
            // 
            this.mainTab.Controls.Add(this.cabinetTab);
            this.mainTab.Controls.Add(this.opportunityTab);
            this.mainTab.Controls.Add(this.requestTab);
            this.mainTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTab.Font = new System.Drawing.Font("RomanD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mainTab.ItemSize = new System.Drawing.Size(65, 25);
            this.mainTab.Location = new System.Drawing.Point(0, 0);
            this.mainTab.Name = "mainTab";
            this.mainTab.SelectedIndex = 2;
            this.mainTab.Size = new System.Drawing.Size(1282, 653);
            this.mainTab.TabIndex = 0;
            // 
            // cabinetTab
            // 
            this.cabinetTab.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cabinetTab.Controls.Add(this.panel3);
            this.cabinetTab.Controls.Add(this.panel2);
            this.cabinetTab.Controls.Add(this.panel1);
            this.cabinetTab.Font = new System.Drawing.Font("RomanD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cabinetTab.Location = new System.Drawing.Point(4, 29);
            this.cabinetTab.Name = "cabinetTab";
            this.cabinetTab.Padding = new System.Windows.Forms.Padding(3);
            this.cabinetTab.Size = new System.Drawing.Size(1274, 620);
            this.cabinetTab.TabIndex = 0;
            this.cabinetTab.Text = "Cabinet";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Location = new System.Drawing.Point(790, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(481, 614);
            this.panel3.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.billsLabel);
            this.panel2.Location = new System.Drawing.Point(309, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(475, 614);
            this.panel2.TabIndex = 5;
            // 
            // billsLabel
            // 
            this.billsLabel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.billsLabel.Location = new System.Drawing.Point(52, 11);
            this.billsLabel.Name = "billsLabel";
            this.billsLabel.Size = new System.Drawing.Size(375, 33);
            this.billsLabel.TabIndex = 0;
            this.billsLabel.Text = "Bills";
            this.billsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.namesBox);
            this.panel1.Controls.Add(this.allMoneyBox);
            this.panel1.Controls.Add(this.clownBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 614);
            this.panel1.TabIndex = 4;
            // 
            // namesBox
            // 
            this.namesBox.Controls.Add(this.nameLabel);
            this.namesBox.Controls.Add(this.lastNameLabel);
            this.namesBox.Location = new System.Drawing.Point(116, -3);
            this.namesBox.Name = "namesBox";
            this.namesBox.Size = new System.Drawing.Size(180, 113);
            this.namesBox.TabIndex = 6;
            this.namesBox.TabStop = false;
            // 
            // nameLabel
            // 
            this.nameLabel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.nameLabel.Location = new System.Drawing.Point(6, 25);
            this.nameLabel.MaximumSize = new System.Drawing.Size(168, 22);
            this.nameLabel.MinimumSize = new System.Drawing.Size(168, 22);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(168, 22);
            this.nameLabel.TabIndex = 5;
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lastNameLabel.Location = new System.Drawing.Point(6, 72);
            this.lastNameLabel.MaximumSize = new System.Drawing.Size(168, 22);
            this.lastNameLabel.MinimumSize = new System.Drawing.Size(168, 22);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(168, 22);
            this.lastNameLabel.TabIndex = 5;
            // 
            // allMoneyBox
            // 
            this.allMoneyBox.Controls.Add(this.moneyLabel);
            this.allMoneyBox.Location = new System.Drawing.Point(5, 116);
            this.allMoneyBox.Name = "allMoneyBox";
            this.allMoneyBox.Size = new System.Drawing.Size(291, 56);
            this.allMoneyBox.TabIndex = 3;
            this.allMoneyBox.TabStop = false;
            this.allMoneyBox.Text = "Total Money";
            // 
            // moneyLabel
            // 
            this.moneyLabel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.moneyLabel.Location = new System.Drawing.Point(6, 25);
            this.moneyLabel.MaximumSize = new System.Drawing.Size(279, 22);
            this.moneyLabel.MinimumSize = new System.Drawing.Size(279, 22);
            this.moneyLabel.Name = "moneyLabel";
            this.moneyLabel.Size = new System.Drawing.Size(279, 22);
            this.moneyLabel.TabIndex = 5;
            // 
            // clownBox
            // 
            this.clownBox.Image = ((System.Drawing.Image)(resources.GetObject("clownBox.Image")));
            this.clownBox.Location = new System.Drawing.Point(5, 0);
            this.clownBox.Name = "clownBox";
            this.clownBox.Size = new System.Drawing.Size(105, 110);
            this.clownBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.clownBox.TabIndex = 1;
            this.clownBox.TabStop = false;
            // 
            // opportunityTab
            // 
            this.opportunityTab.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.opportunityTab.Controls.Add(this.label1);
            this.opportunityTab.Controls.Add(this.BillcomboBox);
            this.opportunityTab.Controls.Add(this.BillButton);
            this.opportunityTab.Controls.Add(this.BankComboBox);
            this.opportunityTab.Controls.Add(this.BillPanel);
            this.opportunityTab.Controls.Add(this.BillLabel);
            this.opportunityTab.Font = new System.Drawing.Font("RomanD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.opportunityTab.Location = new System.Drawing.Point(4, 29);
            this.opportunityTab.Name = "opportunityTab";
            this.opportunityTab.Padding = new System.Windows.Forms.Padding(3);
            this.opportunityTab.Size = new System.Drawing.Size(1274, 620);
            this.opportunityTab.TabIndex = 1;
            this.opportunityTab.Text = "Opportunity";
            // 
            // BillButton
            // 
            this.BillButton.Location = new System.Drawing.Point(74, 373);
            this.BillButton.Name = "BillButton";
            this.BillButton.Size = new System.Drawing.Size(232, 29);
            this.BillButton.TabIndex = 10;
            this.BillButton.Text = "button1";
            this.BillButton.UseVisualStyleBackColor = true;
            // 
            // BankComboBox
            // 
            this.BankComboBox.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BankComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BankComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BankComboBox.Font = new System.Drawing.Font("RomanD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BankComboBox.Location = new System.Drawing.Point(8, 76);
            this.BankComboBox.Name = "BankComboBox";
            this.BankComboBox.Size = new System.Drawing.Size(365, 30);
            this.BankComboBox.TabIndex = 7;
            this.BankComboBox.Visible = false;
            // 
            // BillPanel
            // 
            this.BillPanel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BillPanel.Location = new System.Drawing.Point(10, 140);
            this.BillPanel.Name = "BillPanel";
            this.BillPanel.Size = new System.Drawing.Size(363, 190);
            this.BillPanel.TabIndex = 9;
            // 
            // BillLabel
            // 
            this.BillLabel.AutoSize = true;
            this.BillLabel.Font = new System.Drawing.Font("RomanD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BillLabel.Location = new System.Drawing.Point(8, 13);
            this.BillLabel.Name = "BillLabel";
            this.BillLabel.Size = new System.Drawing.Size(365, 60);
            this.BillLabel.TabIndex = 8;
            this.BillLabel.Text = "Choose bank where you want\r\nto create your bill";
            this.BillLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // requestTab
            // 
            this.requestTab.Controls.Add(this.tableLayoutPanelRequest);
            this.requestTab.Location = new System.Drawing.Point(4, 29);
            this.requestTab.Name = "requestTab";
            this.requestTab.Size = new System.Drawing.Size(1274, 620);
            this.requestTab.TabIndex = 2;
            this.requestTab.Text = "Requests";
            // 
            // tableLayoutPanelRequest
            // 
            this.tableLayoutPanelRequest.AutoScroll = true;
            this.tableLayoutPanelRequest.AutoSize = true;
            this.tableLayoutPanelRequest.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tableLayoutPanelRequest.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanelRequest.ColumnCount = 1;
            this.tableLayoutPanelRequest.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.23858F));
            this.tableLayoutPanelRequest.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.76142F));
            this.tableLayoutPanelRequest.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1075F));
            this.tableLayoutPanelRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelRequest.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelRequest.Name = "tableLayoutPanelRequest";
            this.tableLayoutPanelRequest.RowCount = 1;
            this.tableLayoutPanelRequest.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelRequest.Size = new System.Drawing.Size(1274, 620);
            this.tableLayoutPanelRequest.TabIndex = 0;
            // 
            // BillcomboBox
            // 
            this.BillcomboBox.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BillcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BillcomboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BillcomboBox.Font = new System.Drawing.Font("RomanD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BillcomboBox.Location = new System.Drawing.Point(614, 76);
            this.BillcomboBox.Name = "BillcomboBox";
            this.BillcomboBox.Size = new System.Drawing.Size(365, 30);
            this.BillcomboBox.TabIndex = 7;
            this.BillcomboBox.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("RomanD", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(614, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(404, 60);
            this.label1.TabIndex = 8;
            this.label1.Text = "Choose your bill where you want\r\nto get credit or installment\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1282, 653);
            this.Controls.Add(this.mainTab);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.mainTab.ResumeLayout(false);
            this.cabinetTab.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.namesBox.ResumeLayout(false);
            this.allMoneyBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clownBox)).EndInit();
            this.opportunityTab.ResumeLayout(false);
            this.opportunityTab.PerformLayout();
            this.requestTab.ResumeLayout(false);
            this.requestTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTab;
        private System.Windows.Forms.TabPage cabinetTab;
        private System.Windows.Forms.TabPage opportunityTab;
        private System.Windows.Forms.PictureBox clownBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox allMoneyBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.Label moneyLabel;
        private System.Windows.Forms.GroupBox namesBox;
        private System.Windows.Forms.Label billsLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage requestTab;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRequest;
        private System.Windows.Forms.Button BillButton;
        private System.Windows.Forms.ComboBox BankComboBox;
        private System.Windows.Forms.Panel BillPanel;
        private System.Windows.Forms.Label BillLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox BillcomboBox;
    }
}