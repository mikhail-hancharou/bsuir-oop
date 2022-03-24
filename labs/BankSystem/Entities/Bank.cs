using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem.Entities
{
    abstract public class Bank
    {
        public string BID { get; set; }
        List<User> users { get; set; }
        double totalMoney { get; set; }
        protected Bank(string BID, List<User> users = null, double totalMoney = 0)
        {
            this.BID = BID;
            this.users = users;
            this.totalMoney = totalMoney;
        }

        protected void AddUser(User user)
        {
            users.Add(user);
        }
    }
}
