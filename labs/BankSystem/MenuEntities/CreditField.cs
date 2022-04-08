using BankSystem.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;


namespace BankSystem.MenuEntities
{
    class CreditField
    {
        public Panel FieldPanel { get; set; }
        public Label BankName { get; set; }
        public Label BillNumberNPeriod { get; set; }
        public Label RemainderNPercent { get; set; }
        public Credit Credit { get; set; }
        public Installement Installement { get; set; }
        private Bill Bill { get; set; }
        public TableLayoutPanel TablePanel { get; set; }

        public CreditField(Credit credit, Bill bill, TableLayoutPanel tablePanel)
        {
            using AppContext db = new AppContext();
            TablePanel = tablePanel;
            Bill = bill;
            FieldPanel = CreatePanel();
            if (credit.Confirmed)
            {
                BillNumberNPeriod.Text += credit.ConfirmedTime.AddMonths(credit.Months).ToString();
                RemainderNPercent.Text += credit.Money + " Percent: " + db.Banks.FirstOrDefault(b => b.BID == Bill.BID).OverPaymentPercent.ToString() + " CREDIT";
            }
            else
            {
                BillNumberNPeriod.Text = "Requested";
            }
        }

        public CreditField(Installement installement, Bill bill, TableLayoutPanel tablePanel)
        {
            TablePanel = tablePanel;
            Bill = bill;
            FieldPanel = CreatePanel();
            if (installement.Confirmed)
            {
                BillNumberNPeriod.Text += installement.ConfirmedTime.AddMonths(installement.Months).ToString();
                RemainderNPercent.Text += installement.Money + " INSTALLEMENT";
            }
            else
            {
                BillNumberNPeriod.Text = "Requested";
            }
        }

        private Panel CreatePanel()
        {
            using AppContext db = new AppContext();
            FieldPanel = new Panel();
            FieldPanel.Dock = DockStyle.Top;
            FieldPanel.BorderStyle = BorderStyle.Fixed3D;
            FieldPanel.Margin = new Padding(3, 3, 3, 0);

            BankName = new Label();
            BankName.Size = new Size(400, 30);
            BankName.ForeColor = Color.Black;
            BankName.Dock = DockStyle.Top;
            BankName.TextAlign = ContentAlignment.MiddleLeft;
            BankName.Text = "Bank: " + db.Banks.FirstOrDefault(b => b.BID == Bill.BID).Name;

            BillNumberNPeriod = new Label();
            BillNumberNPeriod.Size = new Size(400, 30);
            BillNumberNPeriod.ForeColor = Color.Black;
            BillNumberNPeriod.Dock = DockStyle.Top;
            BillNumberNPeriod.TextAlign = ContentAlignment.MiddleLeft;
            BillNumberNPeriod.Text = Bill.BillNumber  + " Last payment: ";

            RemainderNPercent = new Label();
            RemainderNPercent.Size = new Size(400, 30);
            RemainderNPercent.ForeColor = Color.Black;
            RemainderNPercent.Dock = DockStyle.Top;
            RemainderNPercent.TextAlign = ContentAlignment.MiddleLeft;
            RemainderNPercent.Text = "Remainder: ";

            FieldPanel.Controls.Add(BankName);
            FieldPanel.Controls.Add(BillNumberNPeriod);
            FieldPanel.Controls.Add(RemainderNPercent);

            return FieldPanel;
        }
    }
}
