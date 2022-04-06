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
        public List<RequestField> ListRequestField { get; set; }
        public MainMenu(object mainUser)
        {
            this.MainUser = mainUser;
            this.ListRequestField = new List<RequestField>();
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            if (MainUser is Client)
            {
                MainUser = MainUser as Client;
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
                ListRequestField.Add(requestField);
            }
        }

        private void Opportunity()
        {
            using AppContext db = new AppContext();
            Client client = MainUser as Client;
            if (client.Bills != null)
            {
                List<string> Bills = new List<string>();
                foreach (Bill bill in client.Bills)
                {
                    Bills.Add(bill.BillNumber + "//" + bill.Bank.Name);
                }
                BillcomboBox.Items.AddRange(Bills.ToArray());
                BillcomboBox.SelectedIndex = 0;
            }
            else
            {
                BillcomboBox.Text = "No Bills";
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

        private void CreditButton_Click(object sender, EventArgs e)
        {
            Client client = MainUser as Client;
            //using AppContext db = new AppContext();
            Bill bill;
            string[] BillNumber = Regex.Split(BillcomboBox.Text.Trim(), "//");

            foreach (Bill b in client.Bills)
            {
                if (b.BillNumber == BillNumber[0])
                {
                    bill = b;
                    break;
                }
            }

        }

        private void BillButton_Click(object sender, EventArgs e)
        {
            using AppContext db = new AppContext();
            Bank bank;
            string[] BankAndBID = Regex.Split(BankComboBox.Text.Trim(), "//");
            bank = db.Banks.AsEnumerable().ToList().Find(b => b.Name == BankAndBID[0] && b.BID == BankAndBID[1]);
        }

        private void BankComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            using AppContext db = new AppContext();
            Client client = MainUser as Client;
            Bank bank;
            string[] BankAndBID = Regex.Split(BankComboBox.Text.Trim(), "//");
            bank = db.Banks.AsEnumerable().ToList().Find(b => b.Name == BankAndBID[0] && b.BID == BankAndBID[1]);

            Bill bill = new Bill() { 
                Bank = bank,
                Money = 0,
                Blocked = false, 
                Freezed = false,
            };
            bill.BillInizializer(bank);

            BankNameLabel.Text = BankAndBID[0];
            ClientNameLabel.Text = client.User.Name + " " + client.User.LastName;
            BillNumberLabel.Text = bill.BillNumber;
        }
    }
}
