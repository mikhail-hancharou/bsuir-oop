using BankSystem.Entities;
using BankSystem.MenuEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BankSystem
{
    public partial class MainMenu : Form
    {
        public object MainUser { get; set; } //Client mainUser { get; set; }
        public MainMenu(object mainUser)
        {
            this.MainUser = mainUser;
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            if (MainUser is Client)
            {
                MainUser = MainUser as Client;
                InizializeMenu();
                Opportunity();
            }
            else if (MainUser is Outsider)
            {
                //TODO
            }
            else if (MainUser is Operator)
            {
                //TODO
            }
            else if (MainUser is Manager)
            {
                MainUser = MainUser as Manager;
                Aprovement();
            }
            else if (MainUser is Admin)
            {
                //TODO
            }
        }

        private void Aprovement()
        {
            using AppContext db = new AppContext();
            foreach (Client client in db.Clients
                .Include(c => c.User)
                .Where(c => !c.User.Confirmed))
            {
                RequestField requestField = new RequestField(client, tableLayoutPanelRequest);
                tableLayoutPanelRequest.Controls.Add(requestField.FieldPanel);
            }
        }

        private void Opportunity()
        {
            Client client = MainUser as Client;
            ClientNameLabel.Text = client.User.Name + " " + client.User.LastName;
            ClientNameLabel1.Text = client.User.Name + " " + client.User.LastName;
            BankInit();
            BillInit(client);
        }

        private void BankInit()
        {
            using AppContext db = new AppContext();
            List<string> Banks = new List<string>();
            foreach (Bank b in db.Banks.ToList())
            {
                Banks.Add(b.Name + "//" + b.BID);
            }

            BankComboBox.Controls.Clear();
            BankComboBox.Items.AddRange(Banks.ToArray());
            BankComboBox.SelectedIndex = 0;
        }

        private void BillInit(Client client)
        {
            List<string> Bills = new List<string>();
            foreach (Bill bill in client.Bills)
            {
                Bills.Add(bill.BillNumber);
            }

            if (Bills.Count != 0)
            {
                BillcomboBox.Controls.Clear();
                BillcomboBox.Enabled = true;
                BillcomboBox.Items.AddRange(Bills.ToArray());
                BillcomboBox.SelectedIndex = 0;
            }
            else
            {
                BillcomboBox.Enabled = false;
            }

            PeriodComboBox.SelectedIndex = 0;
        }

        private void InizializeMenu()
        {
            Client client = MainUser as Client;
            nameLabel.Text = client.User.Name;
            lastNameLabel.Text = client.User.LastName;
            moneyLabel.Text = client.Bills.Sum(b => b.Money).ToString();
            tableLayoutPanelBill.Controls.Clear();
            foreach (Bill bill in client.Bills)
            {
                BillField billField = new BillField(bill, tableLayoutPanelBill);
                tableLayoutPanelBill.Controls.Add(billField.FieldPanel);
            }

            if (client.Bills.Count != 0)
            {
                billsLabel.Text = "Bills";
            }
            else
            {
                billsLabel.Text = "No Bills";
            }
        }

        private void CreditButton_Click(object sender, EventArgs e)
        {
            //using AppContext db = new AppContext();
            Client client = MainUser as Client;
            Bill bill;
            string BillNumber = BillcomboBox.Text;

            foreach (Bill b in client.Bills)
            {
                if (b.BillNumber == BillNumber)
                {
                    bill = b;
                    break;
                }
            }

        }

        private void BillButton_Click(object sender, EventArgs e)
        {
            using AppContext db = new AppContext();
            Client client = MainUser as Client;
            string[] BankAndBID = Regex.Split(BankComboBox.Text.Trim(), "//");
            Bank bank = db.Banks
                .Include(b => b.Clients)
                .FirstOrDefault(b => b.Name == BankAndBID[0] && b.BID == BankAndBID[1]);

            if (!bank.Clients.Any(c => c.Id == client.Id))
            {
                bank.Clients.Add(client);
                db.Banks.Update(bank);
                db.SaveChanges();
            }

            Bill bill = new Bill()
            {
                BID = BankAndBID[1],
                Money = 0,
                Blocked = false,
                Freezed = false,
                BillNumber = BillNumberLabel.Text,
            };

            client.OpenBill(bill);

            BankComboBox_SelectedIndexChanged(sender, e);
            InizializeMenu();
            BillInit(client);
        }

        private void BankComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            using AppContext db = new AppContext();
            Client client = MainUser as Client;
            Bank bank;
            string[] BankAndBID = Regex.Split(BankComboBox.Text.Trim(), "//");
            bank = db.Banks.FirstOrDefault(b => b.Name == BankAndBID[0] && b.BID == BankAndBID[1]);

            Bill bill = new Bill() { 
                BID = BankAndBID[1],
                Money = 0,
                Blocked = false, 
                Freezed = false,
            };
            bill.BillInizializer(bank);

            BankNameLabel.Text = BankAndBID[0];
            BillNumberLabel.Text = bill.BillNumber;
        }

        private void BillcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            using AppContext db = new AppContext();
            Client client = MainUser as Client;
            Bill bill;
            string BillNumber = BillcomboBox.Text;

            bill =  client.Bills.FirstOrDefault(b => b.BillNumber == BillNumber);
            BankNameLabel.Text = db.Banks.FirstOrDefault(b => b.BID == bill.BID).Name;

            CreditPercentLabel.Text = (db.Banks.FirstOrDefault(b => b.BID == bill.BID).OverPaymentPercent / 100).ToString();
            OverPaymentLabel.Text = ((uint)((double)db.Banks.FirstOrDefault(b => b.BID == bill.BID).OverPaymentPercent / 100) * numericUpDownMoney.Value).ToString();
            OperationLabel.Text = "Credit";
        }

        private void PeriodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PeriodLabel.Text = PeriodComboBox.Text;
        }

        private void numericUpDownMoney_ValueChanged(object sender, EventArgs e)
        {
            AmountLabel.Text = numericUpDownMoney.Value.ToString() + "R";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            CreditPercentLabel.Text = "";
            OperationLabel.Text = "Installement";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            BillcomboBox_SelectedIndexChanged(sender, e);
        }
    }
}
