using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem.Entities
{
    public class Admin
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Bank myWork { get; set; }

        public void ChooseBank(Bank bank)
        {
            myWork = bank;
        }

        public void UndoUserActions()
        {
            //TODO
        }

        public void TrackLogs()
        {
            //TODO
        }
    }
}
