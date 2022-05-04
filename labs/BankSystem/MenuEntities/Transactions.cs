using BankSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BankSystem.MenuEntities
{
    class Transactions
    {
        public Panel FieldPanel { get; set; }
        public Button Undo { get; set; }
        public Label TransactionInfo { get; set; }
        public Transaction Transaction { get; set; }
        public Bill Bill { get; set; }
        public TableLayoutPanel TablePanel { get; set; }

        public Transactions(Transaction transaction, Bill bill, TableLayoutPanel tablePanel)
        {
            TablePanel = tablePanel;
            Transaction = transaction;
            Bill = bill;
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
            TransactionInfo.Text = $"Amount: {Transaction.Amount} | From: {Bill.BillNumber} | To: {Transaction.DestBill}";

            FieldPanel.Controls.Add(Undo);
            FieldPanel.Controls.Add(TransactionInfo);

            Undo.Click += UndoButton_Click;
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            TablePanel.Controls.Remove(FieldPanel);
            AppContext db = new AppContext();
            Bill bill = db.Bills.FirstOrDefault(b => b.BillNumber == Transaction.DestBill);
            bill.Money -= Transaction.Amount;
            Bill.Money += Transaction.Amount;
            Bill.Transactions.Remove(Transaction);
            db.Bills.Update(bill);
            db.Bills.Update(Bill);
            db.Transactions.Remove(Transaction);
            db.Logs.Add(new Log("", $"{DateTime.UtcNow.ToString()} Undo transaction to - {Transaction.DestBill}"));

            db.SaveChanges();
        }
    }
}

