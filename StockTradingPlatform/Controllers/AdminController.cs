using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StockTradingPlatform.Models;

namespace StockTradingPlatform.Controllers
{

    public class AdminController : Controller
    {

        private StpDBEntities db = new StpDBEntities();
        // GET: Admin

        //index is dashboard
        public ActionResult Index()
        {
            if (Session["user"] == null || Session["userName"] == null)
                return Redirect("~/Login.aspx");
            StockManager manager = new StockManager();


            ViewBag.usercount = string.Format("{0:n0}", manager.StpDBEntities.tblUsers.Where(x => x.status == "A" && x.role == "U").Count());
            ViewBag.stockcount = string.Format("{0:n0}", manager.StpDBEntities.tblStocks.Where(x => x.status == "A").Count());
            ViewBag.traderequestcount = string.Format("{0:n0}", manager.StpDBEntities.tblTradeRequests.Count());
            ViewBag.transactionscount = string.Format("{0:n0}", manager.StpDBEntities.tblTransactions.Count());

            return View();
        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            Session["userName"] = null;
            return Redirect("~/Login.aspx");
        }

        //above code is chayank's







        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// prajjwal's code starts
        /// </summary>
        /// <returns></returns>
        public ActionResult AllUsersTradeRequests()
        {
            if (Session["user"] == null || Session["userName"] == null)
                return Redirect("~/Login.aspx");
            var tblTradeRequests = db.tblTradeRequests.Include(t => t.tblStock).Include(t => t.tblUser);
            return View(tblTradeRequests.ToList());
        }
        
     
        // GET: tblUsers
        public ActionResult ViewUsers() //AdminController => ViewUsers()
        {
            if (Session["user"] == null || Session["userName"] == null)
                return Redirect("~/Login.aspx");
            return View(db.tblUsers.ToList());
        }
         

        // GET: tblUsers/Edit/5
        public ActionResult EditUser(int? id) //AdminController => EditUser()
        {
            if (Session["user"] == null || Session["userName"] == null)
                return Redirect("~/Login.aspx");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUser tblUsers = db.tblUsers.Find(id);
            if (tblUsers == null)
            {
                return HttpNotFound();
            }
            return View(tblUsers);
        }

