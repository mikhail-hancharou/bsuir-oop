using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    public class Transaction
    {
        public string InBill { get; set; }
        public double Amount { get; set; }

        public Transaction(string inBill, double amount)
        {
            this.InBill = inBill;
            this.Amount = amount;
        }

        public void Undo()
        {

        }
    }
}
