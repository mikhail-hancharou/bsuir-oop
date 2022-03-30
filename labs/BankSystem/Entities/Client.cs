using BankSystem.Comparer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BankSystem.Entities
{
    //[Keyless]
    public class Client
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string PassportNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public HashSet<Bill> Bills { get; set; }

        public void OpenBill()
        {
            //TODO
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
