using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem.Comparer
{
    class BillComparer : IEqualityComparer<Bill>
    {
        public bool Equals(Bill bill1, Bill bill2)
        {
            if (bill1 == null && bill2 == null) { return true; }
            if (bill1 == null || bill2 == null) { return false; }
            if (bill1.BillNumber == bill2.BillNumber) { return true; }
            return false;
        }

        public int GetHashCode(Bill t)
        {
            string code = t.BillNumber + ":" + t.BillNumber;
            return code.GetHashCode();
        }
    }
}
