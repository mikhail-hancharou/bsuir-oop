using BankSystem.Comparer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;

namespace BankSystem.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public User User { get; set; }
        public DateTime ExpiryDate { get; set; }
        public HashSet<Bill> Bills { get; set; }

        public void OpenBill()
        {
            //TODO
            AppContext db = new AppContext();
            Bank bank;//= new Bank();
            //string[] BankAndBID = Regex.Split(roleBankBox.Text.Trim(), "//");
            //bank = db.Banks.AsEnumerable().ToList().Find(b => b.Name == BankAndBID[0] && b.BID == BankAndBID[1]);
            //Bills.Add(new Bill(bank));
        }

        public void CloseBill()
        {
            //TODO
        }

        public void CreditRequest()
        {
            //TODO
        }

        public void InstallmentRequest()
        {
            //TODO
        }
    }
}
