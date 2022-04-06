using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem.Entities
{
    public class Installement
    {
        public int Id { get; set; }
        public bool Confirmed { get; set; }
        public DateTime ConfirmedTime { get; set; }
        public int Months { get; set; }
        public double Money { get; set; }

        public Installement() { }
    }
}
