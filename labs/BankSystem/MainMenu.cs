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
                mainTab.Controls.Remove(requestTab);
                mainTab.Controls.Remove(salaryProjectTab);
                mainTab.Controls.Remove(transferTab);
                InitializeMenu();
                InitializeDeals();
                Opportunity();
            }
            else if (MainUser is Outsider)
            {
                mainTab.Controls.Remove(opportunityTab);
                mainTab.Controls.Remove(dealTab);
                mainTab.Controls.Remove(cabinetTab);
                salaryTabControl.Controls.Remove(RequestTabPage1);
                salaryTabControl.Controls.Remove(RequestTabPage2);
                salaryTabControl.Controls.Remove(RequestTabPage3);
                salaryTabControl.Controls.Remove(RequestTabPage4);
                salaryTabControl.Controls.Remove(RequestTabPage6);
                salaryTabControl.Controls.Remove(RequestTabPage7);
                InitializeSP();
                InitializeTransferRequest();
            }
            else if (MainUser is Operator)
            {
                Operator @operator = MainUser as Operator;
                salaryTabControl.Controls.Remove(RequestTabPage1);
                salaryTabControl.Controls.Remove(RequestTabPage2);
                salaryTabControl.Controls.Remove(RequestTabPage3);
                salaryTabControl.Controls.Remove(RequestTabPage5);
                mainTab.Controls.Remove(opportunityTab);
                mainTab.Controls.Remove(dealTab);
                mainTab.Controls.Remove(cabinetTab);
                mainTab.Controls.Remove(salaryProjectTab);
                mainTab.Controls.Remove(transferTab);
                InitializeSPRequest(@operator.myWork.BID);
                InitializeTranzactions(@operator.myWork.BID);
            }
            else if (MainUser is Manager)
            {
                salaryTabControl.Controls.Remove(RequestTabPage5);
                mainTab.Controls.Remove(opportunityTab);
                mainTab.Controls.Remove(dealTab);
                mainTab.Controls.Remove(cabinetTab);
                mainTab.Controls.Remove(salaryProjectTab);
                mainTab.Controls.Remove(transferTab);
                Manager manager = MainUser as Manager;
                Aprovement(manager.BID);
                InitializeUndoOutsiders(manager.BID);
            }
            else if (MainUser is Admin)
            {
                //TODO
            }
        }

        private void Aprovement(string BID)
        {
            using AppContext db = new AppContext();
            foreach (Client client in db.Clients
                .Include(c => c.User)
                .Where(c => !c.User.Confirmed))
            {
                RequestField requestField = new RequestField(client, tableLayoutPanelRequest1);
                tableLayoutPanelRequest1.Controls.Add(requestField.FieldPanel);
            }

            InitializeCreditRequest(BID);
            InitializeInstallementRequest(BID);
            InitializeSPRequest(BID);
        }

        private void InitializeTransferRequest()
        {
            using AppContext db = new AppContext();
            Outsider outsider = MainUser as Outsider;
            Company company = db.Companies
                .Include(c => c.BillsNSalaries)
                .Include(c => c.CompanyTransfer)
                .FirstOrDefault(c => c.UNP == outsider.UNP);

            //foreach (Company company in db.Companies
            //    .Include(c => c.BillsNSalaries)
            //    .Include(c => c.CompanyTransfer)
            //    .Where(c => c.Confirmed))
            //{
            foreach (BillsNSalary billsNSalary in company.BillsNSalaries.Where(b => b.IsRequest))
            {
                TransferRequest transferRequest = new TransferRequest(billsNSalary, company, tableLayoutPanel5);
                tableLayoutPanel5.Controls.Add(transferRequest.FieldPanel);
            }
            //}
        }

        private void InitializeCreditRequest(string BID)
        {
            using AppContext db = new AppContext();
            foreach (Client client in db.Clients
                .Include(c => c.User)
                .Include(c => c.Bills.Where(b => b.BID == BID))
                .ThenInclude(b => b.Credits)
                .Where(c => c.Bills.Sum(b => b.Credits.Count) != 0))
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

        private void InitializeInstallementRequest(string BID)
        {
            using AppContext db = new AppContext();
            foreach (Client client in db.Clients
                .Include(c => c.User)
                .Include(c => c.Bills.Where(b => b.BID == BID))
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

        private void InitializeSPRequest(string BID)
        {
            using AppContext db = new AppContext();
            foreach (Outsider outsider in db.Outsiders)
            {
                if (db.Companies.Any(c => c.UNP == outsider.UNP && c.Requested && c.BID == BID))
                {
                    Company company = db.Companies
                        .FirstOrDefault(c => c.UNP == outsider.UNP && c.Requested);
                    SalaryPRequest salaryPRequest = new SalaryPRequest(company, outsider, tableLayoutPanel4);
                    tableLayoutPanel4.Controls.Add(salaryPRequest.FieldPanel);
                }
            }
        }

        private void InitializeTranzactions(string BID)
        {
            using AppContext db = new AppContext();
            foreach (Client client in db.Clients
                .Include(c => c.User)
                .Include(c => c.Bills)
                .ThenInclude(b => b.Transactions)
                .Where(c => c.User.Confirmed))
            {
                foreach (Bill bill in client.Bills.Where(b => b.BID == BID))
                {
                    foreach (Transaction transaction in bill.Transactions)
                    {
                        Transactions transactions = new Transactions(transaction, bill, tableLayoutPanel6);
                        tableLayoutPanel6.Controls.Add(transactions.FieldPanel);
                    }
                }
            }
        }

        private void InitializeUndoOutsiders(string BID)
        {
            using AppContext db = new AppContext();
            foreach (Company company in db.Companies
                .Include(c => c.CompanyTransfer)
                .Where(c => c.BID == BID && c.Confirmed))
            {
                foreach (CompanyTransfer companyTransfer in company.CompanyTransfer)
                {
                    UndoOutsiders undoOutsiders = new UndoOutsiders(companyTransfer, company, tableLayoutPanel7);
                    tableLayoutPanel7.Controls.Add(undoOutsiders.FieldPanel);
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

            accumComboBox.Items.Clear();
            accumComboBox.Items.AddRange(Banks.ToArray());
            accumComboBox.SelectedIndex = 0;
        }

        private void BillInit(Client client)
        {
            List<string> Bills = new List<string>();
            foreach (Bill bill in client.Bills.Where(b => !b.Blocked && !b.Freezed))
            {
                Bills.Add(bill.BillNumber);
            }

            if (Bills.Count != 0)
            {
                BillcomboBox.Enabled = true;
                CreditButton.Enabled = true;
                PeriodComboBox.Enabled = true;
                numericUpDownMoney.Enabled = true;
                BillcomboBox.Items.Clear();
                BillcomboBox.Items.AddRange(Bills.ToArray());
                BillcomboBox.SelectedIndex = 0;

                transferGroupBox.Enabled = true;
                accumulateGroupBox.Enabled = true;
                abilityGroupBox.Enabled = true;
                dealComboBox.Items.Clear();
                dealComboBox.Items.AddRange(Bills.ToArray());
                dealComboBox.SelectedIndex = 0;
            }
            else
            {
                BillcomboBox.Enabled = false;
                CreditButton.Enabled = false;
                PeriodComboBox.Enabled = false;
                numericUpDownMoney.Enabled = false;

                transferGroupBox.Enabled = false;
                accumulateGroupBox.Enabled = false;
                abilityGroupBox.Enabled = false;
            }
        }

        private void InitializeMenu()
        {
            using AppContext db = new AppContext();
            Client client = MainUser as Client;
            client = db.Clients
                .Include(c => c.Bills)
                .ThenInclude(b => b.Credits)
                .Include(c => c.Bills)
                .ThenInclude(b => b.Installements)
                .Include(c => c.User)
                .Include(c => c.Bills)
                .FirstOrDefault(c => c.Id == client.Id);
            nameLabel.Text = client.User.Name;
            lastNameLabel.Text = client.User.LastName;
            moneyLabel.Text = client.Bills.Sum(b => b.Money).ToString();
            tableLayoutPanelBill.Controls.Clear();
            tableLayoutPanelCredit.Controls.Clear();
            db.Clients.Update(client);
            db.SaveChanges();
            foreach (Bill bill in client.Bills)
            {
                BillField billField = new BillField(bill, tableLayoutPanelBill);
                tableLayoutPanelBill.Controls.Add(billField.FieldPanel);

                foreach (Credit credit in bill.Credits)
                {
                    CreditField creditField = new CreditField(credit, bill, tableLayoutPanelCredit);
                    tableLayoutPanelCredit.Controls.Add(creditField.FieldPanel);
                }

                foreach (Installement installement in bill.Installements)
                {
                    CreditField creditField = new CreditField(installement, bill, tableLayoutPanelCredit);
                    tableLayoutPanelCredit.Controls.Add(creditField.FieldPanel);
                }
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

            Random rnd = new Random();
            Bill bill = new Bill()
            {
                BID = BankAndBID[1],
                Money = rnd.Next(1000, 15000),
                Blocked = false,
                Freezed = false,
                BillNumber = BillNumberLabel.Text,
                Credits = new List<Credit>(),
                Installements = new List<Installement>(),
                Transactions = new List<Transaction>(),
            };

            client.OpenBill(bill);
            //db.Clients.Update(client);
            db.SaveChanges();

            BankComboBox_SelectedIndexChanged(sender, e);
            InitializeMenu();
            InitializeDeals();
            BillInit(client);
        }

        private void CreditButton_Click(object sender, EventArgs e)
        {
            using AppContext db = new AppContext();
            string BillNumber = BillcomboBox.Text;
            Client client = MainUser as Client;
            Bill bill = client.Bills.FirstOrDefault(b => b.BillNumber == BillNumber);
            //Bill bill = db.Bills
            //    .Include(b => b.Installements)
            //    .Include(b => b.Credits)
            //    .FirstOrDefault(b => b.BillNumber == BillNumber);

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

            InitializeMenu();
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

            bill = client.Bills.FirstOrDefault(b => b.BillNumber == BillNumber);
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

        private void InitializeDeals()
        {
            transferMoneyLabel.Text = sumNumericUpDown.Value.ToString();
            label31.Text = numericUpDown2.Value.ToString();

            using AppContext db = new AppContext();
            List<string> Bills = new List<string>();
            Client client = MainUser as Client;
            foreach (Bill bill in client.Bills)
            {
                Bills.Add(bill.BillNumber);
            }

            if (Bills.Count != 0)
            {
                comboBox6.Enabled = true;
                freezeButton.Enabled = true;
                blockButton.Enabled = true;
                comboBox6.Items.Clear();
                comboBox6.Items.AddRange(Bills.ToArray());
                comboBox6.SelectedIndex = 0;
            }
            else
            {
                comboBox6.Enabled = false;
                freezeButton.Enabled = false;
                blockButton.Enabled = false;
            }
        }

        private void transferButton_Click(object sender, EventArgs e)
        {
            using AppContext db = new AppContext();
            if (db.Bills.Any(b => b.BillNumber == destBillMaskedTextBox.Text))
            {
                Bill SourceBill = db.Bills
                    .Include(b => b.Transactions)
                    .FirstOrDefault(b => b.BillNumber == dealComboBox.Text);
                if (SourceBill.Money >= (double)sumNumericUpDown.Value)
                {
                    SourceBill.Money -= (double)sumNumericUpDown.Value;
                    Bill DestBill = db.Bills.Include(b => b.Transactions).FirstOrDefault(b => b.BillNumber == destBillMaskedTextBox.Text);
                    DestBill.Money += (double)sumNumericUpDown.Value;
                    Transaction tr = new Transaction()
                    {
                        DestBill = DestBill.BillNumber,
                        Amount = (double)sumNumericUpDown.Value,
                    };

                    SourceBill.Transactions.Add(tr);
                    db.Transactions.Add(tr);
                    db.Bills.Update(SourceBill);
                    db.Bills.Update(DestBill);
                    db.SaveChanges();
                    InitializeMenu();
                }
            }
        }

        private void destBillMaskedTextBox_TextChanged(object sender, EventArgs e)
        {
            if (destBillMaskedTextBox.MaskFull)
            {
                transfetToLabel.Text += destBillMaskedTextBox.Text;
                transferButton.Enabled = true;
            }
            else
            {
                transferButton.Enabled = false;
            }
        }

        private void sumNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            transferMoneyLabel.Text = sumNumericUpDown.Value.ToString();
        }

        private void accumComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            using AppContext db = new AppContext();
            string[] BankAndBID = Regex.Split(BankComboBox.Text.Trim(), "//");
            double percent = db.Banks.FirstOrDefault(b => b.Name == BankAndBID[0] && b.BID == BankAndBID[1]).AccumPercent;

            label30.Text = "Bank/id: " + BankAndBID[0] + '/' + BankAndBID[1];
            label32.Text = "Percent: " + percent.ToString();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            label31.Text = numericUpDown2.Value.ToString();
        }

        private void accumButton_Click(object sender, EventArgs e)
        {
            using AppContext db = new AppContext();
            Client client = MainUser as Client;
            Bill SourceBill = db.Bills.FirstOrDefault(b => b.BillNumber == dealComboBox.Text);
            if (SourceBill.Money >= (double)numericUpDown2.Value)
            {
                string[] BankAndBID = Regex.Split(BankComboBox.Text.Trim(), "//");
                Bank bank = db.Banks.Include(b => b.ClientAccum).FirstOrDefault(b => b.BID == BankAndBID[1]);
                SourceBill.Money -= (double)numericUpDown2.Value;
                Accumulate accum = new Accumulate
                {
                    ClientId = client.User.Login,
                    Amount = (double)numericUpDown2.Value,
                    Percent = bank.AccumPercent,
                    Time = DateTime.UtcNow,
                };

                bank.ClientAccum.Add(accum);
                db.Banks.Update(bank);
                db.Accumulates.Add(accum);
                db.SaveChanges();
                InitializeMenu();
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            using AppContext db = new AppContext();
            Bill bill;
            string BillNumber = comboBox6.Text;
            bill = db.Bills.FirstOrDefault(b => b.BillNumber == BillNumber);

            if (bill.Blocked)
            {
                label29.Text = "Already blocked";
                freezeButton.Visible = false;
                blockButton.Visible = false;
            }
            else if (bill.Freezed)
            {
                label29.Text = "Already freezed";
                freezeButton.Visible = true;
                freezeButton.Text = "Unfreeze";
                blockButton.Visible = false;
            }
            else
            {
                label29.Text = "Freeze you can cancel\nBlocking you cann't";
                freezeButton.Visible = true;
                freezeButton.Text = "Freeze";
                blockButton.Visible = true;
            }
        }

        private void freezeButton_Click(object sender, EventArgs e)
        {
            using AppContext db = new AppContext();
            Bill bill;
            string BillNumber = comboBox6.Text;
            bill = db.Bills.FirstOrDefault(b => b.BillNumber == BillNumber);

            if (freezeButton.Text == "Freeze")
            {
                bill.Freezed = true;
            }
            else
            {
                bill.Freezed = false;
            }

            db.Bills.Update(bill);
            db.SaveChanges();
            comboBox6_SelectedIndexChanged(sender, e);
            BillInit(MainUser as Client);
            InitializeMenu();
        }

        private void blockButton_Click(object sender, EventArgs e)
        {
            using AppContext db = new AppContext();
            Bill bill;
            string BillNumber = comboBox6.Text;
            bill = db.Bills.FirstOrDefault(b => b.BillNumber == BillNumber);
            bill.Blocked = true;

            db.Bills.Update(bill);
            db.SaveChanges();
            comboBox6_SelectedIndexChanged(sender, e);
            BillInit(MainUser as Client);
            InitializeMenu();
        }

        private void InitializeSP()
        {
            using AppContext db = new AppContext();
            List<string> Banks = new List<string>();
            foreach (Bank b in db.Banks.ToList())
            {
                Banks.Add(b.BID);
            }

            comboBox7.SelectedIndex = 0;
            comboBox8.Items.AddRange(Banks.ToArray());
            comboBox8.SelectedIndex = 0;

            Outsider outsider = MainUser as Outsider;
            if (outsider.UNP != null)
            {
                regCompanyButton.Enabled = false;
                maskedTextBox2.Enabled = true;
                label54.Text = db.Companies.FirstOrDefault(c => c.UNP == outsider.UNP).Name;

                Company Company = db.Companies
                    //.Include(c => c.Requested)
                    //.Include(c => c.Confirmed)
                    .FirstOrDefault(c => c.UNP == outsider.UNP);
                if (Company.Confirmed || Company.Requested)
                {
                    submitButton.Enabled = false;
                }
            }
            else
            {
                maskedTextBox2.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using AppContext db = new AppContext();
            if (textBox1.Text.Trim().Length == 0)
            {
                textBox1.Text = "Cann't be empty";
            }
            else if (textBox2.Text.Trim().Length == 0)
            {
                textBox2.Text = "Cann't be empty";
            }
            else if (textBox3.Text.Trim().Length == 0)
            {
                textBox3.Text = "Cann't be empty";
            }
            else if (!db.Companies.Any(c => c.UNP == textBox1.Text.Trim()))
            {
                Outsider outsider = MainUser as Outsider;
                Random rd = new Random();
                Company company = new Company
                {
                    UNP = textBox1.Text.Trim(),
                    BID = comboBox8.Text,
                    Name = textBox2.Text,
                    Address = textBox3.Text,
                    Confirmed = false,
                    Requested = false,
                    Money = rd.Next(25000, 70000),
                };

                outsider.UNP = company.UNP;

                db.Outsiders.Update(outsider);
                db.Companies.Add(company);
                db.SaveChanges();

                InitializeSP();
            }
        }

        private void addSalaryBillButton_Click(object sender, EventArgs e) //TODO
        {
            using AppContext db = new AppContext();
            if (db.Bills.Any(b => b.BillNumber == maskedTextBox2.Text))
            {
                Outsider outsider = MainUser as Outsider;
                Company Company = db.Companies
                    .Include(c => c.BillsNSalaries)
                    .FirstOrDefault(c => c.UNP == outsider.UNP); //TODO
                if (Company.BillsNSalaries.Any(b => b.BillNumber == maskedTextBox2.Text))
                {
                    BillsNSalary billsNSalary = Company.BillsNSalaries.FirstOrDefault(b => b.BillNumber == maskedTextBox2.Text);
                    billsNSalary.Salary = (int)numericUpDown4.Value;
                    label53.Text = $"Changed salary for\n{maskedTextBox2.Text}";
                }
                else
                {
                    Company.AddWorker(maskedTextBox2.Text, (int)numericUpDown4.Value);
                    label53.Text = "Succesfull";
                }

                db.Outsiders.Update(outsider);
                db.Companies.Update(Company);
                db.SaveChanges();
            }
            else
            {
                label53.Text = "No such bill";
            }
        }

        private void maskedTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox2.MaskFull)
            {
                addSalaryBillButton.Enabled = true;
            }
            else
            {
                addSalaryBillButton.Enabled = false;
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            using AppContext db = new AppContext();
            Outsider outsider = MainUser as Outsider;
            Company Company = db.Companies
                .FirstOrDefault(c => c.UNP == outsider.UNP);
            Company.Requested = true;
            db.Outsiders.Update(outsider);
            db.SaveChanges();
            submitButton.Enabled = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            using AppContext db = new AppContext();
            if (textBox10.Text.Trim().Length == 0)
            {
                label78.Text = "UNP is empty";
            }
            else
            {
                if (db.Companies.Any(c => c.Confirmed && c.UNP == textBox10.Text.Trim()))
                {
                    Outsider outsider = MainUser as Outsider;
                    Company Company = db.Companies
                        .Include(c => c.BillsNSalaries)
                        .FirstOrDefault(c => c.UNP == textBox10.Text.Trim());
                    if (maskedTextBox4.MaskFull && Company.BillsNSalaries
                        .Any(b => b.BillNumber == maskedTextBox4.Text))
                    {
                        BillsNSalary billsNSalary = new BillsNSalary
                        {
                            IsRequest = true,
                            BillNumber = maskedTextBox4.Text,
                            Salary = (int)numericUpDown7.Value,
                            FromBill = outsider.UNP,
                        };
                        Company.BillsNSalaries.Add(billsNSalary);
                        db.BillsNSalaries.Add(billsNSalary);
                        label78.Text = "Succesful";
                    }
                    else if (maskedTextBox4.Text.Length == 0)
                    {
                        BillsNSalary billsNSalary = new BillsNSalary
                        {
                            IsRequest = true,
                            BillNumber = textBox10.Text.Trim(),
                            Salary = (int)numericUpDown7.Value,
                            FromBill = outsider.UNP,
                        };
                        Company.BillsNSalaries.Add(billsNSalary);
                        db.BillsNSalaries.Add(billsNSalary);
                        label78.Text = "Succesful";
                    }
                    else
                    {
                        label78.Text = "No such bill";
                    }

                    db.Companies.Update(Company);
                    db.SaveChanges();
                }
                else
                {
                    label78.Text = "No such company";
                }
            }
        }
    }
}
