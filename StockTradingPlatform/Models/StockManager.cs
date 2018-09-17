using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using StockTradingPlatform.Models;
namespace StockTradingPlatform.Models
{
    public class StockManager
    {
        
        public StpDBEntities StpDBEntities { get; set; }
        public tblStock tblStock { get; set; }
        public tblStocksPrice tblStocksPrice { get; set; }
        public tblStocksHistory tblStocksHistory { get; set; }
        public int? qty { get; set; }

        public StockManager()
        {
            this.StpDBEntities = new StpDBEntities();
            this.tblStock = new tblStock();
            this.tblStocksPrice = new tblStocksPrice();
            this.tblStocksHistory = new tblStocksHistory();
        }
        /*
        public StpDBEntities GetEntity()
        {
            return this.stpentity;
        }

        public tblStock GetStockTable()
        {
            return this.stk ;
        }
        public tblStocksPrice GetStockPriceTable()
        {
            return this.stk_price;
        }

        public tblStocksHistory GetStockHistoryTable()
        {
            return this.stk_history;
        }
        public IEnumerable<tblStock> GetStockRecords()
        {
            return this.stpentity.tblStocks;
        }
        public IEnumerable<tblStocksPrice> GetStockPriceRecords()
        {
            return this.stpentity.tblStocksPrices;
        }

        public IEnumerable<tblStocksHistory> GetStockHistoryRecords()
        {
            return this.stpentity.tblStocksHistories;
        }


        /// adding stock to stock table and also stock price
        public void AddToStockTable()
        {


            try
            {
                System.Diagnostics.Debug.WriteLine("this is a bug place KJHBDCHBJHBCD no code entered"+this.stk.stockName);

                this.stpentity.tblStocks.Add(this.stk);
                this.stpentity.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine(" this is a bug place KJHBDCHBJHBCD Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }

        }

        public void AddToStockPriceTable()
        {
            try
            {
                this.stpentity.tblStocksPrices.Add(this.stk_price);
                this.stpentity.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }*/
    }
}