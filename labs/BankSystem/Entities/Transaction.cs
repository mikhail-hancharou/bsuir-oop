using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    public class Transaction
    {
        public int Id { get; set; }
        public Bill DestBill { get; set; }
        public double Amount { get; set; }
        public string BID { get; set; }
        public bool BankOperation { get; set; }
        public bool Blocked { get; set; }

        public Transaction(Bill inBill, double amount)
        {
            this.DestBill = inBill;
            this.Amount = amount;
        }

        public Transaction()
        {
        }

        public void Undo()
        {

        }
    }
}
