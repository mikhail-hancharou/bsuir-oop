using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem.Entities
{
    public class Log
    {
        public int Id { get; set; }
        public string BID { get; set; }
        public string LogInfo { get; set; }

        public Log() { }

        public Log(string bid, string loginfo)
        {
            BID = bid;
            LogInfo = loginfo;
        }

        public string Bid
        {
            get
            {
                return BID;
            }
        }

        public string Loginfo
        {
            get
            {
                return LogInfo;
            }
        }
    }
}
