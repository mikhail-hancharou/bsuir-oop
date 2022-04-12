using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem.Entities
{
    public class CompanyTransfer
    {
        public int Id { get; set; }
        public string From { get; set; }
        public int Amount { get; set; }
        public string DestBill { get; set; }

        public CompanyTransfer() { }
    }
}
