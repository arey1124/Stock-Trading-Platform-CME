using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockTradingPlatform.Models
{
    public class UserManager : StockManager
    {

       
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