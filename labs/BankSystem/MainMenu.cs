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
                RequestField requestField = new RequestField(client, tableLayoutPanelRequest1);
                tableLayoutPanelRequest1.Controls.Add(requestField.FieldPanel);
            }

            //foreach (Client client in db.Clients
            //    .Include(c => c.Bills)
            //    .ThenInclude(b => b.Credits)
            //    .SelectMany(c => c.Bills)
            //    .Where(c => c.Credits.Count != 0))
            //{

            //}

            InitializeCreditRequest();
            InitializeInstallementRequest();
            //foreach (Client client in db.Clients
            //    .Include(c => c.Bills)
            //    .ThenInclude(b => b.Credits)
            //    .Where(c => c.Bills.Sum(b => b.Credits.Count) != 0)) //.User.Confirmed))
            //{
            //    var credits = client.Bills
            //    .SelectMany(c => c.Credits)
            //    .Where(c => !c.Confirmed);
            //
            //    foreach (Credit credit in credits)
            //    {
            //        CreditRequest creditRequest = new CreditRequest(client, credit, tableLayoutPanelRequest2);
            //        tableLayoutPanelRequest2.Controls.Add(creditRequest.FieldPanel);
            //    }
            //}
            //
            //foreach (Credit credit in db.Credits
            //    .Where(c => !c.Confirmed))
            //{
            //    RequestField requestField = new RequestField(credit, tableLayoutPanelRequest1);
            //    tableLayoutPanelRequest1.Controls.Add(requestField.FieldPanel);
            //}
        }

        private void InitializeCreditRequest()
        {
            using AppContext db = new AppContext();
            foreach (Client client in db.Clients
                .Include(c => c.User)
                .Include(c => c.Bills)
                .ThenInclude(b => b.Credits)
                .Where(c => c.Bills.Sum(b => b.Credits.Count) != 0)) //.User.Confirmed))
            {
                var credits = client.Bills
                .SelectMany(c => c.Credits)
                .Where(c => !c.Confirmed);

                foreach (Credit credit in credits)
                {
                    CreditRequest creditRequest = new CreditRequest(client, credit, tableLayoutPanelRequest2);
                    tableLayoutPanelRequest2.Controls.Add(creditRequest.FieldPanel);
                }
            }
        }

        private void InitializeInstallementRequest()
        {
            using AppContext db = new AppContext();
            foreach (Client client in db.Clients
                .Include(c => c.User)
                .Include(c => c.Bills)
                .ThenInclude(b => b.Installements)
                .Where(c => c.Bills.Sum(b => b.Installements.Count) != 0))
            {
                var installements = client.Bills
                .SelectMany(c => c.Installements)
                .Where(c => !c.Confirmed);

                foreach (Installement installement in installements)
                {
                    CreditRequest installementRequest = new CreditRequest(client, installement, tableLayoutPanelRequest3);
                    tableLayoutPanelRequest3.Controls.Add(installementRequest.FieldPanel);
                }
            }
        }

        private void Opportunity()
        {
            Client client = MainUser as Client;
            ClientNameLabel.Text = client.User.Name + " " + client.User.LastName;
            ClientNameLabel1.Text = client.User.Name + " " + client.User.LastName;
            PeriodComboBox.SelectedIndex = 0;
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

            BankComboBox.Items.Clear();
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
                BillcomboBox.Items.Clear();
                BillcomboBox.Enabled = true;
                CreditButton.Enabled = true;
                PeriodComboBox.Enabled = true;
                numericUpDownMoney.Enabled = true;
                BillcomboBox.Items.AddRange(Bills.ToArray());
                BillcomboBox.SelectedIndex = 0;
            }
            else
            {
                BillcomboBox.Enabled = false;
                CreditButton.Enabled = false;
                PeriodComboBox.Enabled = false;
                numericUpDownMoney.Enabled = false;
            }
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

        private void CreateBillButton_Click(object sender, EventArgs e)
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

        private void CreditButton_Click(object sender, EventArgs e)
        {
            using AppContext db = new AppContext();
            string BillNumber = BillcomboBox.Text;
            Bill bill = db.Bills
                .Include(b => b.Installements)
                .Include(b => b.Credits)
                .FirstOrDefault(b => b.BillNumber == BillNumber);

            if (radioButton1.Checked)
            {         
                Credit credit = new Credit
                {
                    Confirmed = false,
                    Months = Convert.ToInt32(PeriodComboBox.Text),
                    Money = (double)numericUpDownMoney.Value,
                    Percent = db.Banks.FirstOrDefault(b => b.BID == bill.BID).OverPaymentPercent,
                };

                bill.CreditRequest(credit);
            }
            else
            {
                Installement installement = new Installement
                {
                    Confirmed = false,
                    Months = Convert.ToInt32(PeriodComboBox.Text),
                    Money = (double)numericUpDownMoney.Value,
                };

                bill.InstallmentRequest(installement);
            }
        }

        private void BankComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            using AppContext db = new AppContext();
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
            BankNameLabel1.Text = db.Banks.FirstOrDefault(b => b.BID == bill.BID).Name;
            CreditBillLabel.Text = BillNumber;
            MoneyNPaymentUpdate(bill);
        }

        private void MoneyNPaymentUpdate(Bill bill)
        {
            using AppContext db = new AppContext();
            AmountLabel.Text = numericUpDownMoney.Value.ToString() + "R";
            
            if (radioButton1.Checked)
            {
                OperationLabel.Text = "Credit";
                CreditPercentLabel.Text = db.Banks.FirstOrDefault(b => b.BID == bill.BID).OverPaymentPercent.ToString() + "%";
                OverPaymentLabel.Text = ((uint)(db.Banks.FirstOrDefault(b => b.BID == bill.BID).OverPaymentPercent / 100 * (double)numericUpDownMoney.Value)).ToString();
            }
        }

        private void PeriodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PeriodLabel.Text = PeriodComboBox.Text + " month";
        }

        private void numericUpDownMoney_ValueChanged(object sender, EventArgs e)
        {
            Bill bill;
            Client client = MainUser as Client;
            string BillNumber = BillcomboBox.Text;
            bill = client.Bills.FirstOrDefault(b => b.BillNumber == BillNumber);
            MoneyNPaymentUpdate(bill);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            BillcomboBox_SelectedIndexChanged(sender, e);
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            CreditPercentLabel.Text = "";
            OverPaymentLabel.Text = "";
            OperationLabel.Text = "Installement";
        }
    }
}
