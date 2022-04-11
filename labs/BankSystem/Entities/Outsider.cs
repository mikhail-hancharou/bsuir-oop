using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem.Entities
{
    public class Outsider
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string UNP { get; set; }
        public List<Transaction> Transaction { get; set; }

        public void SalaryProjectRequest()
        {
            //TODO
        }

        public void TransactionRequest()
        {
            //TODO
        }
    }
}
