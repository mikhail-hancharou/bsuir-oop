using BankSystem.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BankSystem.MenuEntities
{
    class BillField
    {
        public Panel FieldPanel { get; set; }
        public Label BankName { get; set; }
        public Label BillNumber { get; set; }
        public Label BillMoney { get; set; }
        public Bill Bill { get; set; }
        public TableLayoutPanel TablePanel { get; set; }

        public BillField(Bill bill, TableLayoutPanel tablePanel)
        {
            Bill = bill;
            TablePanel = tablePanel;
            FieldPanel = new Panel();
            FieldPanel.Dock = DockStyle.Top;
            FieldPanel.BorderStyle = BorderStyle.Fixed3D;
            FieldPanel.Margin = new Padding(3, 3, 3, 0);

            BankName = new Label();
            BankName.Size = new Size(400, 30);
            BankName.ForeColor = Color.Black;
            BankName.Dock = DockStyle.Top;
            BankName.TextAlign = ContentAlignment.MiddleLeft;
            BankName.Text = "Bank: " + Bill.BID;

            BillNumber = new Label();
            BillNumber.Size = new Size(400, 30);
            BillNumber.ForeColor = Color.Black;
            BillNumber.Dock = DockStyle.Top;
            BillNumber.TextAlign = ContentAlignment.MiddleLeft;
            BillNumber.Text = Bill.BillNumber;

            BillMoney = new Label();
            BillMoney.Size = new Size(400, 30);
            BillMoney.ForeColor = Color.Black;
            BillMoney.Dock = DockStyle.Top;
            BillMoney.TextAlign = ContentAlignment.MiddleLeft;
            BillMoney.Text = "Money: " + Bill.Money.ToString();

            FieldPanel.Controls.Add(BankName);
            FieldPanel.Controls.Add(BillNumber);
            FieldPanel.Controls.Add(BillMoney);
        }
    }
}
