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
            using AppContext db = new AppContext();
            Client client = MainUser as Client;

            List<string> Bills = new List<string>();
            foreach (Bill bill in client.Bills)
            {
                Bills.Add(bill.BillNumber);
            }

            if (Bills.Count != 0)
            {
                BillcomboBox.Items.AddRange(Bills.ToArray());
                BillcomboBox.SelectedIndex = 0;
            }
            else
            {
                BillcomboBox.Enabled = false;
            }

            List<string> Banks = new List<string>();
            foreach (Bank b in db.Banks.ToList())
            {
                Banks.Add(b.Name + "//" + b.BID);
            }

            BankComboBox.Items.AddRange(Banks.ToArray()); //db.Banks.ToArray().ToString()
            BankComboBox.SelectedIndex = 0;
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
            Client client = MainUser as Client;
            //using AppContext db = new AppContext();
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
            Bank bank;
            string[] BankAndBID = Regex.Split(BankComboBox.Text.Trim(), "//");
            bank = db.Banks
                .Include(b => b.Clients)
                .ToList()
                .Find(b => b.Name == BankAndBID[0] && b.BID == BankAndBID[1]);

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
        }

        private void BankComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            using AppContext db = new AppContext();
            Client client = MainUser as Client;
            Bank bank;
            string[] BankAndBID = Regex.Split(BankComboBox.Text.Trim(), "//");
            bank = db.Banks.AsEnumerable().ToList().Find(b => b.Name == BankAndBID[0] && b.BID == BankAndBID[1]);

            Bill bill = new Bill() { 
                BID = BankAndBID[1],
                Money = 0,
                Blocked = false, 
                Freezed = false,
            };
            bill.BillInizializer(bank);

            BankNameLabel.Text = BankAndBID[0];
            ClientNameLabel.Text = client.User.Name + " " + client.User.LastName;
            BillNumberLabel.Text = bill.BillNumber;
        }

        private void BillcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            using AppContext db = new AppContext();
            Client client = MainUser as Client;
            Bill bill;
            string BillNumber = BillcomboBox.Text;

            foreach(Bill b in client.Bills)
            {
                if (b.BillNumber == BillNumber)
                {
                    bill = b;
                    break;
                }
            }

            BankNameLabel
        }
    }
}
