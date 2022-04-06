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
        public int OverPaymentPercent { get; set; }
        public List<Client> Clients { get; set; }
        public double TotalMoney { get; set; }

        public Bank() { }

        //public Bank(string BID, List<Client> clients = null, double totalMoney = 0)
        //{
        //    this.BID = BID;
        //    this.Clients = clients;
        //    this.TotalMoney = totalMoney;
        //}

        protected void AddUser(Client user)
        {
            Clients.Add(user);
        }
    }
}
