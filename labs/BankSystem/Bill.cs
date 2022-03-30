using BankSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    public class Bill
    {
        public int Id { get; set; }
        public double Money { get; set; }
        public string BillNumber { get; set; }
        public bool Blocked { get; set; }
        public bool Freezed { get; set; }
        public List<Transaction> Transactions { get; set;}

        public Bill() { }//

        public Bill(Bank bank)
        {
            this.Money = 0;
            BillInizializer(bank);

        }

        private void BillInizializer(Bank bank)
        {
            StringBuilder number = new StringBuilder(10);
            number.Append(bank.BID);
            number.Append(RandomNumber());
            this.BillNumber = number.ToString();
            bool flag = false;

            while (true)
            {
                foreach (Client u in bank.Clients)
                {
                    if (u.Bills.Contains(this))
                    {
                        flag = true;
                        break;
                    }
                }

                if (flag)
                {
                    flag = false;
                    number.Append(bank.BID);
                    number.Append(RandomNumber());
                    this.BillNumber = number.ToString();
                }
                else
                {
                    break;
                }
            }
        }

        private string RandomNumber()
        {
            Random rd = new Random();
            int number = rd.Next(1000000, 9999999);
            return number.ToString();
        }
    }
}
