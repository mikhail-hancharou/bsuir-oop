using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem.Entities
{
    public class User
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public string PassportNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Password { get; set; }

    }
}
