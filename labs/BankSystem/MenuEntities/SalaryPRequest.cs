using BankSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BankSystem.MenuEntities
{
    public class SalaryPRequest
    {
        public Panel FieldPanel { get; set; }
        public Button AproveButton { get; set; }
        public Button DeniedButton { get; set; }
        public Label CompanyInfo { get; set; }
        public Company Company { get; set; }
        public Outsider Outsider { get; set; }
        public TableLayoutPanel TablePanel { get; set; }

        public SalaryPRequest(Company company, Outsider outsider, TableLayoutPanel tablePanel)
        {
            TablePanel = tablePanel;
            Company = company;
            Outsider = outsider;
            FieldPanel = new Panel();
            FieldPanel.Size = new Size(600, 50);
            FieldPanel.Dock = DockStyle.Top;
            FieldPanel.BorderStyle = BorderStyle.Fixed3D;
            FieldPanel.Margin = new Padding(3, 3, 3, 0);

            AproveButton = new Button();
            AproveButton.BackColor = System.Drawing.Color.FromArgb(185, 209, 234);
            AproveButton.Size = new Size(80, 50);
            AproveButton.TextAlign = ContentAlignment.MiddleCenter;
            AproveButton.Dock = DockStyle.Left;
            AproveButton.Text = "Aprove";

            DeniedButton = new Button();
            DeniedButton.BackColor = System.Drawing.Color.FromArgb(185, 209, 234);
            DeniedButton.Size = new Size(80, 50);
            DeniedButton.TextAlign = ContentAlignment.MiddleCenter;
            DeniedButton.Dock = DockStyle.Left;
            DeniedButton.Text = "Denied";

            CompanyInfo = new Label();
            CompanyInfo.ForeColor = Color.Black;
            CompanyInfo.Dock = DockStyle.Fill;
            CompanyInfo.TextAlign = ContentAlignment.MiddleCenter;
            CompanyInfo.Text = $"Name: {Company.Name} | UNP: {Company.UNP} | Address: {Company.Address}";

            FieldPanel.Controls.Add(AproveButton);
            FieldPanel.Controls.Add(DeniedButton);
            FieldPanel.Controls.Add(CompanyInfo);

            DeniedButton.Click += DeniedButton_Click;
            AproveButton.Click += AproveButton_Click;
        }

        private void AproveButton_Click(object sender, EventArgs e)
        {
            TablePanel.Controls.Remove(FieldPanel);
            AppContext db = new AppContext();
            Company.Confirmed = true;
            Company.Requested = false;
            db.Companies.Update(Company);
            db.Logs.Add(new Log($"{Company.BID}", $"{DateTime.UtcNow.ToString()} Aprove salary project request - {Company.UNP}"));
            db.SaveChanges();
        }

        private void DeniedButton_Click(object sender, EventArgs e)
        {
            TablePanel.Controls.Remove(FieldPanel);
            AppContext db = new AppContext();
            db.Companies.Remove(Company);
            Outsider.UNP = null;
            db.Outsiders.Update(Outsider);
            db.Logs.Add(new Log($"{Company.BID}", $"{DateTime.UtcNow.ToString()} Denied salary project request - {Company.UNP}"));
            db.SaveChanges();
        }
    }
}

