using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem.Entities
{
    public class Bank
    {
        public string BID { get; set; }
        public List<User> Users { get; set; }
        double TotalMoney { get; set; }
        protected Bank(string BID, List<User> users = null, double totalMoney = 0)
        {
            this.BID = BID;
            this.Users = users;
            this.TotalMoney = totalMoney;
        }

        protected void AddUser(User user)
        {
            Users.Add(user);
        }
    }
}
