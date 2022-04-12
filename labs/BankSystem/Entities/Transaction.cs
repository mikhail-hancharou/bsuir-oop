using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    public class Transaction
    {
        public int Id { get; set; }
        public string DestBill { get; set; }
        public double Amount { get; set; }
        public string BID { get; set; }
        public bool BankOperation { get; set; }
        public bool Blocked { get; set; }

        public Transaction(string destBill, double amount)
        {
            DestBill = destBill;
            Amount = amount;
        }

        public Transaction() { }
    }
}
