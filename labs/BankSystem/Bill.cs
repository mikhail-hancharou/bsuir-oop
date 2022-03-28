using BankSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    public class Bill
    {
        public double Money { get; set; }
        public string BillNumber { get; set; }
        public List<Transaction> Transactions { get; set;}

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
                foreach (User u in bank.Users)
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
