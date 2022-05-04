using BankSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BankSystem.MenuEntities
{
    public class TransferRequest
    {
        public Panel FieldPanel { get; set; }
        public Button AproveButton { get; set; }
        public Button DeniedButton { get; set; }
        public Label CompanyInfo { get; set; }
        public BillsNSalary BillsNSalary { get; set; }
        public Company Company { get; set; }
        public TableLayoutPanel TablePanel { get; set; }

        public TransferRequest(BillsNSalary billsNSalary, Company company, TableLayoutPanel tablePanel)
        {
            TablePanel = tablePanel;
            BillsNSalary = billsNSalary;
            Company = company;
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
            CompanyInfo.Text = $"From: {BillsNSalary.FromBill} | To: {BillsNSalary.BillNumber} | Amount: {BillsNSalary.Salary}";

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
            Company.BillsNSalaries.Remove(BillsNSalary);
            db.BillsNSalaries.Remove(BillsNSalary);
            if (BillsNSalary.BillNumber == Company.UNP)
            {
                Company.Money += BillsNSalary.Salary;
                Company company = db.Companies.FirstOrDefault(c => c.UNP == BillsNSalary.FromBill);
                company.Money -= BillsNSalary.Salary;
                CompanyTransfer companyTransfer = new CompanyTransfer
                {
                    From = BillsNSalary.FromBill,
                    Amount = BillsNSalary.Salary,
                    DestBill = Company.UNP,
                };
                Company.CompanyTransfer.Add(companyTransfer);
                db.CompanyTransfer.Add(companyTransfer);
                db.Companies.Update(Company);
            }
            else
            {
                Bill bill = db.Bills.FirstOrDefault(b => b.BillNumber == BillsNSalary.BillNumber);
                bill.Money += BillsNSalary.Salary;
                Company company = db.Companies
                    .Include(c => c.CompanyTransfer)
                    .FirstOrDefault(c => c.UNP == BillsNSalary.FromBill);
                company.Money -= BillsNSalary.Salary;
                CompanyTransfer companyTransfer = new CompanyTransfer
                {
                    From = BillsNSalary.FromBill,
                    Amount = BillsNSalary.Salary,
                    DestBill = bill.BillNumber,
                };
                company.CompanyTransfer.Add(companyTransfer);//Company
                db.CompanyTransfer.Add(companyTransfer);
                db.Bills.Update(bill);
            }

            db.Logs.Add(new Log($"{Company.BID}", $" {DateTime.UtcNow.ToString()} Aprove transfer request to - {BillsNSalary.BillNumber}"));
            db.SaveChanges();
        }

        private void DeniedButton_Click(object sender, EventArgs e)
        {
            TablePanel.Controls.Remove(FieldPanel);
            AppContext db = new AppContext();
            Company.BillsNSalaries.Remove(BillsNSalary);
            db.BillsNSalaries.Remove(BillsNSalary);
            db.Companies.Update(Company);
            db.Logs.Add(new Log($"{Company.BID} ", $"{DateTime.UtcNow.ToString()} Denied transfer request to - {BillsNSalary.BillNumber}"));
            db.SaveChanges();
        }
    }
}

