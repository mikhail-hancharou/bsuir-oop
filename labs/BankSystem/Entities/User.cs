using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BankSystem.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PassportNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string TNumber { get; set; }
        public bool Confirmed { get; set; }

        public User() { }
    }
}
