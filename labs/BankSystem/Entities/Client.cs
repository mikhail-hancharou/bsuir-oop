using BankSystem.Comparer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;

namespace BankSystem.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public User User { get; set; }
        public DateTime ExpiryDate { get; set; }
        public HashSet<Bill> Bills { get; set; }

        public void OpenBill(Bill bill)
        {
            AppContext db = new AppContext();
            Bills.Add(bill);
            db.Clients.Update(this);
            db.SaveChanges();
        }
    }
}
