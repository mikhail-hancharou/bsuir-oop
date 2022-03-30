using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem.Entities
{
    public class Outsider
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Transaction Transaction { get; set; }

        public void TransactionRequest()
        {
            //TODO
        }

        public void SalaryProjectRequest()
        {
            //TODO
        }
    }
}
