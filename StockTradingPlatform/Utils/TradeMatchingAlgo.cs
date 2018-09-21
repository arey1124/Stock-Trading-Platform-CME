using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockTradingPlatform.Models;

namespace StockTradingPlatform.Utils
{
    public class TradeMatchingAlgo
    {
        StpDBEntities db = new StpDBEntities();
        public void MatchingAlgo(tblTradeRequest tradeRequest)
        {
            List<tblTradeRequest> possibleTradeRequests = new List<tblTradeRequest>();
            int remQty = (int)tradeRequest.requestQty;
            int quantity = 0;
            if(tradeRequest.requestType == "B")
            {
                possibleTradeRequests = db.tblTradeRequests.Where(t => t.requestType == "S" &&
                                                                 (t.requestStatus == "O" || t.requestStatus == "P") &&
                                                                  t.stockId == tradeRequest.stockId &&
                                                                  t.requestPrice <= tradeRequest.requestPrice).ToList();
            }
            else if(tradeRequest.requestType == "S")
            {
                possibleTradeRequests = db.tblTradeRequests.Where(t => t.requestType == "B" &&
                                                                 (t.requestStatus == "O" || t.requestStatus == "P") &&
                                                                  t.stockId == tradeRequest.stockId &&
                                                                  t.requestPrice >= tradeRequest.requestPrice).ToList();
            }
            foreach (tblTradeRequest request in possibleTradeRequests)
            {

                if (remQty == 0)
                    break;
                quantity = (int)((remQty <= request.remainingQty) ? remQty : request.remainingQty);
                remQty -= quantity; 
                if (tradeRequest.requestType == "B")
                {
                    UpdateTblTransaction(tradeRequest.requestId, request.requestId, (double)tradeRequest.requestPrice, (double)request.requestPrice, quantity);
                    UpdateTblWallet((int)request.uid, (double)quantity * (double)request.requestPrice);
                    UpdateTblHoldings((int)tradeRequest.uid, (int)request.uid, (int)tradeRequest.stockId, (int)quantity);
                }
                else if(tradeRequest.requestType == "S")
                {
                    UpdateTblTransaction(request.requestId, tradeRequest.requestId, (double)request.requestPrice, (double)tradeRequest.requestPrice, quantity);
                    UpdateTblHoldings((int)request.uid, (int)tradeRequest.uid, (int)tradeRequest.stockId, (int)quantity);
                }
                UpdateTblTradeRequests(request.requestId, (int)request.requestQty, (int)request.remainingQty - quantity);

            }
            UpdateTblTradeRequests(tradeRequest.requestId, (int)tradeRequest.requestQty , remQty);
            UpdateTblWallet((int)tradeRequest.uid, (double)(tradeRequest.requestQty - remQty) * (double)tradeRequest.requestPrice);
        }

        public void UpdateTblTransaction(int BuyerReqId, int SellerReqId, double BuyPrice, double SellPrice, int qty)
        {
            tblTransactions transaction = new tblTransactions();
            transaction.buyerReqId = BuyerReqId;
            transaction.sellerReqId = SellerReqId;
            transaction.buyPrice = Convert.ToDecimal(BuyPrice);
            transaction.sellPrice = Convert.ToDecimal(SellPrice);
            transaction.quantity = qty;
            transaction.time = DateTime.Now;
            db.tblTransactions.Add(transaction);
        }

        public void UpdateTblTradeRequests(int reqId, int qty, int remQty)
        {
            tblTradeRequest trequest = db.tblTradeRequests.SingleOrDefault(x => x.requestId == reqId);
            trequest.remainingQty = remQty;
            if (remQty == 0)
                trequest.requestStatus = "D";
            else if (remQty != qty)
                trequest.requestStatus = "P";
            else
                trequest.requestStatus = "O";
            db.SaveChanges();
        }

        public void UpdateTblHoldings(int buyerUid, int sellerUid, int StockId, int qty)
        {
            tblHoldings buyer = db.tblHoldings.SingleOrDefault(x => x.uid == buyerUid && x.stockId == StockId);
            if(buyer == null)
            {
                tblHoldings rec = new tblHoldings();
                rec.uid = buyerUid;
                rec.stockId = StockId;
                rec.Qty = qty;
                db.tblHoldings.Add(rec);
            }
            else
            {
                buyer.Qty = buyer.Qty + qty;
                db.SaveChanges();
            }
            tblHoldings seller = db.tblHoldings.SingleOrDefault(x => x.uid == sellerUid && x.stockId == StockId);
            seller.Qty = seller.Qty - qty;
            db.SaveChanges();
        }

        public void UpdateTblWallet(int uid, double amount)
        {
            tblWallet wallet = db.tblWallets.SingleOrDefault(x => x.uid == uid);
            wallet.balance = Convert.ToDecimal((double)wallet.balance + amount);
            db.SaveChanges();
        }
    }
}