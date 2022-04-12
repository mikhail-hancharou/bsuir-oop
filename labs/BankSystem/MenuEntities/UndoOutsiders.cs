using BankSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BankSystem.MenuEntities
{
    public class UndoOutsiders
    {
        public Panel FieldPanel { get; set; }
        public Button Undo { get; set; }
        public Label TransactionInfo { get; set; }
        public CompanyTransfer CompanyTransfer { get; set; }
        public Company Company { get; set; }
        public TableLayoutPanel TablePanel { get; set; }

        public UndoOutsiders(CompanyTransfer companyTransfer, Company company, TableLayoutPanel tablePanel)
        {
            TablePanel = tablePanel;
            CompanyTransfer = companyTransfer;
            Company = company;
            FieldPanel = new Panel();
            FieldPanel.Size = new Size(600, 50);
            FieldPanel.Dock = DockStyle.Top;
            FieldPanel.BorderStyle = BorderStyle.Fixed3D;
            FieldPanel.Margin = new Padding(3, 3, 3, 0);

            Undo = new Button();
            Undo.BackColor = System.Drawing.Color.FromArgb(185, 209, 234);
            Undo.Size = new Size(80, 50);
            Undo.TextAlign = ContentAlignment.MiddleCenter;
            Undo.Dock = DockStyle.Left;
            Undo.Text = "Undo";

            TransactionInfo = new Label();
            TransactionInfo.ForeColor = Color.Black;
            TransactionInfo.Dock = DockStyle.Fill;
            TransactionInfo.TextAlign = ContentAlignment.MiddleCenter;
            TransactionInfo.Text = $"Amount: {CompanyTransfer.Amount} | To: {Company.Name} {CompanyTransfer.DestBill} | UNP: {Company.Name}";

            FieldPanel.Controls.Add(Undo);
            FieldPanel.Controls.Add(TransactionInfo);

            Undo.Click += UndoButton_Click;
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            TablePanel.Controls.Remove(FieldPanel);
            AppContext db = new AppContext();
            if (Company.UNP == CompanyTransfer.DestBill)
            {
                Company.Money -= CompanyTransfer.Amount;
                db.Companies.Update(Company);
            }
            else
            {
                Bill bill = db.Bills.FirstOrDefault(b => b.BillNumber == CompanyTransfer.DestBill);
                bill.Money -= CompanyTransfer.Amount;
                db.Bills.Update(bill);
            }
            Company company = db.Companies.FirstOrDefault(c => c.UNP == CompanyTransfer.From);
            company.Money += CompanyTransfer.Amount;
            db.CompanyTransfer.Remove(CompanyTransfer);
            Company.CompanyTransfer.Remove(CompanyTransfer);     
            db.Companies.Update(company);
            db.SaveChanges();
        }
    }
}

