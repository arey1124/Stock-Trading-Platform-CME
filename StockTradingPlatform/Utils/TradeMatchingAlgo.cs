using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockTradingPlatform.Models;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StockTradingPlatform.Utils
{
    public class TradeMatchingAlgo
    {
        StpDBEntities db = new StpDBEntities();

        public void MatchingAlgo(tblTradeRequest tradeRequest)
        {
            List<tblTradeRequest> possibleTradeRequests = new List<tblTradeRequest>();
            int remQty = (int)tradeRequest.requestQty;
            int reqQty = (int)tradeRequest.requestQty;
            int quantity = 0;
            if(tradeRequest.requestType == "B")
            {
                possibleTradeRequests = db.tblTradeRequests.Where(t => t.requestType == "S" &&
                                                                 (t.requestStatus == "O" || t.requestStatus == "P") &&
                                                                  t.stockId == tradeRequest.stockId &&
                                                                  t.requestPrice <= tradeRequest.requestPrice &&
                                                                  t.uid != tradeRequest.uid).ToList();
            }
            else if(tradeRequest.requestType == "S")
            {
                possibleTradeRequests = db.tblTradeRequests.Where(t => t.requestType == "B" &&
                                                                 (t.requestStatus == "O" || t.requestStatus == "P") &&
                                                                  t.stockId == tradeRequest.stockId &&
                                                                  t.requestPrice >= tradeRequest.requestPrice &&
                                                                  t.uid != tradeRequest.uid).ToList();
            }
            foreach (tblTradeRequest request in possibleTradeRequests.ToList())
            {
                if (remQty == 0)
                    break;
                quantity = (int)((remQty <= request.remainingQty) ? remQty : request.remainingQty);
                remQty -= quantity; 
                if (tradeRequest.requestType == "B")
                {
                    UpdateTblTransaction(tradeRequest.requestId, request.requestId, (double)tradeRequest.requestPrice, (double)request.requestPrice, quantity);
                    UpdateTblTransacts(tradeRequest.requestId, request.requestId, (double)tradeRequest.requestPrice, (double)request.requestPrice, quantity);
                    UpdateTblWallet((int)request.uid, (double)quantity * (double)request.requestPrice);
                    UpdateTblHoldings((int)tradeRequest.uid, (int)request.uid, (int)tradeRequest.stockId, (int)quantity);
                    //UpdateTblTradeRequests(request.requestId, (int)request.requestQty, (int)request.remainingQty - quantity);
                    //SendMail(tradeRequest, quantity);
                    //SMail(request, quantity);
                    //SMail(tradeRequest, quantity);
                }
                else if(tradeRequest.requestType == "S")
                {
                    UpdateTblTransaction(request.requestId, tradeRequest.requestId, (double)request.requestPrice, (double)tradeRequest.requestPrice, quantity);
                    UpdateTblTransacts(request.requestId, tradeRequest.requestId, (double)request.requestPrice, (double)tradeRequest.requestPrice, quantity);
                    UpdateTblHoldings((int)request.uid, (int)tradeRequest.uid, (int)tradeRequest.stockId, (int)quantity);
                    //UpdateTblTradeRequests(request.requestId, (int)request.requestQty, (int)request.remainingQty - quantity);
                    //SendMail(tradeRequest, quantity);
                    //SMail(request, quantity);
                    //SMail(tradeRequest, quantity);
                }
                UpdateTblTradeRequests(request.requestId, (int)request.requestQty, (int)request.remainingQty - quantity);
            }
            UpdateTblTradeRequests(tradeRequest.requestId, (int)tradeRequest.requestQty , remQty);
            UpdateTblWallet((int)tradeRequest.uid, (double)(tradeRequest.requestQty - remQty) * (double)tradeRequest.requestPrice);
            if(reqQty != remQty)
                SendMail(tradeRequest, reqQty - remQty);
        }

        public void UpdateTblTransacts(int BuyerReqId, int SellerReqId, double BuyPrice, double SellPrice, int qty)
        {
            String buyName = db.getUserName(BuyerReqId).FirstOrDefault().ToString();
            String sellname = db.getUserName(SellerReqId).FirstOrDefault().ToString();
            String sName = db.getStockName(BuyerReqId).FirstOrDefault().ToString();
            tblTransact transaction = new tblTransact();
            transaction.buyerReqId = BuyerReqId;
            //transaction.buyerName = db.getUserName(BuyerReqId).ToString();
            transaction.buyerName = buyName;
            transaction.sellerReqId = SellerReqId;
            //transaction.sellerName = db.getUserName(SellerReqId).ToString();
            transaction.sellerName = sellname;
            transaction.stock = sName;
            //System.Diagnostics.Debug.WriteLine("\n\n{0} {1} {2}\n\n",buyName,sellname,sName);
            //transaction.stock = db.getStockName(BuyerReqId).ToString();
            transaction.buyPrice = Convert.ToDecimal(BuyPrice);
            transaction.sellPrice = Convert.ToDecimal(SellPrice);
            transaction.quantity = qty;
            transaction.time = DateTime.Now;
            db.tblTransacts.Add(transaction);

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
            {
                trequest.requestStatus = "D";
            }
            else if (remQty != qty)
            {
                trequest.requestStatus = "P";
            }
            else
            {
                trequest.requestStatus = "O";
            }
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
                rec.remQty = qty;
                db.tblHoldings.Add(rec);
            }
            else
            {
                buyer.Qty = buyer.Qty + qty;
                buyer.remQty = buyer.remQty + qty;
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

        public async Task<int> SMail(tblTradeRequest request, int quantity)
        {
            Task<int> task = new Task<int>(() => SendMail(request, quantity));
            task.Start();
            int res = await task;
            return res;
        }


        public int SendMail(tblTradeRequest req, int qty)
        {
            int s = 0;
            tblUser user = db.tblUsers.SingleOrDefault(x => x.uid == req.uid);
            string eMail = user.email;
            string fname = user.fname;
            tblTransactions trans = db.tblTransactions.OrderByDescending(x => x.time).First();
            
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("cme.stp@gmail.com");
                mail.To.Add(eMail);
                mail.Subject = "Trade Requested Executed";
                mail.Body = "Hello " + fname + ",\n\nCongratulations! Your Trade Request with RequestId " + req.requestId + " is successfully executed.";
                mail.Body += "\n\nBelow are the details of Transaction :\nTransaction Id: " + trans.transactionId + "\nStock Name: " + db.getStockName(trans.buyerReqId).FirstOrDefault().ToString() + "\nQuantity: " + qty + "\n\nPlease find more details on website.\n\n\nHappy Trading!";
                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("cme.stp@gmail.com", "%TGB6yhn^YHN5tgb");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                SmtpServer.Dispose();
            }
            catch (Exception ex)
            {
                s = 0;
            }
            
            return s;
        }
    }
}