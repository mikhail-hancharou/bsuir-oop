using BankSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    public class Bill
    {
        public int Id { get; set; }
        public string BID { get; set; }
        public double Money { get; set; }
        public string BillNumber { get; set; }
        public bool Blocked { get; set; }
        public bool Freezed { get; set; }
        public List<Transaction> Transactions { get; set; }
        public List<Credit> Credits { get; set; }
        public List<Installement> Installements { get; set; }

        public Bill() { }

        public Bill(Bank bank)
        {
            //this.Money = 0;
            //this.Bank = bank;
            //BillInizializer(bank);
        }

        public void CreditRequest(Credit credit)
        {
            AppContext db = new AppContext();
            Credits.Add(credit);
            db.Bills.Update(this);
            db.SaveChanges();
        }

        public void InstallmentRequest(Installement installement)
        {
            AppContext db = new AppContext();
            Installements.Add(installement);
            db.Bills.Update(this);
            db.SaveChanges();
        }

        public void BillInizializer(Bank bank)
        {
            StringBuilder number = new StringBuilder(10);
            number.Append(bank.BID);
            number.Append(RandomNumber());
            BillNumber = number.ToString();
            bool flag = false;

            if (bank.Clients == null)
            {
                return;
            }

            while (true)
            {
                foreach (Client u in bank.Clients)
                {
                    if (u.Bills.Contains(this))
                    {
                        flag = true;
                        break;
                    }
                }

                if (flag)
                {
                    flag = false;
                    number.Append(bank.BID);
                    number.Append(RandomNumber());
                    BillNumber = number.ToString();
                }
                else
                {
                    break;
                }
            }
        }

        private string RandomNumber()
        {
            Random rd = new Random();
            int number = rd.Next(1000000, 9999999);
            return number.ToString();
        }
    }
}
