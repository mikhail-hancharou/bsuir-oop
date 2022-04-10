using BankSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    public class Accumulate
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public double Amount { get; set; }
        public double Percent { get; set; }
        public DateTime Time { get; set; }

        public Accumulate() { }
    }
}
