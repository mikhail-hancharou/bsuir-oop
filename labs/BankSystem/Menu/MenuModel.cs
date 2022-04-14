using BankSystem.Entities;
using BankSystem.MenuEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BankSystem.Menu
{
    class MenuModel
    {
        private AppContext db;
        public MenuModel()
        {
            db = new AppContext();
        }

        public List<Panel> Aprovement(string BID, TableLayoutPanel tb)
        {
            List<Panel> rf = new List<Panel>();
            foreach (Client client in db.Clients
                .Include(c => c.User)
                .Where(c => !c.User.Confirmed))
            {
                RequestField reqf = new RequestField(client, tb);
                rf.Add(reqf.FieldPanel);
            }

            return rf;
        }

        public List<Panel> InitializeTransferRequest(Outsider outsider, TableLayoutPanel tb)
        {
            List<Panel> rf = new List<Panel>();
            Company company = db.Companies
                .Include(c => c.BillsNSalaries)
                .Include(c => c.CompanyTransfer)
                .FirstOrDefault(c => c.UNP == outsider.UNP);

            foreach (BillsNSalary billsNSalary in company.BillsNSalaries.Where(b => b.IsRequest))
            {
                TransferRequest tReq = new TransferRequest(billsNSalary, company, tb);
                rf.Add(tReq.FieldPanel);
            }

            return rf;
        }

        public List<Panel> InitializeCreditRequest(string BID, TableLayoutPanel tb)
        {
            List<Panel> rf = new List<Panel>();
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
                    CreditRequest creditRequest = new CreditRequest(client, credit, tb);
                    rf.Add(creditRequest.FieldPanel);
                }
            }

            return rf;
        }

        public List<Panel> InitializeInstallementRequest(string BID, TableLayoutPanel tb)
        {
            List<Panel> rf = new List<Panel>();
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
                    CreditRequest installementRequest = new CreditRequest(client, installement, tb);
                    rf.Add(installementRequest.FieldPanel);
                }
            }

            return rf;
        }

        public List<Panel> InitializeSPRequest(string BID, TableLayoutPanel tb)
        {
            List<Panel> rf = new List<Panel>();
            foreach (Outsider outsider in db.Outsiders)
            {
                if (db.Companies.Any(c => c.UNP == outsider.UNP && c.Requested && c.BID == BID))
                {
                    Company company = db.Companies
                        .FirstOrDefault(c => c.UNP == outsider.UNP && c.Requested);
                    SalaryPRequest salaryPRequest = new SalaryPRequest(company, outsider, tb);
                    rf.Add(salaryPRequest.FieldPanel);
                }
            }

            return rf;
        }

        public List<Panel> InitializeTranzactions(string BID, TableLayoutPanel tb)
        {
            List<Panel> rf = new List<Panel>();
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
                        Transactions transactions = new Transactions(transaction, bill, tb);
                        rf.Add(transactions.FieldPanel);
                    }
                }
            }

            return rf;
        }

        public List<Panel> InitializeUndoOutsiders(string BID, TableLayoutPanel tb)
        {
            List<Panel> rf = new List<Panel>();
            foreach (Company company in db.Companies
                .Include(c => c.CompanyTransfer)
                .Where(c => c.BID == BID && c.Confirmed))
            {
                foreach (CompanyTransfer companyTransfer in company.CompanyTransfer)
                {
                    UndoOutsiders undoOutsiders = new UndoOutsiders(companyTransfer, company, tb);
                    rf.Add(undoOutsiders.FieldPanel);
                }
            }

            return rf;
        }

        public List<string> BankInit()
        {
            List<string> Banks = new List<string>();
            foreach (Bank b in db.Banks.ToList())
            {
                Banks.Add(b.Name + "//" + b.BID);
            }

            return Banks;
        }

        public List<string> BillInit(Client client)
        {
            List<string> Bills = new List<string>();
            foreach (Bill bill in client.Bills.Where(b => !b.Blocked && !b.Freezed))
            {
                Bills.Add(bill.BillNumber);
            }

            return Bills; 
        }

        public Client ClientUpdate(Client client)
        {
            client = db.Clients
                .Include(c => c.Bills)
                .ThenInclude(b => b.Credits)
                .Include(c => c.Bills)
                .ThenInclude(b => b.Installements)
                .Include(c => c.User)
                .Include(c => c.Bills)
                .FirstOrDefault(c => c.Id == client.Id);

            db.Clients.Update(client);
            db.SaveChanges();
            return client;
        }

        public void CreateBill(Client client, string bankNBID, string billNumber)
        {
            string[] BankAndBID = Regex.Split(bankNBID, "//");
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
                BillNumber = billNumber,
                Credits = new List<Credit>(),
                Installements = new List<Installement>(),
                Transactions = new List<Transaction>(),
            };

            client.OpenBill(bill);
            db.SaveChanges();
        }

        public string BankIndex(string bankNBID)
        {
            string[] BankAndBID = Regex.Split(bankNBID, "//");
            Bank bank = db.Banks.FirstOrDefault(b => b.Name == BankAndBID[0] && b.BID == BankAndBID[1]);

            Bill bill = new Bill()
            {
                BID = BankAndBID[1],
                Money = 0,
                Blocked = false,
                Freezed = false,
            };
            bill.BillInizializer(bank);

            return bill.BillNumber;
        }

        public Bill BillIndex(Client client, string billNumber)
        {
            return client.Bills.FirstOrDefault(b => b.BillNumber == billNumber);   
        }

        public string BankName(Bill bill)
        {
            return db.Banks.FirstOrDefault(b => b.BID == bill.BID).Name;
        }

        public double MoneyNPayment(Bill bill)
        {
            return db.Banks.FirstOrDefault(b => b.BID == bill.BID).OverPaymentPercent;
        }
    }
}
