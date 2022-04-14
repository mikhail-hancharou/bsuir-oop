using BankSystem.Comparer;
using BankSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BankSystem.Reg
{
    class RegModel
    {
        private readonly AppContext db;
        public RegModel()
        {
            db = new AppContext();
        }

        public bool LoginCheck(string login)
        {
            return db.Users.AsEnumerable().Any(u => u.Login == login);
        }

        public bool PasswNumberCheck(string passwNumber)
        {
            return db.Users.AsEnumerable().Any(u => u.PassportNumber == passwNumber);
        }

        public DateTime DateTimeCheck(string date)
        {
            if (Regex.IsMatch(date, @"\d{2}\.\d{2}\.\d{2}"))
            {
                int day = Convert.ToInt32(Regex.Match(date, @"^\d{2}\.").Value[..^1]);
                int month = Convert.ToInt32(Regex.Match(date, @"\.\d{2}\.").Value[1..^1]);
                int year = Convert.ToInt32(Regex.Match(date, @"\.\d{2}$").Value[1..]);

                if (day > 31 || month > 12 || year < 22 || (day < DateTime.Now.Day && month < DateTime.Now.Month))
                {
                    return new DateTime(0, 0, 0);
                }
                else
                {
                    return new DateTime(2000 + year, month, day);
                }
            }
            else
            {
                return new DateTime(0, 0, 0);
            }
        }

        public Bank FindBank(string info)
        {
            string[] BankAndBID = Regex.Split(info, "//");
            return db.Banks.AsEnumerable().ToList().Find(b => b.Name == BankAndBID[0] && b.BID == BankAndBID[1]);
        }

        public void AddUser(User User, int role, DateTime date, Bank bank)
        {
            db.Users.Add(User);
            switch (role)
            {
                case 0:
                    Client client = new Client
                    {
                        User = User,
                        ExpiryDate = date,
                        Bills = new HashSet<Bill>(new BillComparer()),
                    };
                    db.Clients.Add(client);
                    break;
                case 1:
                    Outsider outsider = new Outsider { User = User };
                    db.Outsiders.Add(outsider);
                    break;
                case 2:
                    Operator @operator = new Operator { User = User, myWork = bank };
                    db.Operators.Add(@operator);
                    break;
                case 3:
                    Manager manager = new Manager { User = User, BID = bank.BID };
                    db.Managers.Add(manager);
                    break;
                case 4:
                    Admin admin = new Admin { User = User, myWork = bank };
                    db.Admins.Add(admin);
                    break;
                default:
                    break;
            }

            db.SaveChanges();
        }
    }
}
