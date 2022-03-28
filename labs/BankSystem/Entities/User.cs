using BankSystem.Comparer;
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
        public Roles Role { get; set; }
        public bool Confirmed { get; set; }
        public bool Blocked { get; set; }
        public HashSet<Bill> Bills { get; set; }

        public User(string Name, string LastName, string Id, string PassportNumber,
            DateTime time, string Password, Roles Role, bool Confirmed = false, bool Blocked = false)
        {
            this.Name = Name;
            this.LastName = LastName;
            this.Id = Id;
            this.PassportNumber = PassportNumber;
            this.ExpiryDate = time;
            this.Password = Password;
            this.Role = Role;
            this.Confirmed = Confirmed;
            this.Blocked = Blocked;
            this.Role = Role;
            this.Bills = new HashSet<Bill>(new BillComparer());
        }
    }
}
