using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockTradingPlatform.Models
{
    public class UserManager
    {

        public StpDBEntities StpDBEntities { get; set; }
        public tblStock tblStock { get; set; }
        public tblUser tblUser { get; set; }
        public tblWallet tblWallet { get; set; }
        public tblHoldings tblHolding { get; set; }
        public tblTradeRequest tblTradeRequest { get; set; }
        public tblTransactions tblTransactions { get; set; }
        public IEnumerable<tblHoldings> tblHoldings { get; set; }

        public UserManager()
        {
            StpDBEntities = new StpDBEntities();

        }

    }
}