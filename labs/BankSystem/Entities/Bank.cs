using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem.Entities
{
    public class Bank
    {
        public int Id { get; set; }
        public string BID { get; set; }
        public string Name { get; set; }
        public double OverPaymentPercent { get; set; } = 0;
        public double AccumPercent { get; set; } = 0;
        public List<Accumulate> ClientAccum { get; set; }
        public double TotalMoney { get; set; } = 0;

        public Bank() { }
    }
}
