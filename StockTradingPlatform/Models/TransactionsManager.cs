using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace StockTradingPlatform.Models
{
    public class TransactionsManager
    {
        public StpDBEntities StpDBEntities { get; set; }
        public tblTransactions tblTransactions { get; set; }
        public tblTradeRequest tblTradeRequests { get; set; }
        public tblUser tblUsers { get; set; }
        public tblStock tblStocks { get; set; }

        public TransactionsManager()
        {
            this.StpDBEntities = new StpDBEntities();
            this.tblTransactions = new tblTransactions();
            this.tblTradeRequests = new tblTradeRequest();
            this.tblUsers = new tblUser();
            this.tblStocks = new tblStock();
        }
    }
}