        // POST: tblUsers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser([Bind(Include = "uid,fname,lname,email,mobile,dob,address,role,status")] tblUser tblUsers)
        {
            if (Session["user"] == null || Session["userName"] == null)
                return Redirect("~/Login.aspx");
            if (ModelState.IsValid)
            {
                db.Entry(tblUsers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewUsers");
            }
            return View(tblUsers);
        }

        // GET: tblTransactions
        public ActionResult AllTransactions()     
        {
            if (Session["user"] == null || Session["userName"] == null)
                return Redirect("~/Login.aspx");
            TransactionsManager model = new TransactionsManager();
            return View(model);
        }




        /// <summary>
        /// prajjwals code ends
        /// </summary>
        /// <returns></returns>
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////chayank's code starts
        //below everything related to stock chyaank's code below
        public ActionResult ListOfStocks()
        {//to pass two models in one onject
            if (Session["user"] == null || Session["userName"] == null)
                return Redirect("~/Login.aspx");
            StockManager model = new StockManager();
            
            return View(model);
        }


        // get : addStock
        public ActionResult AddStock()
        {
            if (Session["user"] == null || Session["userName"] == null)
                return Redirect("~/Login.aspx");
            ViewBag.name = "ADD STOCK";
            StockManager model = new StockManager();

            return View(model);
        }

        //post for addstock
        [HttpPost]
        public ActionResult AddStock(StockManager ob)
        {
            if (Session["user"] == null || Session["userName"] == null)
                return Redirect("~/Login.aspx");
            //inserted data to stock table
            ob.tblStock.quantity_remaining = ob.tblStock.quantity;
            ob.tblStock.stockId = (int)ob.StpDBEntities.getLastStockId().FirstOrDefault() + 1;
            ob.tblStock.addedBy = 1;
            ob.StpDBEntities.tblStocks.Add(ob.tblStock);

           

            //inserted data to stock price table
            ob.tblStocksPrice.stockId = ob.tblStock.stockId;
            ob.tblStocksPrice.highPrice = ob.tblStocksPrice.currentPrice;
            ob.tblStocksPrice.lowPrice = ob.tblStocksPrice.currentPrice;
            ob.tblStocksPrice.timeOfDay = DateTime.Now;
            ob.StpDBEntities.tblStocksPrices.Add(ob.tblStocksPrice);

            //saving changes to databases
            ob.StpDBEntities.SaveChanges();

            return RedirectToAction("listofstocks");


        }


        // get : addStock
        public ActionResult EditStock(int id)
        {
            if (Session["user"] == null || Session["userName"] == null)
                return Redirect("~/Login.aspx");
            StockManager model = new StockManager();
            model.tblStock=model.StpDBEntities.tblStocks.Single(x => x.stockId == id );
            int index = (int)model.StpDBEntities.getIdexFromStockPriceTable(id).FirstOrDefault();
            model.tblStocksPrice = model.StpDBEntities.tblStocksPrices.Single(x => x.id==index);

            System.Diagnostics.Debug.WriteLine("this is a bug " + model.tblStocksPrice.stockId +"  : price " + model.tblStocksPrice.currentPrice);
            ViewBag.name = "EDIT";
            
            return View(model);
        }

        //post for addstock
        [HttpPost]
        public ActionResult EditStock(StockManager ob)
        {
            if (Session["user"] == null || Session["userName"] == null)
                return Redirect("~/Login.aspx");
            System.Diagnostics.Debug.WriteLine("this is a bug " + ob.tblStocksPrice.stockId + "  : price " + ob.tblStocksPrice.currentPrice+"qty addded or subtracted "+ob.qty);

            //to check if qty added or subtracted is corrected
           




            // if a has a value, assign it to aNum, if not assign 0 to aNum

            int aNum = ob.qty.HasValue ? ob.qty.Value : 0;
            int bNum = (int)ob.tblStock.quantity;
            int cNum = (int)ob.tblStock.quantity_remaining;
            if (aNum < 0)
            {
                aNum = -aNum;
                System.Diagnostics.Debug.WriteLine("this is a bug " + ob.tblStocksPrice.stockId + "  : price " + ob.tblStocksPrice.currentPrice + "qty addded or subtracted " + ob.qty);

                if (aNum > cNum)
                {
                    System.Diagnostics.Debug.WriteLine("please enter valid quantity to be subtracted as it is more than quantity remaining");

                    ViewBag.error = "please enter valid quantity to be subtracted as it is more than quantity remaining";
                    ViewBag.name = "EDIT";
                    return View(ob);
                }
                else
                {
                    
                    bNum =bNum- aNum;
                    cNum = cNum-aNum;
                    ob.tblStock.quantity = bNum;
                    ob.tblStock.quantity_remaining = cNum;


                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("addition: "+bNum+" + "+aNum+" ="+(aNum+bNum));
                System.Diagnostics.Debug.WriteLine("addition: " + cNum + " + " + aNum + " =" + (aNum + cNum));

                bNum = bNum+aNum;
                cNum = cNum+aNum;
                ob.tblStock.quantity = bNum;
                ob.tblStock.quantity_remaining = cNum;
            }

            ob.StpDBEntities.Entry(ob.tblStock).State = EntityState.Modified;


            ob.tblStocksPrice.lowPrice = ob.tblStocksPrice.currentPrice;
            ob.tblStocksPrice.highPrice = ob.tblStocksPrice.currentPrice;
            ob.tblStocksPrice.timeOfDay = DateTime.Now;


            ob.StpDBEntities.Entry(ob.tblStocksPrice).State = EntityState.Modified;
            ob.StpDBEntities.SaveChanges();
           /* if (ModelState.IsValid)
            {
                
                ob.StpDBEntities.SaveChanges();
                return RedirectToAction("listofstocks");
            }
            ob.StpDBEntities.SaveChanges();*/


            return RedirectToAction("listofstocks");



        }

        /// <summary>
        /// chayanks code end
        /// </summary>
        /// 
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }

}