using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public double Money { get; set; }
        public string UNP { get; set; }
        public string BID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public  bool Confirmed { get; set; }
        public bool Requested { get; set; }
        public List<BillsNSalary> BillsNSalaries { get; set; }
        
        public void AddWorker(string billNumber, int salary)
        {
            using AppContext db = new AppContext();
            BillsNSalary billsNSalary = new BillsNSalary { BillNumber = billNumber, Salary = salary };
            BillsNSalaries.Add(billsNSalary);
            db.Companies.Update(this);
            db.BillsNSalaries.Add(billsNSalary);
            db.SaveChanges();
        }
    }
}
